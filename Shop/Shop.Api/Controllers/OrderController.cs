using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheckOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.RoleAgg.Enums;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Orders.DTOs;
using System.Security;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [PermissionChecker(PermissionType.Order_Management)]
        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
        {
            var result = await _orderFacade.GetOrdersByFilter(filterParams);
            return QueryResult(result);
        }

       

       

        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
        {
            var result = await _orderFacade.AddOrderItem(command);
            return CommandResult(result);
        }

        [HttpPost("Checkout")]
        public async Task<ApiResult> CheckoutOrder(CheckOutOrderCommand command)
        {
            var result = await _orderFacade.OrderCheckOut(command);
            return CommandResult(result);
        }

       

        [HttpPut("orderItem/IncreaseCount")]
        public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.IncreaseItemCount(command);
            return CommandResult(result);
        }
        [HttpPut("orderItem/DecreaseCount")]
        public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.DecreaseItemCount(command);
            return CommandResult(result);
        }

        [HttpDelete("orderItem/{itemId}")]
        public async Task<ApiResult> RemoveOrderItem(long itemId)
        {
            var result = await _orderFacade.RemoveOrderItem(new RemoveOrderItemCommand(User.GetUserId(), itemId));
            return CommandResult(result);
        }
    }
}
