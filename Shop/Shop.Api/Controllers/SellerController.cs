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
using Shop.Api.Infrastructure.Security;
using Shop.Domain.RoleAgg.Enums;

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

        [PermissionChecker(PermissionType.Seller_Management)]
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


        [PermissionChecker(PermissionType.Seller_Management)]
        [HttpPost]

        public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
        {
            var result = await _sellerFacade.CreateSeller(command);
            return CommandResult(result);
        }

        [PermissionChecker(PermissionType.Seller_Management)]
        [HttpPut]


        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            var result = await _sellerFacade.EditSeller(command);
            return CommandResult(result);
        }

        [PermissionChecker(PermissionType.Add_Inventory)]
        [HttpPost("Inventory")]

        public async Task<ApiResult> AddInventory(AddInvertoryCommand command)
        {
            var result = await _sellerInventoryFacade.AddInventory(command);
            return CommandResult(result);
        }

        [PermissionChecker(PermissionType.Edit_Inventory)]
        [HttpPut("Inventory")]

        public async Task<ApiResult> EditInventory(EditInvertoryCommand command)
        {
            var result = await _sellerInventoryFacade.EditInventory(command);
            return CommandResult(result);
        }



    }
}
