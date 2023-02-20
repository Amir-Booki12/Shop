using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastucture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }

        public Task<Order> GetCurrentUserOrder(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
