using SM.Integration.Application.ViewModels;
using SM.MQ.Models;

namespace SM.Integration.Application.Interfaces
{
    public interface IBillToPayService
    {
        Task<BillToPayViewModel> GetBillToPayById(Guid id);
        Task<IEnumerable<BillToPayViewModel>> GetAllBillToPay();
        Task<ResponseOut> AddBillToPay(BillToPayViewModel bill);
        Task<ResponseOut> UpdateBillToPay(BillToPayViewModel bill);
        Task<IEnumerable<SupplierViewModel>> GetAllSupplier();
    }
}
