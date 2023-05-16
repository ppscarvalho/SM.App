using Microsoft.Extensions.Options;
using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;
using SM.Util.Extensions;
using SM.Util.Options;

namespace SM.Integration.Application.Htpp.Category
{
    public class CategoryClient : ApiClientBase, ICategoryClient
    {
        private readonly APIsOptions _apisOptions;

        public CategoryClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategory()
        {
            var result = await Get($"{_apisOptions.BaseUrlCategory}/api/Categoria/lista-categorias");
            return result.DeserializeObject<IEnumerable<CategoryViewModel>>();
        }
    }
}
