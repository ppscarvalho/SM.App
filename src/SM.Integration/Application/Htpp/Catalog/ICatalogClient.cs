using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;

namespace SM.Integration.Application.Htpp.Catalog
{
    public interface ICatalogClient : IApiClientBase
    {
        //Category
        Task<IEnumerable<CategoryViewModel>> GetAllCategory();

        //Product
        Task<ProductViewModel> GetProductById(Guid id);
    }
}
