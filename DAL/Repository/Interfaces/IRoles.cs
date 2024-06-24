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
    public interface IRoles
    {
        List<Role> GetRoles();

        List<GetRoles_Result> GetAllRolesSP();

        List<DropdownRoles_Result> DropdownRoles();




        //ValueDataResponse<Role> AddRoleWithPermissions(Role role, List<int> permissionIds);

        ValueDataResponse<RoleReq> AddUpdateRole(RoleReq role);


        
    }
}
