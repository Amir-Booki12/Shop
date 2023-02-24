﻿using Common.Application;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheckOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Orders
{
    public interface IOrderFacade
    {
        Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
        Task<OperationResult> OrderCheckOut(CheckOutOrderItemCommand command);
        Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
        Task<OperationResult> IncreaseItemCount(IncreaseOrderCountCommand command);
        Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);
       

        Task<OrderDto?> GetOrderById(long orderId);
        Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
        
    }
}
