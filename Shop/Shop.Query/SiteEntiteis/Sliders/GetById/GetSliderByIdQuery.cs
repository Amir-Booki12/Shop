using Common.Query;
using Shop.Query.SiteEntiteis.Sliders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.SiteEntiteis.Sliders.GetById
{
    public record GetSliderByIdQuery(long SilderId) : IQuery<SliderDto>;
}
