using Microsoft.AspNetCore.Mvc;
using SM.Integration.Application.Htpp.Financial;
using SM.Integration.Application.Htpp.People;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;

namespace SM.App.Controllers
{
    public class BillToPayController : Controller
    {
        private readonly IBillToPayService _billToPayService;
        private readonly IFinancialClient _financialClient;
        private readonly IPeopleClient _peopleClient;

        public BillToPayController(IBillToPayService billToPayService, IFinancialClient financialClient, IPeopleClient peopleClient)
        {
            _billToPayService = billToPayService;
            _financialClient = financialClient;
            _peopleClient = peopleClient;
        }

        // GET: BillToPayController
        public async Task<IActionResult> Index()
        {
            var bills = await _billToPayService.GetAllBillToPay();

            foreach (var item in bills)
                item.SupplierViewModel = await GetSupplierById(item.SupplierId);

            return View(bills);
        }

        // GET: BillToPayController/Create
        public async Task<IActionResult> Create()
        {
            var supplier = await _billToPayService.GetAllSupplier();
            var bill = new BillToPayViewModel
            {
                SupplierViewModels = supplier.ToList(),
            };

            return View(bill);
        }

        // POST: BillToPayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillToPayViewModel bill)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                bill.Value /= 100.0M;

                var result = await _billToPayService.AddBillToPay(bill);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<SupplierViewModel> GetSupplierById(Guid id)
        {
            return await _peopleClient.GetSupplierById(id);
        }
    }
}
