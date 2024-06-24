using DAL.Expense.edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IRoles
    {
        List<Role> GetRoles();
    }
}
