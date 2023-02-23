using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntiteis.Sliders.DTOs
{
    public class SliderDto:BaseDto
    {
        public string Title { get;  set; }
        public string Link { get;  set; }
        public string ImageName { get;  set; }
    }
}
