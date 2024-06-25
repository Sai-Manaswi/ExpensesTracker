using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class LoginService : ILogin
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public bool ValidateUser(string UserName, string Password)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            return user != null;
        }
    }
}
