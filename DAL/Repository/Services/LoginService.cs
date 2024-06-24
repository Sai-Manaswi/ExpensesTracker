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
        ExpensesTrackerEntities context = new ExpensesTrackerEntities();

        public bool ValidateUser(string UserName, string Password)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            return user != null;
        }
    }
}
