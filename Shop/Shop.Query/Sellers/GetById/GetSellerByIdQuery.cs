using Common.Query;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetById
{
    public class GetSellerByIdQuery : IQuery<SellerDto>
    {
        public GetSellerByIdQuery(long sellerId)
        {
            SellerId = sellerId;
        }

        public long SellerId { get; set; }
    }

}
