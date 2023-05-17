using Microsoft.AspNetCore.Mvc;
using SM.Integration.Application.Htpp.Category;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;

namespace SM.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryClient _categoryClient;
        public ProductController(IProductService productService, ICategoryClient categoryClient)
        {
            _productService = productService;
            _categoryClient = categoryClient;
        }


        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var product = await _productService.GetAllProduct();
            return View(product);

        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            var supplier = await _productService.GetAllSupplier();
            var category = await _categoryClient.GetAllCategory();
            var product = new ProductViewModel
            {
                SupplierViewModels = supplier.ToList(),
                CategoryViewModels = category.ToList()
            };

            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                productViewModel.PurchaseValue /= 100.0M;
                productViewModel.SaleValue /= 100.0M;
                productViewModel.ProfitMargin /= 100.0M;

                var result = await _productService.AddProduct(productViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
