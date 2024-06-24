using DAL.Expense.edmx;
using DAL.Repository.Interfaces;
using DAL.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static DAL.Responses.RequestResModel;

namespace API.Controllers
{
    public class RoleController : ApiController
    {
        IRoles obj = new RoleRepository();

        [HttpPost]
        [Route("AddUpdateRole")]

        public HttpResponseMessage AddUpdateRole(RoleReq role)
        {
            var result = obj.AddUpdateRole(role);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
