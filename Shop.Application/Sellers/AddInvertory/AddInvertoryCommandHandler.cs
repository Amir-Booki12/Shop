using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Sellers.AddInvertory
{
    public class AddInvertoryCommandHandler : IBaseCommandHandler<AddInvertoryCommand>
    {
      private readonly  ISellerRepository _sellerRepository;

        public AddInvertoryCommandHandler(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult> Handle(AddInvertoryCommand request, CancellationToken cancellationToken)
        {
            var seller =await _sellerRepository.GetTracking(request.SellerId);
            if (seller == null)
                return OperationResult.NotFound();

            var invertory = new SellerInvertory(request.ProductId,request.Price,request.Count,request.DiscountPersentAge);

            seller.AddInvertory(invertory);
            await _sellerRepository.Save();
            return OperationResult.Success();
        }
    }
}
