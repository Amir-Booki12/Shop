using Commom.Domain;
using System.Diagnostics;

namespace Shop.Domain.SellerAgg
{
    public class SellerInvertory:BaseEntity
    {
        public SellerInvertory(long productId, int price, int count, int? discountPersentAge)
        {
            if (Price < 1 || Count < 0)
                throw new InvalidDataException();

            ProductId = productId;
            Price = price;
            Count = count;
            DiscountPersentAge = discountPersentAge;
        }

        public long SellerId { get;private set; }
        public long ProductId { get;private set; }
        public int Price { get;private set; }
        public int Count { get;private set; }
        public int? DiscountPersentAge { get; set; }


        public void Edit(int price, int count, int? discountPersentAge)
        {
            Price = price;
            Count = count;
            DiscountPersentAge = discountPersentAge;
        }
    }
   
}
