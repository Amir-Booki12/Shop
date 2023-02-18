using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastucture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.RoleAgg
{
    internal class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ShopContext context) : base(context)
        {
        }
    }
}
