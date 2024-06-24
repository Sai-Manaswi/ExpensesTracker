using DAL.Expense.edmx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Responses
{
    public class RequestResModel
    {

        public class UserReq : User
        {
            public List<UserRole> UserRolesReq { get; set; }
        }

        public class RoleReq : Role
        {
            public List<RolePermission> RolePermissionsReq { get; set; }
        }
    }
}
