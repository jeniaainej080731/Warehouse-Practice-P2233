using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class EmployeeRepository
        : Repository<Employee, MasterDbContext>, IEmployeeRepository
    {
        private readonly MasterDbContext _master;
        private readonly AuthDbContext _auth;
        private readonly IMapper _mapper;

        public EmployeeRepository(
            MasterDbContext masterDbContext,
            AuthDbContext authDbContext,
            IMapper mapper)
            : base(masterDbContext)
        {
            _master = masterDbContext ?? throw new ArgumentNullException(nameof(masterDbContext));
            _auth = authDbContext ?? throw new ArgumentNullException(nameof(authDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Employee>> GetByNameAsync(string name) =>
            await _master.Employees
                         .Where(e => e.FullName.Contains(name))
                         .ToListAsync();

        public async Task<Employee> GetByIdWithInvoicesAsync(int id) =>
            await _master.Employees
                         .Include(e => e.Invoices)
                         .FirstOrDefaultAsync(e => e.EmployeeId == id);

        public async Task<Employee> GetByIdWithOperationsAsync(int id) =>
            await _master.Employees
                         .Include(e => e.Operations)
                         .FirstOrDefaultAsync(e => e.EmployeeId == id);

        public async Task<Employee> GetByIdWithInvoicesAndOperationsAsync(int id) =>
            await _master.Employees
                         .Include(e => e.Invoices)
                         .Include(e => e.Operations)
                         .FirstOrDefaultAsync(e => e.EmployeeId == id);

        public async Task<IEnumerable<EmployeeDto>> GetAllWithRolesAsync()
        {
            var employees = await _master.Employees.ToListAsync();
            var roles = await _auth.LoginRoles.ToListAsync();

            return employees
                .Join(roles,
                      e => e.Login_Id,
                      r => r.LoginId,
                      (e, r) => new EmployeeDto
                      {
                          EmployeeId = e.EmployeeId,
                          FullName = e.FullName,
                          Email = e.Email,
                          PhoneNumber = e.PhoneNumber,
                          Role = r.Role,
                          PhotoPath = e.PhotoPath
                      })
                .ToList();
        }

        public async Task<EmployeeDto> GetByIdWithRoleAsync(int id)
        {
            var e = await _master.Employees
                                 .FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (e == null) return null;

            var r = await _auth.LoginRoles
                               .FirstOrDefaultAsync(lr => lr.LoginId == e.Login_Id);

            return new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                FullName = e.FullName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Role = r?.Role,
                PhotoPath = e.PhotoPath
            };
        }
    }
}
