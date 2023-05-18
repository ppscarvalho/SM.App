using AutoMapper;
using Microsoft.Extensions.Options;
using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;
using SM.Util.Extensions;
using SM.Util.Options;

namespace SM.Integration.Application.Htpp.Catalog
{
    public class CatalogClient : ApiClientBase, ICatalogClient
    {
        private readonly APIsOptions _apisOptions;
        private readonly IMapper _mapper;

        public CatalogClient(HttpClient httpClient, IOptions<APIsOptions> options, IMapper mapper) : base(httpClient)
        {
            _apisOptions = options.Value;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategory()
        {
            var result = await Get($"{_apisOptions.BaseUrlCatalog}/api/Category/GetAllCategory");
            return result.DeserializeObject<IEnumerable<CategoryViewModel>>();
        }

        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlCatalog}/api/Product/GetProductById", new { Id = id }, headers);

            var prod = result.DeserializeObject<ProductViewModel>();

            return prod;
        }
    }
}
