using AutoMapper;
using Newtonsoft.Json;
using SM.Integration.Application.Htpp.People;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models;
using SM.MQ.Models.Supplier;
using SM.MQ.Operators;

namespace SM.Integration.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IPublish _publish;
        private readonly IMapper _mapper;
        private readonly IPeopleClient _peopleClient;
        public SupplierService(IPublish publish, IMapper mapper, IPeopleClient peopleClient)
        {
            _publish = publish;
            _mapper = mapper;
            _peopleClient = peopleClient;
        }

        public async Task<SupplierViewModel> GetSupplierById(Guid id)
        {
            var suppliers = await _peopleClient.GetSupplierById(id);
            return suppliers;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSupplier()
        {
            var suppliers = await _peopleClient.GetAllSupplier();
            return suppliers;
        }

        public async Task<ResponseOut> AddSupplier(SupplierViewModel SupplierViewModel)
        {
            var Supplier = _mapper.Map<ResponseSupplierOut>(SupplierViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(Supplier),
                Queue = "AddSupplier"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<ResponseOut> UpdateSupplier(SupplierViewModel SupplierViewModel)
        {
            var Supplier = _mapper.Map<ResponseSupplierOut>(SupplierViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(Supplier),
                Queue = "UpdateSupplier"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public IEnumerable<StateViewModel> GetAllStates()
        {
            var states = new StateViewModel();
            return states.GetAllState();
        }
    }
}
