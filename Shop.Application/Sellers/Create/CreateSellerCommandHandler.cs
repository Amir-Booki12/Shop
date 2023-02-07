using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Create
{
    internal class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ISellerDomainService _sellerDomainService;

        public CreateSellerCommandHandler(ISellerRepository sellerRepository, ISellerDomainService sellerDomainService)
        {
            _sellerRepository = sellerRepository;
            _sellerDomainService = sellerDomainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode,_sellerDomainService);

            _sellerRepository.Add(seller);
            await _sellerRepository.Save();
            return OperationResult.Success();

        }
    }
}
