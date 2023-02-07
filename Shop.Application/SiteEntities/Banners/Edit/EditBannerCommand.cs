using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shop.Domain.SiteEntities.Banner;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommand:IBaseCommand
    {
        public EditBannerCommand(long bannerId, string link, IFormFile? imageFile, BannerPosition position)
        {
            BannerId = bannerId;
            Link = link;
            ImageFile = imageFile;
            Position = position;
        }

        public long BannerId { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
