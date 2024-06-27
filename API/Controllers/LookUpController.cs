using DAL.Repository.Interfaces;
using DAL.Repository.Services;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static DAL.Responses.RequestResModel;

namespace API.Controllers
{
    public class LookUpController : ApiController
    {
        ILookup _lookupRepository = new LookupService();

        [HttpGet]
        [Route("api/expenses/GetLookUpDetails")]
        public HttpResponseMessage SP_GetLookupwithDetails(bool pIsActive)
        {
            try
            {
                var expenses = _lookupRepository.SP_GetLookupwithDetails(pIsActive);
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/expenses/GetLookUpDropdown")]
        public HttpResponseMessage SP_GetLookUpDropdowns(string name)
        {
            try
            {
                var expenses = _lookupRepository.SP_GetLookUpDropdowns(name);
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/expenses/CreateLookUP")]
        public HttpResponseMessage CreateLookUP(LookupReq lookup)
        {
            var result = _lookupRepository.CreateLookUP(lookup);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


    }
}
