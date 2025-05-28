using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Data.Repositories;
using Warehouse.Services.Implementations;
using Warehouse.Services.Interfaces;
using Warehouse.UI;

namespace Warehouse
{
    public class Startup
    {
        public Startup()
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Connect to Databases
            var masterCs = ConfigurationManager.ConnectionStrings["MasterDb"].ConnectionString;
            var authCs = ConfigurationManager.ConnectionStrings["AuthDb"].ConnectionString;
            var auditCs = ConfigurationManager.ConnectionStrings["AuditDb"].ConnectionString;
            var mediaCs = ConfigurationManager.ConnectionStrings["MediaDb"].ConnectionString;
            var transactionCs = ConfigurationManager.ConnectionStrings["TransactionDb"].ConnectionString;

            // Context registration
            services.AddDbContext<MasterDbContext>(opts => opts.UseSqlServer(masterCs));
            services.AddDbContext<AuthDbContext>(opts => opts.UseSqlServer(authCs));
            services.AddDbContext<AuditDbContext>(opts => opts.UseSqlServer(auditCs));
            services.AddDbContext<MediaDbContext>(opts => opts.UseSqlServer(mediaCs));
            services.AddDbContext<TransactionDbContext>(opts => opts.UseSqlServer(transactionCs));

            // Main repository registration
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); <- useless

            // Repositories registration
            services.AddScoped<IProductRepository>(sp =>
                new ProductRepository(
                    sp.GetRequiredService<MasterDbContext>(),
                    sp.GetRequiredService<AuditDbContext>()));
            services.AddScoped<ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<ILoginRoleRepository>(sp =>
                new LoginRoleRepository(
                    sp.GetRequiredService<AuthDbContext>(),
                    sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<LoginRoleRepository>();
            services.AddScoped<IAuditRepository>(sp =>
                new AuditRepository(
                    sp.GetRequiredService<AuditDbContext>(),
                    sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<AuditRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<SupplierRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<IOperationRepository>(sp =>
                new OperationRepository(
                    sp.GetRequiredService<AuditDbContext>(),
                    sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<OperationRepository>();
            services.AddScoped<IDeletedProductRepository>(sp =>
                new DeletedProductRepository(sp.GetRequiredService<AuditDbContext>()));
            services.AddScoped<IReceiptRepository>(sp =>
                new ReceiptRepository(
                    sp.GetRequiredService<TransactionDbContext>(),
                    sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<ReceiptRepository>();
            // *============================

            // Services registrations
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ProductService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<ILoginRoleService, LoginRoleService>();
            services.AddScoped<LoginRoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<AuditService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<SupplierService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<OperationService>();
            services.AddScoped<IDeletedProductService, DeletedProductService>();
            services.AddScoped<DeletedProductService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            // *============================

            // Repositories with context registrations
            // *MasterDbContext
            services.AddScoped<IRepository<Category>>(sp =>
                new Repository<Category, MasterDbContext>(sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<IRepository<Product>>(sp =>
                new Repository<Product, MasterDbContext>(sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<IRepository<Employee>>(sp =>
                new Repository<Employee, MasterDbContext>(sp.GetRequiredService<MasterDbContext>()));
            services.AddScoped<IRepository<Supplier>>(sp =>
                new Repository<Supplier, MasterDbContext>(sp.GetRequiredService<MasterDbContext>()));

            // *AuditDbContext
            services.AddScoped<IRepository<Operation>>(sp =>
                new Repository<Operation, AuditDbContext>(sp.GetRequiredService<AuditDbContext>()));
            services.AddScoped<IRepository<Audit>>(sp =>
                new Repository<Audit, AuditDbContext>(sp.GetRequiredService<AuditDbContext>()));
            services.AddScoped<IRepository<DeletedProduct>>(sp =>
                new Repository<DeletedProduct, AuditDbContext>(sp.GetRequiredService<AuditDbContext>()));

            // *MediaDbContext
            services.AddScoped<IRepository<Photo>>(sp =>
                new Repository<Photo, MediaDbContext>(sp.GetRequiredService<MediaDbContext>()));

            // *TransactionDbContext
            services.AddScoped<IRepository<Receipt>>(sp =>
                new Repository<Receipt, TransactionDbContext>(sp.GetRequiredService<TransactionDbContext>()));
            services.AddScoped<IRepository<Invoice>>(sp =>
                new Repository<Invoice, TransactionDbContext>(sp.GetRequiredService<TransactionDbContext>()));
            services.AddScoped<IRepository<ReceiptDetails>>(sp =>
                new Repository<ReceiptDetails, TransactionDbContext>(sp.GetRequiredService<TransactionDbContext>()));
            services.AddScoped<IRepository<InvoiceDetails>>(sp =>
                new Repository<InvoiceDetails, TransactionDbContext>(sp.GetRequiredService<TransactionDbContext>()));

            // *AuthDbContext
            services.AddScoped<IRepository<LoginRole>>(sp =>
                new Repository<LoginRole, AuthDbContext>(sp.GetRequiredService<AuthDbContext>()));
        }

        // Register forms
        public void ConfigureForms(IServiceCollection services)
        {
            // If first form needs to hand over life-cycle to another form,
            // it should be registered as AddScoped,
            // and it's not neccessary to register other forms,
            // because they will be resolved from the service provider.
            services.AddScoped<LoginForm>();
        }
    }
}
