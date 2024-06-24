using DAL.Expense.edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IExpenses
    {
        List<GetTotalExpensesByCategory_Result> GetTotalExpensesByCategory(int year, int month, int? day);
        List<GetTotalExpensesByCategoryAndStatus_Result> GetTotalExpensesByCategoryAndStatus(int year, int month);

        List<GetMonthlyReport_Result> GetMonthlyReport(int year, int month);

        List<GetBudgetReport_Result> GetBudgetReport(int year, int month);

        //List<SP_GetDropdowns_Result> SP_GetDropdowns(string name);

        List<GetMonthlyBudgetNotification_Result> GetMonthlyBudgetNotification();
    }
}
