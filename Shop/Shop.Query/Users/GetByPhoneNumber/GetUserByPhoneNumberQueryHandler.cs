using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.GetByPhoneNumber
{
    internal class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto>
    {
        private readonly ShopContext _context;

        public GetUserByPhoneNumberQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<UserDto> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return null;

            return await user.Map().SetRoleTitles(_context);
        }
    }
}
