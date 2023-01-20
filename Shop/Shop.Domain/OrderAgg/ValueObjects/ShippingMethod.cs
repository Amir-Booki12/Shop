using Commom.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod:ValueObject
    {
        public ShippingMethod(string shppingType, int shppingPrice)
        {
            ShppingType = shppingType;
            ShppingPrice = shppingPrice;
        }

        public string ShppingType { get; private set; }
        public int ShppingPrice { get; private set; }
    }
}
