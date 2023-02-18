using Commom.Domain.Repository;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastucture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastucture.Persistent.Ef.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }
    }
}
