using AutoMapper;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models.Category;
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
            CreateMap<ProductViewModel, ResponseProductOut>()
                .ForMember(dest => dest.ResponseCategoryOut, act => act.MapFrom(src => src.CategoryViewModel))
                .ForMember(dest => dest.ResponseSupplierOut, act => act.MapFrom(src => src.SupplierViewModel))
                .ReverseMap();

            // Supplier
            CreateMap<SupplierViewModel, ResponseSupplierOut>().ReverseMap();
        }
    }
}
