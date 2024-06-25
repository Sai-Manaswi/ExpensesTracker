using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class ExpensesService : IExpenses
    {


        ExpensesTrackerEntities context = new ExpensesTrackerEntities();

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

        public List<SP_GetDropdowns_Result> SP_GetDropdowns(string name)
        {
            var expenses = context.SP_GetDropdowns(name).ToList();
            return expenses;
        }



    }

}
