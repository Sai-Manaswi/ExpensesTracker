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
    }
}
