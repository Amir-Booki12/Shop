using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;
        public bool CheckSellerInfo(Seller seller)
        {
            var ExistsSeller = _repository.Exists(s => s.NationalCode == seller.NationalCode ||
            s.UserId == seller.UserId);
            return !ExistsSeller;
        }

        public bool NationalCodeExistInDataBase(string nationalCode)
        {
            return _repository.Exists(s => s.NationalCode == nationalCode);
        }
    }
}
