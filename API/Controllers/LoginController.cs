using DAL.Authentication;
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
    public class LoginController : ApiController
    {
        ILogin repos = new LoginService();

        [HttpPost]
        [Route("api/login")]

        public IHttpActionResult Login(LoginModelClass model)
        {
            if (ModelState.IsValid)
            {
                bool isValid = repos.ValidateUser(model.UserName, model.Password);
                if (isValid)
                {
                    return Ok("Login successful");
                }
                else
                {
                    return BadRequest("Invalid UserName or password");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
