using Commom.Domain;
using Commom.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.RoleAgg
{
    public class Role:AggregateRoot
    {
        public Role(string roleTitle)

        {
            RoleTitle = roleTitle;
        }

        public Role(string roleTitle, List<RolePermission> permissions)
        {
            NullOrEmptyDomainDataException.CheckString(roleTitle, nameof(roleTitle));
            RoleTitle = roleTitle;
            this.Permissions = permissions;
        }

        private Role()
        {

        }
       
        public string RoleTitle { get;private set; }
        public List<RolePermission> Permissions { get;private set; }

        public void Edit(string roleTitle)
        {
            NullOrEmptyDomainDataException.CheckString(roleTitle,nameof(roleTitle));
            RoleTitle = roleTitle;
        }

        public void SetPermisstion(List<RolePermission> permissions)
        {
            Permissions = permissions;
        }
    }
}
