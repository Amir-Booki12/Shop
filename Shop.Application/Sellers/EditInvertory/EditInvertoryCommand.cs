using Common.Application;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.EditInvertory
{
    public class EditInvertoryCommand:IBaseCommand
    {
        public EditInvertoryCommand(long sellerId, SellerStatus status, int price, int count, int? discountPersentAge)
        {
            SellerId = sellerId;
            Status = status;
            Price = price;
            Count = count;
            DiscountPersentAge = discountPersentAge;
        }

        public long SellerId { get; private set; }
        public long InventoryId { get; private set; }
        public SellerStatus Status { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public int? DiscountPersentAge { get; set; }
    }
}
