using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.SiteEntiteis.Banners.DTOs;

namespace Shop.Query.SiteEntiteis.Banners.GetList
{
    internal class GetBannerBylistQueryHandler : IQueryHandler<GetBannerBylistQuery, List<BannerDto>>
    {
        private readonly ShopContext _context;

        public GetBannerBylistQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<BannerDto>> Handle(GetBannerBylistQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.Select(s => new BannerDto()
            {
                CreationDate = s.CreationDate,
                Id = s.Id,
                ImageName = s.ImageName,
                Link = s.Link,
                Position = s.Position
            }).ToListAsync();
        }
    }
}
