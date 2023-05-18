using Microsoft.AspNetCore.Mvc;
using SM.Integration.Application.Htpp.Catalog;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;

namespace SM.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICatalogClient _catalogClient;

        public ProductController(IProductService productService, ICatalogClient catalogClient)
        {
            _productService = productService;
            _catalogClient = catalogClient;
        }


        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var product = await _productService.GetAllProduct();
            return View(product.OrderBy(p => p?.ResponseSupplierOut?.CorporateName));

        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _catalogClient.GetProductById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            var supplier = await _productService.GetAllSupplier();
            var category = await _catalogClient.GetAllCategory();
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productService.GetProductById(id);

            var supplier = await _productService.GetAllSupplier();
            var category = await _catalogClient.GetAllCategory();
            product.SupplierViewModels = supplier.ToList();
            product.CategoryViewModels = category.ToList();

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                productViewModel.PurchaseValue /= 100.0M;
                productViewModel.SaleValue /= 100.0M;
                productViewModel.ProfitMargin /= 100.0M;

                var result = await _productService.UpdateProduct(productViewModel);

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
