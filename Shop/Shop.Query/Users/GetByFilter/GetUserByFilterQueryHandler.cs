using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByFilter
{
    public class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
    {

        private readonly ShopContext _context;

        public GetUserByFilterQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Users.OrderByDescending(s => s.Id).AsQueryable();
            var @params = request.FilterParams;

            if (!string.IsNullOrEmpty(@params.Email))
                result = result.Where(s => s.Email.Contains(@params.Email));
            if (@params.PhoneNumber != null)
                result = result.Where(s => s.PhoneNumber == @params.PhoneNumber);
            if (@params.Id != null)
                result = result.Where(s => s.Id == @params.Id);
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new UserFilterResult()
            {
                FilterParams = @params,
                Data = await result.Skip(skip).Take(@params.Take)
                .Select(s => s.MapFilter()).ToListAsync()
            };
            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
