using Commom.Domain;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    public class Order:AggregateRoot
    {
        private Order()
        {

        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItem>();
        }

        public long UserId { get;internal set; }
        public OrderStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public OrderAddress? Addresses { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public ShippingMethod? shippingMethod { get; private set; }
        public int? TotalCount => Items.Count();
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(s=>s.TotalPrice);
                if (shippingMethod != null)
                    totalPrice += shippingMethod.ShppingPrice;
                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }

        public void ChengeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(int itemId)
        {
            var order = Items.FirstOrDefault(i=>i.Id == itemId);
            if (order == null)
                throw new InvalidDataException();  
        }

        public void ChengeCountItem(int itemId,int newCount)
        {
            var order = Items.FirstOrDefault(i => i.Id == itemId);
            if (order == null)
                throw new InvalidDataException();

            order.ChengeCount(newCount);
        }

        public void CheckOut(OrderAddress address)
        {
            Addresses = address;
        }
    }
}
