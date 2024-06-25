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
    public class RolesController : ApiController
    {
        IRoles obj = new RoleRepository();

        [HttpGet]
        [Route("GetRoles")]

        public HttpResponseMessage GetUsers()
        {
            var result = obj.GetRoles();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

 

        [HttpGet]
        [Route("GetAllRolesSP")]

        public HttpResponseMessage GetAllRolesSP()
        {
            var result = obj.GetAllRolesSP();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        

        [HttpGet]
        [Route("DropdownRoles")]

        public HttpResponseMessage DropdownRoles()
        {
            var result = obj.DropdownRoles();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("AddUpdateRole")]

        public HttpResponseMessage AddUpdateRole(RoleReq role)
        {
            var result = obj.AddUpdateRole(role);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
