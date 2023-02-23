using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Query.SiteEntiteis.Sliders.DTOs;

namespace Shop.Query.SiteEntiteis.Sliders.GetById
{
    internal class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private readonly ShopContext _context;

        public GetSliderByIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == request.SilderId);
            if (slider == null)
                return null;
            return new SliderDto()
            {
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title,
                CreationDate = slider.CreationDate,
                Id = slider.Id

            };
        }
    }
}
