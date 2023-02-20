using Common.Application;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderCountCommandHandler : IBaseCommandHandler<IncreaseOrderCountCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public IncreaseOrderCountCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(IncreaseOrderCountCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            currentOrder.IncreaseItemCount(request.Count,request.ItemId);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }


}
