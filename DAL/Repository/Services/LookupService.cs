using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class LookupService :ILookup
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<SP_GetLookUpDropdowns_Result> SP_GetLookUpDropdowns(string name)
        {
            var lookup=context.SP_GetLookUpDropdowns(name).ToList();
            return lookup;
        }

        public List<SP_GetLookupwithDetails_Result> SP_GetLookupwithDetails(bool pIsActive)
        {
            var lookup = context.SP_GetLookupwithDetails(pIsActive).ToList();
            return lookup;
        }

    }
}
