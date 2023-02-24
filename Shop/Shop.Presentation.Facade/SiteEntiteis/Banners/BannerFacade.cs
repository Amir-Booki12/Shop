using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntiteis.Banners.DTOs;
using Shop.Query.SiteEntiteis.Banners.GetById;
using Shop.Query.SiteEntiteis.Banners.GetList;

namespace Shop.Presentation.Facade.SiteEntiteis.Banners
{
    internal class BannerFacade: IBannerFacade
    {
        private readonly IMediator _mediator;

        public BannerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
        {
            return await _mediator.Send(command);
        }
        public async Task<OperationResult> EditBanner(EditBannerCommand command)
        {
            return await _mediator.Send(command);
        }

       

        public async Task<BannerDto?> GetBannerById(long id)
        {
            return await _mediator.Send(new GetBannerByIdQuery(id));
        }

        public async Task<List<BannerDto>> GetBanners()
        {
            return await _mediator.Send(new GetBannerBylistQuery());

        }
    }
}
