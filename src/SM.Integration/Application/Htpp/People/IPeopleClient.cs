using SM.Integration.Application.ViewModels;
using SM.Util.ApiClient;

namespace SM.Integration.Application.Htpp.People
{
    public interface IPeopleClient : IApiClientBase
    {
        //Supplier
        Task<IEnumerable<SupplierViewModel>> GetAllSupplier();
        Task<SupplierViewModel> GetSupplierById(Guid id);

        //Customer
        Task<IEnumerable<CustomerViewModel>> GetAllCustomer();
        Task<CustomerViewModel> GetCustomerById(Guid id);
    }
}
