using Common.Query;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.GetForShop
{

    public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParam>
    {
        public GetProductsForShopQuery(ProductShopFilterParam filterParams) : base(filterParams)
        {
        }
    }
}
