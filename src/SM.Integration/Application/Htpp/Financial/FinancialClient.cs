using Microsoft.Extensions.Options;
using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;
using SM.Util.Extensions;
using SM.Util.Options;

namespace SM.Integration.Application.Htpp.Financial
{
    public class FinancialClient : ApiClientBase, IFinancialClient
    {
        private readonly APIsOptions _apisOptions;

        public FinancialClient(HttpClient httpClient, IOptions<APIsOptions> options) : base(httpClient)
        {
            _apisOptions = options.Value;
        }

        public async Task<IEnumerable<BillToPayViewModel>> GetAllBillToPay()
        {
            var result = await Get($"{_apisOptions.BaseUrlFinancial}/api/BillToPay/GetAllBillToPay");
            return result.DeserializeObject<IEnumerable<BillToPayViewModel>>();
        }

        public async Task<BillToPayViewModel> GetBillToPayById(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlFinancial}/api/BillToPay/GetBillToPayById", new { Id = id }, headers);
            return result.DeserializeObject<BillToPayViewModel>();
        }

        public async Task<IEnumerable<AccountReceivableViewModel>> GetAllAccountReceivable()
        {
            var result = await Get($"{_apisOptions.BaseUrlFinancial}/api/AccountReceivable/GetAllAccountReceivable");
            return result.DeserializeObject<IEnumerable<AccountReceivableViewModel>>();
        }

        public async Task<AccountReceivableViewModel> GetAccountReceivableById(Guid id)
        {
            var headers = new Dictionary<string, string> { { "authorization", $"Bearer {Guid.NewGuid}" } };
            var result = await Post($"{_apisOptions.BaseUrlFinancial}/api/AccountReceivable/GetAccountReceivableById", new { Id = id }, headers);
            return result.DeserializeObject<AccountReceivableViewModel>();
        }
    }
}
