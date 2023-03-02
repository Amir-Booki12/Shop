using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckOutOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);

            if (currentOrder == null)
                return OperationResult.NotFound();

            var address = new OrderAddress(request.City, request.Shire, request.PostalCode, request.PostAddress,
                request.NationalCode, request.Name, request.Family, request.PhoneNumber);

            currentOrder.CheckOut(address);

            await _orderRepository.Save();

            return OperationResult.Success();


        }
    }
}
