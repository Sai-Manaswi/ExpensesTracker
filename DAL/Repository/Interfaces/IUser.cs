using DAL.ExpenseModel;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Responses.RequestResModel;

namespace DAL.Repository.Interfaces
{
    public interface IUser
    {
        List<GetUsersSP_Result> GetUsers();

        ValueDataResponse<UserReq> CreateUser(UserReq user);

        ValueDataResponse<User> Deleteuser(int id);




    }
}
