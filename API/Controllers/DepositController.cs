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
        [Route("api/expenses/GetAllDeposits")]
        public HttpResponseMessage GetAllExpenses()
        {
            try
            {
                var expenses = _depositRepository.GetDeposits();
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
