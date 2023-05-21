using Microsoft.AspNetCore.Mvc;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;

namespace SM.App.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var Customers = await _customerService.GetAllCustomer();
            return View(Customers);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var Customer = await _customerService.GetCustomerById(id);
            return View(Customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            var Customer = new CustomerViewModel
            {
                States = _customerService.GetAllStates()
            };
            return View(Customer);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel CustomerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _customerService.AddCustomer(CustomerViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var Customer = await _customerService.GetCustomerById(id);
            Customer.States = _customerService.GetAllStates();
            return View(Customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel CustomerViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _customerService.UpdateCustomer(CustomerViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
