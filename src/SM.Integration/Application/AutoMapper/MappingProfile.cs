using AutoMapper;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models.AccountReceivable;
using SM.MQ.Models.BillToPlay;
using SM.MQ.Models.Category;
using SM.MQ.Models.Customer;
using SM.MQ.Models.Product;
using SM.MQ.Models.Supplier;

namespace SM.Integration.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Category
            CreateMap<CategoryViewModel, ResponseCategoryOut>().ReverseMap();

            // Product
            CreateMap<ProductViewModel, ResponseProductOut>().ReverseMap();

            // Supplier
            CreateMap<SupplierViewModel, ResponseSupplierOut>().ReverseMap();

            // Customer
            CreateMap<CustomerViewModel, ResponseCustomerOut>().ReverseMap();

            // BillToPay
            CreateMap<BillToPayViewModel, ResponseBillToPayOut>().ReverseMap();

            // AccountReceivable
            CreateMap<AccountReceivableViewModel, ResponseAccountReceivableOut>().ReverseMap();
        }
    }
}
