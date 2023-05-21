using Microsoft.AspNetCore.Mvc;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;

namespace SM.App.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: SupplierController
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSupplier();
            return View(suppliers);
        }

        // GET: SupplierController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var supplier = await _supplierService.GetSupplierById(id);
            return View(supplier);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            var supplier = new SupplierViewModel
            {
                States = _supplierService.GetAllStates()
            };
            return View(supplier);
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierViewModel SupplierViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _supplierService.AddSupplier(SupplierViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var supplier = await _supplierService.GetSupplierById(id);
            supplier.States = _supplierService.GetAllStates();
            return View(supplier);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupplierViewModel SupplierViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _supplierService.UpdateSupplier(SupplierViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
