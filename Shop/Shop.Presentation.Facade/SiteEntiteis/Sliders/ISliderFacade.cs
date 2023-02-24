using Common.Application;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntiteis.Sliders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.SiteEntiteis.Sliders
{
    public interface ISliderFacade
    {
        Task<OperationResult> CreateSlider(CreateSliderCommand command);
        Task<OperationResult> EditSlider(EditSliderCommand command);


        Task<SliderDto?> GetSliderById(long id);
        Task<List<SliderDto>> GetSliders();
    }
}
