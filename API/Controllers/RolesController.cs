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
    public class RolesController : ApiController
    {
        IRoles obj = new RoleService();

        [HttpGet]
        [Route("GetRoles")]

        public HttpResponseMessage GetUsers()
        {
            var result = obj.GetRoles();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
