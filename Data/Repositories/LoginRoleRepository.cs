using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class LoginRoleRepository : Repository<LoginRole, AuthDbContext>, ILoginRoleRepository
    {
        private readonly AuthDbContext _ctx;
        private readonly MasterDbContext masterDbContext;
        public LoginRoleRepository(AuthDbContext ctx, MasterDbContext masterDbContext)
            : base(ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            this.masterDbContext = masterDbContext ?? throw new ArgumentNullException(nameof(masterDbContext));
        }

        public async Task<IEnumerable<LoginRoleDto>> GetAllAsync()
        {
            var loginRoles = await _ctx.LoginRoles.ToListAsync();
            return loginRoles.Select(lr => new LoginRoleDto
            {
                LoginId = lr.LoginId,
                Login = lr.Login,
                Password = lr.Password,
                Role = lr.Role
            });
        }

        public async Task<LoginRoleDto> GetByIdAsync(int id)
        {
            var lr = await _ctx.LoginRoles.FindAsync(id);
            if (lr == null)
                throw new KeyNotFoundException($"LoginRole with ID {id} not found.");

            return new LoginRoleDto
            {
                LoginId = lr.LoginId,
                Login = lr.Login,
                Password = lr.Password,
                Role = lr.Role
            };
        }

        public async Task AddAsync(LoginRoleDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var entity = new LoginRole
            {
                Login = dto.Login,
                Password = dto.Password,
                Role = dto.Role
            };

            await _ctx.LoginRoles.AddAsync(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoginRoleDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var lr = await _ctx.LoginRoles.FindAsync(dto.LoginId);
            if (lr == null)
                throw new KeyNotFoundException($"LoginRole with ID {dto.LoginId} not found.");

            lr.Login = dto.Login;
            lr.Password = dto.Password;
            lr.Role = dto.Role;

            _ctx.LoginRoles.Update(lr);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lr = await _ctx.LoginRoles.FindAsync(id);
            if (lr == null)
                throw new KeyNotFoundException($"LoginRole with ID {id} not found.");

            _ctx.LoginRoles.Remove(lr);
            await _ctx.SaveChangesAsync();
        }

        public async Task<LoginRole> GetByCredentialsAsync(string login, string password)
        {
            return await _ctx.LoginRoles.FirstOrDefaultAsync(lr => lr.Login == login && lr.Password == password);
        }

        public async Task<LoginRole> GetByEmployeeIdAsync(int employeeId)
        {
            var employee = await masterDbContext.Employees.FindAsync(employeeId);
            if (employee == null)
                return null;

            return await _ctx.LoginRoles.FirstOrDefaultAsync(lr => lr.LoginId == employee.Login_Id);
        }
    }
}
