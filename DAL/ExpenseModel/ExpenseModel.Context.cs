﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExpensesTrackerEntities : DbContext
    {
        public ExpensesTrackerEntities()
            : base("name=ExpensesTrackerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<Expens> Expenses { get; set; }
        public virtual DbSet<LookUpDetail> LookUpDetails { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int AddExpense(Nullable<System.DateTime> expenseDate, string amount, string description, Nullable<int> categoryId, Nullable<int> statusId, Nullable<int> paymentMethodId, string createdBy, string photo)
        {
            var expenseDateParameter = expenseDate.HasValue ?
                new ObjectParameter("ExpenseDate", expenseDate) :
                new ObjectParameter("ExpenseDate", typeof(System.DateTime));
    
            var amountParameter = amount != null ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            var statusIdParameter = statusId.HasValue ?
                new ObjectParameter("StatusId", statusId) :
                new ObjectParameter("StatusId", typeof(int));
    
            var paymentMethodIdParameter = paymentMethodId.HasValue ?
                new ObjectParameter("PaymentMethodId", paymentMethodId) :
                new ObjectParameter("PaymentMethodId", typeof(int));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var photoParameter = photo != null ?
                new ObjectParameter("Photo", photo) :
                new ObjectParameter("Photo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddExpense", expenseDateParameter, amountParameter, descriptionParameter, categoryIdParameter, statusIdParameter, paymentMethodIdParameter, createdByParameter, photoParameter);
        }
    
        public virtual ObjectResult<GetAllExpenses_Result> GetAllExpenses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllExpenses_Result>("GetAllExpenses");
        }
    
        public virtual ObjectResult<GetBudgetReport_Result> GetBudgetReport(Nullable<int> year, Nullable<int> month)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBudgetReport_Result>("GetBudgetReport", yearParameter, monthParameter);
        }
    
        public virtual ObjectResult<GetHighestCategory_Result> GetHighestCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetHighestCategory_Result>("GetHighestCategory");
        }
    
        public virtual ObjectResult<GetMonthlyBudgetNotification_Result> GetMonthlyBudgetNotification()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMonthlyBudgetNotification_Result>("GetMonthlyBudgetNotification");
        }
    
        public virtual ObjectResult<GetMonthlyReport_Result> GetMonthlyReport(Nullable<int> year, Nullable<int> month)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("Month", month) :
                new ObjectParameter("Month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMonthlyReport_Result>("GetMonthlyReport", yearParameter, monthParameter);
        }
    
        public virtual ObjectResult<GetTotalExpensesByCategory_Result> GetTotalExpensesByCategory(Nullable<int> year, Nullable<int> month, Nullable<int> day)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("month", month) :
                new ObjectParameter("month", typeof(int));
    
            var dayParameter = day.HasValue ?
                new ObjectParameter("day", day) :
                new ObjectParameter("day", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTotalExpensesByCategory_Result>("GetTotalExpensesByCategory", yearParameter, monthParameter, dayParameter);
        }
    
        public virtual ObjectResult<GetTotalExpensesByCategoryAndStatus_Result> GetTotalExpensesByCategoryAndStatus(Nullable<int> year, Nullable<int> month)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("month", month) :
                new ObjectParameter("month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTotalExpensesByCategoryAndStatus_Result>("GetTotalExpensesByCategoryAndStatus", yearParameter, monthParameter);
        }
    
        public virtual ObjectResult<string> GetUserPermissionsByUsername(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetUserPermissionsByUsername", userNameParameter);
        }
    
        public virtual ObjectResult<GetUsersSP_Result> GetUsersSP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUsersSP_Result>("GetUsersSP");
        }
    
        public virtual ObjectResult<Nullable<decimal>> usp_AddOrUpdateExpense(Nullable<int> expenseId, Nullable<System.DateTime> expenseDate, string amount, string description, Nullable<int> categoryId, Nullable<int> statusId, Nullable<int> paymentMethodId, string createdBy, string updatedBy, string photo)
        {
            var expenseIdParameter = expenseId.HasValue ?
                new ObjectParameter("ExpenseId", expenseId) :
                new ObjectParameter("ExpenseId", typeof(int));
    
            var expenseDateParameter = expenseDate.HasValue ?
                new ObjectParameter("ExpenseDate", expenseDate) :
                new ObjectParameter("ExpenseDate", typeof(System.DateTime));
    
            var amountParameter = amount != null ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            var statusIdParameter = statusId.HasValue ?
                new ObjectParameter("StatusId", statusId) :
                new ObjectParameter("StatusId", typeof(int));
    
            var paymentMethodIdParameter = paymentMethodId.HasValue ?
                new ObjectParameter("PaymentMethodId", paymentMethodId) :
                new ObjectParameter("PaymentMethodId", typeof(int));
    
            var createdByParameter = createdBy != null ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(string));
    
            var updatedByParameter = updatedBy != null ?
                new ObjectParameter("UpdatedBy", updatedBy) :
                new ObjectParameter("UpdatedBy", typeof(string));
    
            var photoParameter = photo != null ?
                new ObjectParameter("Photo", photo) :
                new ObjectParameter("Photo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("usp_AddOrUpdateExpense", expenseIdParameter, expenseDateParameter, amountParameter, descriptionParameter, categoryIdParameter, statusIdParameter, paymentMethodIdParameter, createdByParameter, updatedByParameter, photoParameter);
        }
    
        public virtual ObjectResult<GetDeposits_Result> GetDeposits()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDeposits_Result>("GetDeposits");
        }
    }
}
