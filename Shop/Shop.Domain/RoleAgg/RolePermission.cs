using Commom.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission:BaseEntity
    {
        public RolePermission(PermissionType permission)
        {
            Permission = permission;
        }

        public long RoleId { get;internal set; }
        public PermissionType Permission { get;private set; }

    }
}
