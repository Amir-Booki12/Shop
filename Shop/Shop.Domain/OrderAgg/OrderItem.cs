using Commom.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem:BaseEntity
    {
        private OrderItem()
        {

        }
        public OrderItem(long invertoryId, int price, int count)
        {
            PriceGuord(price);
            CountGuord(Count);
            InvertoryId = invertoryId;
            Price = price;
            Count = count;
        }

        public long OrderId { get;internal set; }
        public long InvertoryId { get;private set; }
        public int Price { get;private set; }
        public int Count { get; private set; }
        public int TotalPrice => Price * Count;

        public void ChengePrice(int newPrice)
        {
            PriceGuord(newPrice);
            Price = newPrice;
        }
        public void IncreaseCount(int count)
        {
            Count += count;
        }
        public void DecreaseCount(int count)
        {
            if (count == 1 || Count - count <= 0)
                return;

            Count -= count;
        }
        public void ChengeCount(int newCount)
        {
            CountGuord(newCount);
            Count = newCount;
        }


        public void PriceGuord(int newPrice)
        {
            if (newPrice < 1)
                throw new InvalidDataException("مبلغ معتبر نیست");

        } 
        public void CountGuord(int newCount)
        {
            if (newCount < 1)
                throw new InvalidDataException("تعداد معتبر نیست");
        }
    }
}
