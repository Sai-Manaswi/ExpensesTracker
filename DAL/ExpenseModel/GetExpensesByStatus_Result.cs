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
    
    public partial class GetExpensesByStatus_Result
    {
        public int Id { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public Nullable<int> PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string Photo { get; set; }
    }
}
