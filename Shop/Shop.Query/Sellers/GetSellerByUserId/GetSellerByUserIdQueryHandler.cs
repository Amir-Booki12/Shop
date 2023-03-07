using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetSellerByUserId
{
    public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
    {
        private readonly ShopContext _context;

        public GetSellerByUserIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.UserId == request.UserId,
                cancellationToken: cancellationToken);
            return new SellerDto()
            {
                Id = seller.Id,
                CreationDate = seller.CreationDate,
                NationalCode = seller.NationalCode,
                ShopName = seller.ShopName,
                Status = seller.Status,
                UserId = seller.UserId
            };
        }
    }
}