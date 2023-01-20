using Commom.Domain;

namespace Shop.Domain.SellerAgg
{
    public class SellerInvertory:BaseEntity
    {
        public SellerInvertory(long productId, int price, int count)
        {
            if (Price < 1 || Count < 0)
                throw new InvalidDataException();

            ProductId = productId;
            Price = price;
            Count = count;
        }

        public long SellerId { get;internal set; }
        public long ProductId { get;internal set; }
        public int Price { get;private set; }
        public int Count { get;private set; }
    }
}
