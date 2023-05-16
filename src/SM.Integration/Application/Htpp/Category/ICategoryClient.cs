using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;

namespace SM.Integration.Application.Htpp.Category
{
    public interface ICategoryClient : IApiClientBase
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategory();
    }
}
