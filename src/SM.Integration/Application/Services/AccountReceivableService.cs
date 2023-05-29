using AutoMapper;
using Newtonsoft.Json;
using SM.Integration.Application.Htpp.Financial;
using SM.Integration.Application.Htpp.People;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models;
using SM.MQ.Models.AccountReceivable;
using SM.MQ.Operators;

namespace SM.Integration.Application.Services
{
    public class AccountReceivableService : IAccountReceivableService
    {
        private readonly IPublish _publish;
        private readonly IMapper _mapper;
        private readonly IFinancialClient _financialClient;
        private readonly IPeopleClient _peopleClient;
        public AccountReceivableService(IPublish publish, IMapper mapper, IFinancialClient financialClient, IPeopleClient peopleClient)
        {
            _publish = publish;
            _mapper = mapper;
            _financialClient = financialClient;
            _peopleClient = peopleClient;
        }

        public async Task<AccountReceivableViewModel> GetAccountReceivableById(Guid id)
        {
            var AccountReceivables = await _financialClient.GetAccountReceivableById(id);
            return AccountReceivables;
        }

        public async Task<IEnumerable<AccountReceivableViewModel>> GetAllAccountReceivable()
        {
            var AccountReceivables = await _financialClient.GetAllAccountReceivable();
            return AccountReceivables;
        }

        public async Task<ResponseOut> AddAccountReceivable(AccountReceivableViewModel AccountReceivableViewModel)
        {
            var AccountReceivable = _mapper.Map<ResponseAccountReceivableOut>(AccountReceivableViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(AccountReceivable),
                Queue = "AddAccountReceivable"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<ResponseOut> UpdateAccountReceivable(AccountReceivableViewModel AccountReceivableViewModel)
        {
            var AccountReceivable = _mapper.Map<ResponseAccountReceivableOut>(AccountReceivableViewModel);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(AccountReceivable),
                Queue = "UpdateAccountReceivable"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomer()
        {
            var Customers = await _peopleClient.GetAllCustomer();
            return Customers;
        }
    }
}
