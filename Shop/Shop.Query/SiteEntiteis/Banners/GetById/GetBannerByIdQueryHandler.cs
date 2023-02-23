using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.SiteEntiteis.Banners.DTOs;

namespace Shop.Query.SiteEntiteis.Banners.GetById
{
    internal class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
    {
        private readonly ShopContext _context;

        public GetBannerByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.FirstOrDefaultAsync(s => s.Id == request.BannerId);
            if (banner == null)
                return null;

            return new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position
            };
        }
    }
}
