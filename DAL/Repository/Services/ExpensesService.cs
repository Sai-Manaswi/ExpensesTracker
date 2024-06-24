using DAL.Expense.edmx;
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


        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<GetBudgetReport_Result> GetBudgetReport(int year, int month)
        {
            var expenses = context.GetBudgetReport(year, month).ToList();
            return expenses;
        }

        public List<Expens> GetExpens()
        {
            var res=context.Expenses.ToList();
            return res;
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

        //public List<SP_GetDropdowns_Result> SP_GetDropdowns(string name)
        //{
        //    var expenses = context.SP_GetDropdowns(name).ToList();
        //    return expenses;
        //}
    }

}
