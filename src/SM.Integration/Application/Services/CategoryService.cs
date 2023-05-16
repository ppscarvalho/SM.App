using AutoMapper;
using Newtonsoft.Json;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models;
using SM.MQ.Models.Category;
using SM.MQ.Operators;

namespace SM.Integration.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IPublish _publish;
        private readonly IMapper _mapper;

        public CategoryService(IPublish publish, IMapper mapper)
        {
            _publish = publish;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> GetCategoryById(Guid id)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = id.ToString(),
                Queue = "GetCategoryById"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseCategoryOut>(mapIn);
            return _mapper.Map<CategoryViewModel>(response);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategory()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "GetAllCategory"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseCategoryOut[]>(mapIn);
            return _mapper.Map<IEnumerable<CategoryViewModel>>(result);
        }

        public async Task<ResponseOut> AddCategory(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<ResponseCategoryOut>(categoryViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(category),
                Queue = "AddCategory"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<ResponseOut> UpdateCategory(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<ResponseCategoryOut>(categoryViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(category),
                Queue = "UpdateCategory"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }
    }
}
