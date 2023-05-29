using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;

namespace SM.Integration.Application.Htpp.Financial
{
    public interface IFinancialClient : IApiClientBase
    {
        //BillToPay
        Task<IEnumerable<BillToPayViewModel>> GetAllBillToPay();
        Task<BillToPayViewModel> GetBillToPayById(Guid id);

        //AccountReceivable
        Task<IEnumerable<AccountReceivableViewModel>> GetAllAccountReceivable();
        Task<AccountReceivableViewModel> GetAccountReceivableById(Guid id);
    }
}
