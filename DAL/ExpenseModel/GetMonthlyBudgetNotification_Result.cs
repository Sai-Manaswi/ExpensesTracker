//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.ExpenseModel
{
    using System;
    
    public partial class GetMonthlyBudgetNotification_Result
    {
        public string Notification { get; set; }
        public Nullable<decimal> ApprovedExpenses { get; set; }
        public Nullable<decimal> MonthlyBudget { get; set; }
        public Nullable<decimal> RemainingBudget { get; set; }
    }
}
