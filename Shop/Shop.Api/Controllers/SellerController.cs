using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Sellers.Inventoreis;
using Shop.Presentation.Facade.Sellers;
using Shop.Query.Sellers.DTOs;
using System.Security;
using Shop.Application.Sellers.AddInvertory;
using Shop.Application.Sellers.EditInvertory;

namespace Shop.Api.Controllers
{
    public class SellerController : ApiController
    {
        private readonly ISellerFacade _sellerFacade;
        private readonly ISellerInventoryFacade _sellerInventoryFacade;
        public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
        {
            _sellerFacade = sellerFacade;
            _sellerInventoryFacade = sellerInventoryFacade;
        }

        [HttpGet]
        
        public async Task<ApiResult<SellerFilterResult>> GetSellers(SellerFilterParam filterParams)
        {
            var result = await _sellerFacade.GetSellersByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SellerDto?>> GetSellerById(long sellerId)
        {
            var result = await _sellerFacade.GetSellerById(sellerId);
            return QueryResult(result);
        }

       

        [HttpPost]
        
        public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
        {
            var result = await _sellerFacade.CreateSeller(command);
            return CommandResult(result);
        }

        [HttpPut]
        

        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            var result = await _sellerFacade.EditSeller(command);
            return CommandResult(result);
        }

        [HttpPost("Inventory")]
        
        public async Task<ApiResult> AddInventory(AddInvertoryCommand command)
        {
            var result = await _sellerInventoryFacade.AddInventory(command);
            return CommandResult(result);
        }
        [HttpPut("Inventory")]
        
        public async Task<ApiResult> EditInventory(EditInvertoryCommand command)
        {
            var result = await _sellerInventoryFacade.EditInventory(command);
            return CommandResult(result);
        }

       

    }
}
