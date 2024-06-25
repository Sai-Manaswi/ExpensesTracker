using DAL.ExpenseModel;
using DAL.Repository.Interfaces;
using DAL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Responses.RequestResModel;

namespace DAL.Repository.Services
{
    public class RoleRepository : IRoles
    {
        ExpensesTrackerEntities1 context = new ExpensesTrackerEntities1();

        public List<Role> GetRoles()
        {
            var rse = context.Roles.ToList();
            return rse;
        }



        public  List<GetRoles_Result> GetAllRolesSP()
        {
            var result = context.GetRoles().ToList();
            return result;
        }


        public List<DropdownRoles_Result> DropdownRoles()
        {
            var result = context.DropdownRoles().ToList();
            return result;
        }

        public ValueDataResponse<RoleReq> AddUpdateRole(RoleReq role)
        {
            ValueDataResponse<RoleReq> response = new ValueDataResponse<RoleReq>();

            try
            {
                var existingRole = context.Roles.FirstOrDefault(s => s.Id == role.Id);

                if (existingRole == null)
                {
                    // Creating a new role
                    var newRole = new Role
                    {
                        Name = role.Name,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = role.CreatedBy,
                        UpdatedAt = DateTime.Now, // UpdatedAt should be set to current time
                        UpdatedBy = role.UpdatedBy
                    };

                    context.Roles.Add(newRole);
                    context.SaveChanges();

                    role.Id = newRole.Id;

                    // Add RolePermissions for the new role
                    if (role.RolePermissionsReq != null && role.RolePermissionsReq.Count > 0)
                    {
                        foreach (var rolePermissionReq in role.RolePermissionsReq)
                        {
                            var rolePermission = new RolePermission
                            {
                                RoleId = newRole.Id,
                                PermissionId = rolePermissionReq.PermissionId,
                                CreatedAt = DateTime.Now, // Set to current time
                                UpdatedAt = DateTime.Now // Set to current time
                            };

                            context.RolePermissions.Add(rolePermission);
                        }

                        context.SaveChanges(); // Save changes after adding all RolePermissions
                        response.IsSuccess = true;
                        response.EndUserMessage = "Role and RolePermission(s) added successfully";
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.EndUserMessage = "Role added successfully, but no RolePermission(s) provided";
                    }
                }
                else
                {
                    // Updating existing role
                    existingRole.Name = role.Name;
                    existingRole.CreatedAt = role.CreatedAt;
                    existingRole.CreatedBy = role.CreatedBy;
                    existingRole.UpdatedAt = DateTime.Now; // UpdatedAt should be set to current time
                    existingRole.UpdatedBy = role.UpdatedBy;

                    context.SaveChanges();

                    if (role.RolePermissionsReq != null && role.RolePermissionsReq.Count > 0)
                    {
                        foreach (var rolePermissionReq in role.RolePermissionsReq)
                        {
                            if (rolePermissionReq.Id > 0)
                            {
                                // Update existing RolePermission
                                var existingRolePermission = context.RolePermissions.FirstOrDefault(rp => rp.Id == rolePermissionReq.Id);
                                if (existingRolePermission != null)
                                {

                                    existingRolePermission.PermissionId = rolePermissionReq.PermissionId;
                                    existingRolePermission.UpdatedAt = DateTime.Now;
                                }
                            }
                          
                        }

                        context.SaveChanges(); // Save changes after all RolePermission modifications
                        response.IsSuccess = true;
                        response.EndUserMessage = "Role and RolePermission(s) updated successfully";
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.EndUserMessage = "Role updated successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.EndUserMessage = $"An error occurred while creating/updating the role: {ex.Message}";
            }

            return response;
        }



    }
}
