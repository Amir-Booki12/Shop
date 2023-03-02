using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Presentation.Facade.SiteEntiteis.Banners;
using Shop.Query.SiteEntiteis.Banners.DTOs;

namespace Shop.Api.Controllers
{
   
   
        public class BannerController : ApiController
        {
            private readonly IBannerFacade _facade;


            public BannerController(IBannerFacade facade)
            {
                _facade = facade;
            }

            
            [HttpGet]
            public async Task<ApiResult<List<BannerDto>>> GetList()
            {
                var result = await _facade.GetBanners();
                return QueryResult(result);
            }

            [HttpGet("{id}")]
            public async Task<ApiResult<BannerDto?>> GetById(long id)
            {
                var result = await _facade.GetBannerById(id);
                return QueryResult(result);
            }

            [HttpPost]
            public async Task<ApiResult> Create([FromForm] CreateBannerCommand command)
            {
                var result = await _facade.CreateBanner(command);
                return CommandResult(result);
            }
            [HttpPut]
            public async Task<ApiResult> Edit([FromForm] EditBannerCommand command)
            {
                var result = await _facade.EditBanner(command);
                return CommandResult(result);
            }

            [HttpDelete("{bannerId}")]
            public async Task<ApiResult> Delete(long bannerId)
            {
                var result = await _facade.DeleteBanner(bannerId);
                return CommandResult(result);
            }
        }
    }

