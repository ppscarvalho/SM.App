using AutoMapper;
using Newtonsoft.Json;
using SM.Integration.Application.Htpp.People;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models;
using SM.MQ.Models.Customer;
using SM.MQ.Operators;

namespace SM.Integration.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IPublish _publish;
        private readonly IMapper _mapper;
        private readonly IPeopleClient _peopleClient;
        public CustomerService(IPublish publish, IMapper mapper, IPeopleClient peopleClient)
        {
            _publish = publish;
            _mapper = mapper;
            _peopleClient = peopleClient;
        }

        public async Task<CustomerViewModel> GetCustomerById(Guid id)
        {
            var Customers = await _peopleClient.GetCustomerById(id);
            return Customers;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomer()
        {
            var Customers = await _peopleClient.GetAllCustomer();
            return Customers;
        }

        public async Task<ResponseOut> AddCustomer(CustomerViewModel CustomerViewModel)
        {
            var Customer = _mapper.Map<ResponseCustomerOut>(CustomerViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(Customer),
                Queue = "AddCustomer"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<ResponseOut> UpdateCustomer(CustomerViewModel CustomerViewModel)
        {
            var Customer = _mapper.Map<ResponseCustomerOut>(CustomerViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(Customer),
                Queue = "UpdateCustomer"
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
