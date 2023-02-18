using Common.Query;
using Shop.Query.Comments.DTOs;
using Shop.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrderByFilerQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrderByFilerQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
