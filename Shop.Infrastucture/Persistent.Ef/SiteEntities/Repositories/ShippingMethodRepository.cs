using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastucture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.SiteEntities.Repositories
{
    internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
    {
        public ShippingMethodRepository(ShopContext context) : base(context)
        {
        }
    }
}
