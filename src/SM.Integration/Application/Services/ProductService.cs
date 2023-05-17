using AutoMapper;
using Newtonsoft.Json;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models;
using SM.MQ.Models.Product;
using SM.MQ.Models.Supplier;
using SM.MQ.Operators;

namespace SM.Integration.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IPublish _publish;
        private readonly IMapper _mapper;

        public ProductService(IPublish publish, IMapper mapper)
        {
            _publish = publish;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = id.ToString(),
                Queue = "GetProductById"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseProductOut>(mapIn);
            return _mapper.Map<ProductViewModel>(response);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProduct()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "GetAllProduct"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseProductOut[]>(mapIn);
            return _mapper.Map<IEnumerable<ProductViewModel>>(result);
        }

        public async Task<ResponseOut> AddProduct(ProductViewModel productViewModel)
        {
            var Product = _mapper.Map<ResponseProductOut>(productViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(Product),
                Queue = "AddProduct"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<ResponseOut> UpdateProduct(ProductViewModel productViewModel)
        {
            var Product = _mapper.Map<ResponseProductOut>(productViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(Product),
                Queue = "UpdateProduct"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSupplier()
        {
            var mapIn = new RequestIn
            {
                Host = "localhost",
                Queue = "GetAllSupplier"
            };

            var result = await _publish.DoRPC<RequestIn, ResponseSupplierOut[]>(mapIn);
            return _mapper.Map<IEnumerable<SupplierViewModel>>(result);
        }
    }
}
