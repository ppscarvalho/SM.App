using SM.Integration.Application.ViewModels;
using SM.MQ.Models;

namespace SM.Integration.Application.Interfaces
{
    public interface IAccountReceivableService
    {
        Task<AccountReceivableViewModel> GetAccountReceivableById(Guid id);
        Task<IEnumerable<AccountReceivableViewModel>> GetAllAccountReceivable();
        Task<ResponseOut> AddAccountReceivable(AccountReceivableViewModel account);
        Task<ResponseOut> UpdateAccountReceivable(AccountReceivableViewModel account);
        Task<IEnumerable<CustomerViewModel>> GetAllCustomer();
    }
}
