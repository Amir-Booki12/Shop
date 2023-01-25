using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISellerRepository _sellerRepository;

        public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
        {
            _orderRepository = orderRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var invertory = await _sellerRepository.GetInvertoryResultById(request.InvertoryId);
            if (invertory == null)
                return OperationResult.NotFound();

            if (invertory.Count < request.Count)
                return OperationResult.Error("تعداد کالای درخواستی بیشتر از کالای موجود است");

            var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (order == null)
                order = new Order(request.UserId);

            order.AddItem(new OrderItem(request.InvertoryId, invertory.Price, invertory.Count));


            if (ItemCountBeggerThanInventoryCount(invertory, order))
                return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");
            await _orderRepository.Save();
            return OperationResult.Success();
        }
        private bool ItemCountBeggerThanInventoryCount(InvertoryResult inventory, Order order)
        {
            var orderItem = order.Items.First(f => f.InvertoryId == inventory.Id);
            if (orderItem.Count > inventory.Count)
                return true;

            return false;
        }
    }
   
}
