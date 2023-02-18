using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastucture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}
