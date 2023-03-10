using Common.Query;
using Shop.Query.SiteEntiteis.Banners.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntiteis.Banners.GetById
{
    public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;
}
