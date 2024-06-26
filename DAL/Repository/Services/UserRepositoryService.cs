using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using static DAL.Responses.RequestResModel;

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
        public ValueDataResponse<UserReq> CreateUser(UserReq user)
        {
            ValueDataResponse<UserReq> response = new ValueDataResponse<UserReq>();

            try
            {
               
                var existingUser = context.Users.FirstOrDefault(s => s.Id == user.Id);

                if (existingUser == null)
                {
                    var existingMobileNumber = context.Users.FirstOrDefault(c => c.MobileNumber == user.MobileNumber);
                    if (existingMobileNumber != null)
                    {
                        response.IsSuccess = false;
                        response.EndUserMessage = "Contact number has already existed for another candidate.";
                        return response;
                    }

                    var existingEmail = context.Users.FirstOrDefault(c => c.EMail == user.EMail);

                    if (existingEmail != null)
                    {
                        response.IsSuccess = false;
                        response.EndUserMessage = "Email address has already existed for another candidate.";
                        return response;
                    }


                    var existingNumberEmail = context.Users.FirstOrDefault(c => c.MobileNumber == user.MobileNumber && c.EMail == user.EMail);

                    if (existingNumberEmail != null)
                    {
                        response.IsSuccess = false;
                        response.EndUserMessage = "Number and Email address has already existed for another candidate.";
                        return response;
                    }
                    // Creating a new user
                    var newUser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EMail = user.EMail,
                        MobileNumber = user.MobileNumber,
                        UserName = user.UserName,
                        Password = user.Password,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = user.CreatedBy,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = user.UpdatedBy,
                        DOB = user.DOB
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges(); // Save changes after adding the new user

                    user.Id = newUser.Id; // Update user Id after saving changes

                    // Add or update UserRoles
                    if ( user.UserRolesReq.Count > 0)
                    {
                        foreach (var userRoleReq in user.UserRolesReq)
                        {
                            var userRole = new UserRole
                            {
                                UserId = newUser.Id, 
                                RoleId = userRoleReq.RoleId,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            };

                            context.UserRoles.Add(userRole);
                        }

                        context.SaveChanges(); // Save changes after adding all UserRoles
                        response.IsSuccess = true;
                        response.EndUserMessage = "User and UserRole(s) added successfully";
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.EndUserMessage = "Data failed to Add successfully";
                    }
                }
                else
                {
                    // Updating existing user
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.EMail = user.EMail;
                    existingUser.MobileNumber = user.MobileNumber;
                    existingUser.UserName = user.UserName;
                    existingUser.Password = user.Password;
                    //existingUser.IsActive = user.IsActive;
                    existingUser.CreatedAt = existingUser.CreatedAt;
                    existingUser.CreatedBy = user.CreatedBy;
                    existingUser.UpdatedAt = DateTime.Now;
                    existingUser.UpdatedBy = user.UpdatedBy;
                    existingUser.DOB = user.DOB;

                    context.SaveChanges(); // Save changes to update the existing user

                    // Add or update UserRoles
                    if (user.UserRolesReq != null && user.UserRolesReq.Count > 0)
                    {
                        foreach (var userRoleReq in user.UserRolesReq)
                        {
                            if (userRoleReq.Id > 0)
                            {
                                // Update existing UserRole
                                var existingUserRole = context.UserRoles.FirstOrDefault(ur => ur.Id == userRoleReq.Id);
                                if (existingUserRole != null)
                                {
                                    existingUserRole.RoleId = userRoleReq.RoleId;
                                    existingUserRole.CreatedAt = existingUserRole.CreatedAt;
                                    existingUserRole.UpdatedAt =DateTime.Now;
                                }
                            }
                          
                        }

                        context.SaveChanges(); // Save changes after all UserRole modifications
                        response.IsSuccess = true;
                        response.EndUserMessage = "User and UserRole(s) updated successfully";
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.EndUserMessage = "User updated successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = $"An error occurred while creating/updating the user: {ex.Message}";
            }


            return response;
        }




        public ValueDataResponse<User> Deleteuser(int id)

        {
            ValueDataResponse<User> response = new ValueDataResponse<User>();

            try
            {
                var res = context.Users.Where(s => s.Id == id).FirstOrDefault();

                if (res != null)
                {
                    res.IsActive = false;
                    res.UpdatedAt = DateTime.Now;

                    context.SaveChanges();

                    response.IsSuccess = true;
                    response.EndUserMessage = "Data deleted successfully";
                }
                else
                {

                    response.IsSuccess = false;
                    response.EndUserMessage = "User Not Found";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = "Data failed to delete:" + ex;
            }
            return response;
        }



    }
}
