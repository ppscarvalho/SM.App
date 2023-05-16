using Microsoft.AspNetCore.Mvc;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;

namespace SM.App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoriaController
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoryService.GetAllCategory();
            return View(categorias);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _categoryService.AddCategory(categoryViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var resp = await _categoryService.GetCategoryById(id);
            return View(resp);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _categoryService.UpdateCategory(categoryViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
