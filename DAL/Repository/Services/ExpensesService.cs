using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class ExpensesService : IExpenses
    {


        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<GetAllExpenses_Result> GetAllExpenses()
        {
            var expenses=context.GetAllExpenses().ToList();
            return expenses;
        }

        public List<GetBudgetReport_Result> GetBudgetReport(int year, int? month)
        {
            var expenses = context.GetBudgetReport(year, month).ToList();
            return expenses;
        }


        public List<GetMonthlyBudgetNotification_Result> GetMonthlyBudgetNotification()
        {
            var expenses = context.GetMonthlyBudgetNotification().ToList();
            return expenses;
        }

        public List<GetMonthlyReport_Result> GetMonthlyReport(int year, int month)
        {
            var expenses = context.GetMonthlyReport(year, month).ToList();
            return expenses;
        }

        public List<GetTotalExpensesByCategory_Result> GetTotalExpensesByCategory(int year, int month, int? day)
        {
            var expenses = context.GetTotalExpensesByCategory(year, month, day).ToList();
            return expenses;
        }

        public List<GetTotalExpensesByCategoryAndStatus_Result> GetTotalExpensesByCategoryAndStatus(int year, int month)
        {
            var expenses = context.GetTotalExpensesByCategoryAndStatus(year, month).ToList();
            return expenses;

        }


        public ValueDataResponse<Expens> AddupdateExpenses(Expens req)
        {
            ValueDataResponse<Expens> response = new ValueDataResponse<Expens>();

            try
            {
                var exisitngdata = context.Expenses.FirstOrDefault(s => s.Id == req.Id);

                if(exisitngdata == null)
                {
                    var obj = new Expens
                    {
                        ExpenseDate = req.ExpenseDate,
                        Amount = req.Amount,
                        Description = req.Description,
                        CategoryId = req.CategoryId,
                        StatusId = req.StatusId,
                        PaymentMethodId = req.PaymentMethodId,
                        CreatedBy = req.CreatedBy,
                        CreatedAt = DateTime.Now,
                        UpdatedBy = req.UpdatedBy,
                        UpdatedAt = DateTime.Now,
                        Photo = req.Photo

                    };
                    context.Expenses.Add(obj);
                    context.SaveChanges();


                    response.IsSuccess = true;
                    response.EndUserMessage = "Data Added successfully";

                }

                else
                {
                    exisitngdata.Id = req.Id;
                    exisitngdata.ExpenseDate = exisitngdata.ExpenseDate;
                    exisitngdata.Amount = req.Amount;
                    exisitngdata.Description = req.Description;
                    exisitngdata.CategoryId = req.CategoryId;
                    exisitngdata.StatusId = req.StatusId;
                    exisitngdata.PaymentMethodId = req.PaymentMethodId;
                    exisitngdata.CreatedBy = req.CreatedBy;
                    exisitngdata.CreatedAt = exisitngdata.CreatedAt;
                    exisitngdata.UpdatedBy = req.UpdatedBy;
                    exisitngdata.UpdatedAt = DateTime.Now;
                    exisitngdata.Photo = req.Photo;

                    context.SaveChanges();

                    response.IsSuccess = true;
                    response.EndUserMessage = "Data Updated successfully";
                }
            }


            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = "Data failed to Add or Update :" + ex;
            }

            return response;
        }

        public List<GetHighestPurchaseCategory_Result> GetHighestPurchaseCategory()
        {
            var expenses = context.GetHighestPurchaseCategory().ToList();
            return expenses;
        }

        public List<GetExpensesByStatus_Result> GetExpensesByStatus(int statusId)
        {
            var expenses = context.GetExpensesByStatus(statusId).ToList();
            return expenses;
        }
    }

}
