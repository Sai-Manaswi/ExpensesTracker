﻿using DAL.ExpenseModel;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL.Repository.Interfaces
{
    public interface IExpenses
    {
        List<GetTotalPurchasesByCategory_Result> GetTotalPurchasesByCategory(int year, int? month, int? day);
        List<GetTotalExpensesByCategoryAndStatus_Result> GetTotalExpensesByCategoryAndStatus(int year, int month);

        List<GetMonthlyReport_Result> GetMonthlyReport(int year, int? month);

        List<GetBudgetReport_Result> GetBudgetReport(int year,int? month);


        List<GetMonthlyBudgetNotification_Result> GetMonthlyBudgetNotification();
        List<GetAllExpenses_Result> GetAllExpenses();

        ValueDataResponse<Expens> AddupdateExpenses(Expens req);
        List<GetHighestPurchaseCategory_Result> GetHighestPurchaseCategory();
        List<GetExpensesByStatus_Result> GetExpensesByStatus(int statusId);

    }
}
