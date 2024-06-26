using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;

namespace API.Controllers
{
    public class ExpensesController : ApiController
    {
        IExpenses _expensesRepository = new ExpensesService();
        [HttpGet]
        [Route("api/expenses/GetTotalExpenses")]
        public HttpResponseMessage GetTotalExpenses(int year, int month, int? day = null)
        {
            try
            {
                var expenses = _expensesRepository.GetTotalExpensesByCategory(year, month, day);
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/expenses/GetTotalExpensesByCategoryAndStatus")]
        public HttpResponseMessage GetTotalExpensesByCategoryAndStatus(int year, int month)
        {
            try
            {
                var expenses = _expensesRepository.GetTotalExpensesByCategoryAndStatus(year, month);
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/expenses/GetMonthlyReport")]
        public HttpResponseMessage GetMonthlyReport(int year, int month)
        {
            try
            {
                var expenses = _expensesRepository.GetMonthlyReport(year, month);
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/expenses/GetBudgetReport")]
        public HttpResponseMessage GetBudgetReport(int year, int? month = null)
        {
            try
            {
                var expenses = _expensesRepository.GetBudgetReport(year, month);
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/expenses/GetMonthlyBudgetNotification")]
        public HttpResponseMessage GetMonthlyBudgetNotification()
        {
            try
            {
                var expenses = _expensesRepository.GetMonthlyBudgetNotification();
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("api/expenses/GetAllExpenses")]
        public HttpResponseMessage GetAllExpenses()
        {
            try
            {
                var expenses = _expensesRepository.GetAllExpenses();
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/expenses/GetHighestPurchaseCategory()")]
        public HttpResponseMessage GetHighestPurchaseCategory()
        {
            try
            {
                var expenses = _expensesRepository.GetHighestPurchaseCategory();
                return Request.CreateResponse(HttpStatusCode.OK, expenses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/expenses/AddupdateExpenses")]


        public HttpResponseMessage AddupdateExpenses(Expens req)
        {
            var result = _expensesRepository.AddupdateExpenses(req);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpPost]
        [Route("api/expenses/updateExpenses")]


        public HttpResponseMessage updateExpenses(Expens req)
        {
            var result = _expensesRepository.AddupdateExpenses(req);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}
