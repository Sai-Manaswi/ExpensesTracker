using DAL.ExpenseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DAL.Authentication
{
    public class UserRepository : IDisposable
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public User ValidateUser(string UserName, string Password)
        {
            return context.Users.FirstOrDefault(user =>
            user.UserName.Equals(UserName, StringComparison.OrdinalIgnoreCase)
            && user.Password == Password);
        }

        public List<string> GetUserPermissionsByUsername(string UserName)
        {
            var res = context.GetUserPermissionsByUsername(UserName).ToList();
            return res;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}


