using AutoMapper;
using Newtonsoft.Json;
using SM.Integration.Application.Htpp.Financial;
using SM.Integration.Application.Htpp.People;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.ViewModels;
using SM.MQ.Models;
using SM.MQ.Models.BillToPlay;
using SM.MQ.Operators;

namespace SM.Integration.Application.Services
{
    public class BillToPayService : IBillToPayService
    {
        private readonly IPublish _publish;
        private readonly IMapper _mapper;
        private readonly IPeopleClient _peopleClient;
        private readonly IFinancialClient _financialClient;

        public BillToPayService(IPublish publish, IMapper mapper, IPeopleClient peopleClient, IFinancialClient financialClient)
        {
            _publish = publish;
            _mapper = mapper;
            _peopleClient = peopleClient;
            _financialClient = financialClient;
        }

        public async Task<BillToPayViewModel> GetBillToPayById(Guid id)
        {
            var bill = await _financialClient.GetBillToPayById(id);
            return bill;
        }

        public async Task<IEnumerable<BillToPayViewModel>> GetAllBillToPay()
        {
            var bill = await _financialClient.GetAllBillToPay();
            return bill;
        }

        public async Task<ResponseOut> AddBillToPay(BillToPayViewModel bill)
        {
            var BillToPay = _mapper.Map<ResponseBillToPayOut>(bill);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(BillToPay),
                Queue = "AddBillToPay"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<ResponseOut> UpdateBillToPay(BillToPayViewModel bill)
        {
            var BillToPay = _mapper.Map<ResponseBillToPayOut>(bill);

            var mapIn = new RequestIn
            {
                Host = "localhost",
                Result = JsonConvert.SerializeObject(BillToPay),
                Queue = "UpdateBillToPay"
            };

            var response = await _publish.DoRPC<RequestIn, ResponseOut>(mapIn);
            return response;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSupplier()
        {
            var suppliers = await _peopleClient.GetAllSupplier();
            return suppliers;
        }
    }
}
