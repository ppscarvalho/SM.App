using SM.Integration.Application.ViewModels;
using SM.MQ.Models;

namespace SM.Integration.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> GetCategoryById(Guid id);
        Task<IEnumerable<CategoryViewModel>> GetAllCategory();
        Task<ResponseOut> AddCategory(CategoryViewModel categoriaViewModel);
        Task<ResponseOut> UpdateCategory(CategoryViewModel categoriaViewModel);
    }
}
