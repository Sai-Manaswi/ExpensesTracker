using DAL.Authentication;
using DAL.Expense.edmx;
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
    [RoutePrefix("api/ExpenseTracker")]

    public class UserController : ApiController
    {
        IUser obj = new UserRepositoryServices();

        [HttpGet]
        [Route("GetUsers")]

        public HttpResponseMessage GetUsers()
        {
            var result = obj.GetUsers();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateUser")]

        public HttpResponseMessage CreateUser(User user)
        {
            var result = obj.CreateUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


    }
}
