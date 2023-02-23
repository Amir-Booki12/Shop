using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById
{
    internal class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto>
    {
        private readonly ShopContext _context;

        public GetSellerByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SellerDto> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == request.SellerId);
            if (seller == null)
                return null;
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
