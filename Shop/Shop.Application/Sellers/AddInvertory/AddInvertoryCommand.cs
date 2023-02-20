using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInvertory
{
    public class AddInvertoryCommand:IBaseCommand
    {
        public AddInvertoryCommand(long sellerId, long productId, int price, int count, int? discountPersentAge)
        {
            SellerId = sellerId;
            ProductId = productId;
            Price = price;
            Count = count;
            DiscountPersentAge = discountPersentAge;
        }

        public long SellerId { get; private set; }
        public long ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int? DiscountPersentAge { get; set; }
    }
}
