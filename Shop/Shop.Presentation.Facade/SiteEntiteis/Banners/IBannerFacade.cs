using Common.Application;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntiteis.Banners.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SiteEntiteis.Banners
{
    public interface IBannerFacade
    {
        Task<OperationResult> CreateBanner(CreateBannerCommand command);
        Task<OperationResult> EditBanner(EditBannerCommand command);
        
        Task<BannerDto?> GetBannerById(long id);
        Task<List<BannerDto>> GetBanners();
    }
}
