using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ShopContext _context;

        public GetUserByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            if (user == null)
                return null;

            return await user.Map().SetRoleTitles(_context);

        }
    }
}
