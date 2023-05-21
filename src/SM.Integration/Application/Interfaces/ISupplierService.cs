using SM.Integration.Application.ViewModels;
using SM.MQ.Models;

namespace SM.Integration.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierViewModel> GetSupplierById(Guid id);
        Task<IEnumerable<SupplierViewModel>> GetAllSupplier();
        Task<ResponseOut> AddSupplier(SupplierViewModel categoriaViewModel);
        Task<ResponseOut> UpdateSupplier(SupplierViewModel categoriaViewModel);
        IEnumerable<StateViewModel> GetAllStates();
    }
}
