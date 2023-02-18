using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastucture.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetAllCategory
{
    internal class GetListCategoryQueryHandler : IQueryHandler<GetListCategoryQuery, List<CategoryDto>>
    {
        private readonly ShopContext _shopContex;

        public GetListCategoryQueryHandler(ShopContext shopContex)
        {
            _shopContex = shopContex;
        }
        public async Task<List<CategoryDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _shopContex.Categories.OrderByDescending(o=>o.Id).ToListAsync(cancellationToken);
            return result.Map();
        }
    }
}
