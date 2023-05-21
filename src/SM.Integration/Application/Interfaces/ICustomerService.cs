using SM.Integration.Application.ViewModels;
using SM.MQ.Models;

namespace SM.Integration.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> GetCustomerById(Guid id);
        Task<IEnumerable<CustomerViewModel>> GetAllCustomer();
        Task<ResponseOut> AddCustomer(CustomerViewModel categoriaViewModel);
        Task<ResponseOut> UpdateCustomer(CustomerViewModel categoriaViewModel);
        IEnumerable<StateViewModel> GetAllStates();
    }
}
