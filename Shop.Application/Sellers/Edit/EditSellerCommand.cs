using Common.Application;
using Shop.Application.Sellers.Create;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Edit
{
    public record EditSellerCommand(long Id, string ShopName, string NationalCode) : IBaseCommand;

    internal class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ISellerDomainService _sellerDomainService;

        public EditSellerCommandHandler(ISellerRepository sellerRepository, ISellerDomainService sellerDomainService)
        {
            _sellerRepository = sellerRepository;
            _sellerDomainService = sellerDomainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _sellerDomainService);

            _sellerRepository.Add(seller);
            await _sellerRepository.Save();
            return OperationResult.Success();

        }
    }
}
