using DAL.Expense.edmx;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUser
    {
        List<GetUsersSP_Result> GetUsers();

        ValueDataResponse<User> CreateUser(User user);
    }
}
