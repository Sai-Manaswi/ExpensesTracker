using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DepositController : ApiController
    {
        IDeposit _depositRepository = new DepositService();


        [HttpGet]
        [Route("api/expenses/GetDeposits()")]
        public HttpResponseMessage GetDeposits1()
        {
            try
            {
                var expenses = _depositRepository.GetDeposits1();
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/expenses/AddupdateDeposite")]

        public HttpResponseMessage AddupdateDeposite(Deposit deposit)
        {
            var result = _depositRepository.AddupdateDeposite(deposit);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
