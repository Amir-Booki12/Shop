using Commom.Domain.Repository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> removeCategory(long CategoryId)
        {
            var category =await Context.Categories
                .Include(s=>s.Childs)
                .ThenInclude(s=>s.Childs)
                .FirstOrDefaultAsync(f => f.Id == CategoryId);
            if (category == null)
                return false;

            var isExistProduct = await Context.Products.AnyAsync(p => p.CategoryId == CategoryId||
            p.SubCategoryId==CategoryId||p.SecendrySubCategoryId==CategoryId);
            if (isExistProduct)
                return false;

            if (category.Childs.Any(s => s.Childs.Any()))
            {
                Context.RemoveRange(category.Childs.SelectMany(s => s.Childs));
            }
            Context.RemoveRange(category.Childs);
            Context.RemoveRange(category);
            Context.SaveChanges();
            return true;
        }
    }
}
