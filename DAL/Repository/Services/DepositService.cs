using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class DepositService : IDeposit

    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<GetDeposits1_Result> GetDeposits1()
        {
            var expenses = context.GetDeposits1().ToList();
            return expenses;
        }
    }
}
