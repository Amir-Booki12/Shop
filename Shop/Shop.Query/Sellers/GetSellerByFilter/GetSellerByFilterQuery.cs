using Common.Query;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetSellerByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParam>
    {
        public GetSellerByFilterQuery(SellerFilterParam filterParams) : base(filterParams)
        {
        }
    }
}
