using Microsoft.Extensions.Options;
using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;
using SM.Util.Extensions;
using SM.Util.Options;

namespace SM.Integration.Application.Htpp.People
{

    public class PeopleClient : ApiClientBase, IPeopleClient
    {
        private readonly APIsOptions _apisOptions;

        public PeopleClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSupplier()
        {
            var result = await Get($"{_apisOptions.BaseUrlPeople}/api/Supplier/GetAllSupplier");
            return result.DeserializeObject<IEnumerable<SupplierViewModel>>();
        }

        public async Task<SupplierViewModel> GetSupplierById(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlPeople}/api/Supplier/GetSupplierById", new { Id = id }, headers);
            return result.DeserializeObject<SupplierViewModel>();
        }
    }
}
