using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shop.Domain.SiteEntities.Banner;

namespace Shop.Query.SiteEntiteis.Banners.DTOs
{
    public class BannerDto:BaseDto
    {
        public string Link { get;  set; }
        public string ImageName { get;  set; }
        public BannerPosition Position { get;  set; }
    }
}
