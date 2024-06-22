using DAL.Expense.edmx;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Services
{
    public class UserRepositoryServices : IUser
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();


        public List<GetUsersSP_Result> GetUsers()
        {
            var res = context.GetUsersSP().ToList();
            return res;
        }

        public ValueDataResponse<User> CreateUser(User user)
        {
            ValueDataResponse<User> response = new ValueDataResponse<User>();

            try
            {
                var existingUser = context.Users.FirstOrDefault(s => s.Id == user.Id);
                if (existingUser == null)
                {
                    var newUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EMail = user.EMail,
                        MobileNumber = user.MobileNumber,
                        UserName = user.UserName,
                        Password = user.Password, // Note: Handle password securely (not shown here)
                        IsActive = user.IsActive,
                        CreatedAt = user.CreatedAt,
                        CreatedBy = user.CreatedBy,
                        UpdatedAt = user.UpdatedAt,
                        UpdatedBy = user.UpdatedBy,
                        DOB = user.DOB
                    };

                    context.Users.Add(newUser);

                    foreach (var userRole in user.UserRoles)
                    {
                        var newUserRole = new UserRole
                        {
                            UserId = newUser.Id,
                            RoleId = userRole.RoleId,
                            CreatedAt = userRole.CreatedAt,
                            UpdatedAt = userRole.UpdatedAt
                        };
                        context.UserRoles.Add(newUserRole);
                    }

                    context.SaveChanges(); 

                    response.IsSuccess = true;
                    response.EndUserMessage = "User added successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.EndUserMessage = "User already exists";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = $"An error occurred while creating the user: {ex.Message}";
            }

            return response;
        }




    }
}
