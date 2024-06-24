using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
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
        ExpensesTrackerEntities context = new ExpensesTrackerEntities();

        public List<GetDeposits_Result> GetDeposits()
        {
            var deposit = context.GetDeposits().ToList();
            return deposit;
        }
    }
}
