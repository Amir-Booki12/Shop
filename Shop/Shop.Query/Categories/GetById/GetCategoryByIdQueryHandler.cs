using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastucture.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById
{
    internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ShopContext _shopContex;

        public GetCategoryByIdQueryHandler(ShopContext shopContex)
        {
            _shopContex = shopContex;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _shopContex.Categories
                .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);

            return result.Map();
        }
    }
}
