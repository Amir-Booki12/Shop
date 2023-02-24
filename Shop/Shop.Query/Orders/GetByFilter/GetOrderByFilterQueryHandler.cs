using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastucture.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
    {
        private readonly ShopContext _context;

        public GetOrderByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Orders.OrderByDescending(o => o.Id).AsQueryable();
            var @params = request.FilterParams;
            

            if (@params.Status != null)
                result = result.Where(r => r.Status == @params.Status);

            if (@params.UserId != null)
                result = result.Where(r => r.UserId == @params.UserId);

            if (@params.StartDate != null)
                result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

            if (@params.EndDate != null)
                result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new OrderFilterResult()
            {
                FilterParams = @params,
                Data = await result.Skip(skip).Take(@params.Take).Select(s => s.MapFilter(_context)).ToListAsync(cancellationToken)
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
