using SM.Integration.Application.ViewModels;
using SM.MQ.Models;

namespace SM.Integration.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetProductById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAllProduct();
        Task<ResponseOut> AddProduct(ProductViewModel productViewModel);
        Task<ResponseOut> UpdateProduct(ProductViewModel productViewModel);
        Task<IEnumerable<SupplierViewModel>> GetAllSupplier();
    }
}
