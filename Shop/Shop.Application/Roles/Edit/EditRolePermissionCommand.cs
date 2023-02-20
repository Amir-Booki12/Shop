using Common.Application;
using Shop.Application.Roles.Create;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Edit
{
    public record EditRolePermissionCommand(long Id,string Title, List<PermissionType> Permissions) : IBaseCommand;
}
