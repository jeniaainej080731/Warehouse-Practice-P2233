using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;

namespace Warehouse
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Class -> DTO
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.LoginRole.Role));
            CreateMap<LoginRole, LoginRoleDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Audit, AuditDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<Operation, OperationDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName));
            CreateMap<DeletedProduct, DeletedProductsDto>();
            CreateMap<Audit, AuditDto>()
                .ForMember(d => d.ProductName, o => o.MapFrom(src =>
                    src.Product != null
                        ? src.Product.ProductName
                        : "(deleted)"))
                .ForMember(d => d.EmployeeName, o => o.MapFrom(src =>
                    src.Employee != null
                        ? src.Employee.FullName
                        : "(deleted)"));
            CreateMap<Receipt, ReceiptDto>()
                .ForMember(d => d.QuantityInReceipt, o => o.Ignore())
                .ForMember(d => d.PriceInReceipt, o => o.Ignore())
                .ForMember(d => d.ProductId, o => o.Ignore())
                .ForMember(d => d.ProductName, o => o.Ignore())
                .ForMember(d => d.EmployeeName, o => o.MapFrom(r => r.Employee.FullName));
            CreateMap<ReceiptDetails, ReceiptDto>()
                .ForMember(d => d.CustomerName, o => o.Ignore())
                .ForMember(d => d.ReceiptTotalAmount, o => o.Ignore())
                .ForMember(d => d.ReceiptDate, o => o.Ignore())
                .ForMember(d => d.EmployeeId, o => o.Ignore())
                .ForMember(d => d.EmployeeName, o => o.Ignore())
                .ForMember(d => d.ProductName, o => o.MapFrom(rd => rd.Product.ProductName))
                .ForMember(d => d.QuantityInReceipt, o => o.MapFrom(rd => rd.QuantityInReceipt))
                .ForMember(d => d.PriceInReceipt, o => o.MapFrom(rd => rd.PriceInReceipt))
                .ForMember(d => d.ProductId, o => o.MapFrom(rd => rd.ProductId));
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(d => d.QuantityInInvoice, o => o.Ignore())
                .ForMember(d => d.PriceInInvoice, o => o.Ignore())
                .ForMember(d => d.EmployeeName, o => o.MapFrom(i => i.Employee.FullName))
                .ForMember(d => d.SupplierName, o => o.MapFrom(i => i.Supplier.SupplierName));
            CreateMap<InvoiceDetails, InvoiceDto>()
                .ForMember(d => d.QuantityInInvoice, o => o.MapFrom(id => id.QuantityInInvoice))
                .ForMember(d => d.PriceInInvoice, o => o.MapFrom(id => id.PriceInInvoice))
                .ForMember(d => d.SupplierName, o => o.Ignore())
                .ForMember(d => d.EmployeeName, o => o.Ignore());

            // DTO -> Class
            CreateMap<ProductDto, Product>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<LoginRoleDto, LoginRole>();
            CreateMap<CategoryDto, Category>();
            CreateMap<AuditDto, Audit>();
            CreateMap<OperationDto, Operation>()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
            CreateMap<DeletedProductsDto, DeletedProduct>();
            CreateMap<AuditDto, Audit>()
            // мапим только те поля, которые реально есть в Audit
                .ForMember(dest => dest.InventoryAuditId, opt => opt.MapFrom(src => src.InventoryAuditId))
                .ForMember(dest => dest.CheckedQuantity, opt => opt.MapFrom(src => src.CheckedQuantity))
                .ForMember(dest => dest.AuditDate, opt => opt.MapFrom(src => src.AuditDate))
                .ForMember(dest => dest.InventoryAuditComments, opt => opt.MapFrom(src => src.InventoryAuditComments))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            // ОЧЕНЬ ВАЖНО: не трогаем навигации
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
            CreateMap<ReceiptDto, Receipt>()
                .ForMember(r => r.ReceiptDetails, o => o.Ignore());
            CreateMap<InvoiceDto, Invoice>()
                .ForMember(i => i.InvoiceDetails, o => o.Ignore());
        }
    }
}
