using DAL.Expense.edmx;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class RoleService: IRoles
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<Role> GetRoles()
        {
           var rse=context.Roles.ToList();
            return rse;
        }
    }
}
