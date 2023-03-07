using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Common.Query.Filter;

namespace Shop.Query.Sellers.DTOs
{
    public class SellerDto:BaseDto
    {
        public long UserId { get;  set; }
        public string ShopName { get;  set; }
        public string NationalCode { get;  set; }     
        public SellerStatus Status { get;  set; }
    }
    public class SellerFilterParam:BaseFilterParam
    {
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
    }
    public class SellerFilterResult:BaseFilter<SellerDto,SellerFilterParam>
    {

    }
}
