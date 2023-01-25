using Common.Application;
using FluentValidation;
using Shop.Domain.OrderAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(long UserId, int ItemId) : IBaseCommand;

    public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public RemoveOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.RemoveItem(request.ItemId);
            await _orderRepository.Save();
            return OperationResult.Success();

        }
    }

}
