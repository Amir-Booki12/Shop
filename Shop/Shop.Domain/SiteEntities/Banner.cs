using Commom.Domain;
using Commom.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Domain.SiteEntities
{
    public partial class Banner:BaseEntity
    {
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public BannerPosition Position { get; private set; }

        public Banner(string link, string imageName, BannerPosition position)
        {
            Guord(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }
        public void Edit(string link, string imageName, BannerPosition position)
        {
            Guord(link,imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Guord(string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        }
    }
}
