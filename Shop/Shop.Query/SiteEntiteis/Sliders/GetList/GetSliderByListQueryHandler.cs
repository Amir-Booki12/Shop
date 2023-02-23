using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.SiteEntiteis.Sliders.DTOs;

namespace Shop.Query.SiteEntiteis.Sliders.GetList
{
    internal class GetSliderByListQueryHandler : IQueryHandler<GetSliderByListQuery, List<SliderDto>>
    {
        private readonly ShopContext _context;

        public GetSliderByListQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<SliderDto>> Handle(GetSliderByListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.Select(s => new SliderDto()
            {
                ImageName = s.ImageName,
                Link = s.Link,
                Title = s.Title,
                CreationDate = s.CreationDate,
                Id = s.Id
            }).ToListAsync();
        }
    }
}
