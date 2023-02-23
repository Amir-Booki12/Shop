using Common.Query;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.GetByFilter
{
    internal class GetByProductByFilterQueryHandler : IQueryHandler<GetByProductByFilterQuery, ProductFilterResult>
    {
        private readonly ShopContext _context;

        public GetByProductByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<ProductFilterResult> Handle(GetByProductByFilterQuery request, CancellationToken cancellationToken)
        {
            var result =_context.Products.OrderByDescending(s => s.Id).AsQueryable();
            var @params = request.FilterParams;

            if(@params.Title!=null)
                result=result.Where(s => s.Title.Contains(@params.Title));
            if (@params.Slug != null)
                result = result.Where(s => s.Slug == @params.Slug);

            if (@params.Id != null)
                result = result.Where(s => s.Id == @params.Id);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new ProductFilterResult()
            {
                FilterParams = @params,
                Data = result.Skip(skip).Take(@params.Take).Select(s => s.MapData()).ToList()
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
