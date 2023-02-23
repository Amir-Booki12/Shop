using Common.Query;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Roles.DTOs
{
    public class RoleDto:BaseDto
    {
        public string RoleTitle { get;  set; }
        public List<PermissionType> Permissions { get;  set; }
    }
}
