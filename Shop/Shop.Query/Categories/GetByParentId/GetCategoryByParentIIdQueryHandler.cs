using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastucture.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetCategoryByParentIIdQueryHandler : IQueryHandler<GetCategoryByParentIIdQuery,
       List<ChildCategoryDto>>
    {
        private readonly ShopContext _shopContex;

        public GetCategoryByParentIIdQueryHandler(ShopContext shopContex)
        {
            _shopContex = shopContex;
        }
        public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentIIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _shopContex.Categories
                .Where(c => c.ParentId == request.ParentId).ToListAsync(cancellationToken);
            return result.MapChildren();
        }
    }
}
