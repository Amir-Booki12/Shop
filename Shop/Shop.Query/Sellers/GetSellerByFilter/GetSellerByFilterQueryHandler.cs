using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetSellerByFilter
{
    internal class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
    {
        private readonly ShopContext _context;

        public GetSellerByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Sellers.OrderByDescending(s => s.Id).AsQueryable();
            var @param = request.FilterParams;

            if (param.ShopName != null)
                result = result.Where(s => s.ShopName.Contains(param.ShopName));

            if (param.NationalCode != null)
                result = result.Where(s => s.NationalCode.Contains(param.NationalCode));

            var skip = (param.PageId - 1) * param.Take;
            var model = new SellerFilterResult()
            {
                FilterParams = param,
                Data = await result.Skip(skip).Take(param.Take).Select(s => new SellerDto()
                {
                    Id = s.Id,
                    CreationDate =s.CreationDate,
                    NationalCode = s.NationalCode,
                    ShopName = s.ShopName,
                    Status = s.Status,
                    UserId = s.UserId,
                }).ToListAsync()
            };
            model.GeneratePaging(result, param.Take, param.PageId);
            return model;
        }
    }
}
