using Common.Application;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.EditInvertory
{
    public class EditInvertoryCommandHandler : IBaseCommandHandler<EditInvertoryCommand>
    {
        private readonly ISellerRepository _sellerRepository;

        public EditInvertoryCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        public async Task<OperationResult> Handle(EditInvertoryCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();

            seller.EditInvertory(request.InventoryId, request.Price, request.Count, request.DiscountPersentAge);
            seller.ChengeStatus(request.Status);
            await _sellerRepository.Save();
            return OperationResult.Success();
        }
    }
}
