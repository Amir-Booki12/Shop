using Commom.Domain;
using Commom.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        private Seller()
        {

        }
        public Seller(long userId, string shopName, string nationalCode)
        {
            Guord(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public long UserId { get; internal set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInvertory> Invertories { get; private set; }
        public SellerStatus Status { get; private set; }

        public void ChengeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void Edit(string shopName, string nationalCode)
        {
            Guord(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
        }

        public void AddInvertory(SellerInvertory invertoriy)
        {
            if (Invertories.Any(f => f.ProductId == invertoriy.ProductId))
                throw new InvalidDomainDataException();
            Invertories.Add(invertoriy);
        }
        public void EditInvertory(SellerInvertory invertoriy)
        {
            var oldInvertory = Invertories.FirstOrDefault(f=>f.Id==invertoriy.Id);
            if(oldInvertory==null)
                throw new InvalidDomainDataException("محصول یافت نشد");

            Invertories.Remove(oldInvertory);
            Invertories.Add(invertoriy);
        }

        public void RemoveInvertory(long invertoriyId)
        {
            var oldInvertory = Invertories.FirstOrDefault(f => f.Id == invertoriyId);
            if (oldInvertory == null)
                throw new InvalidDomainDataException("محصول یافت نشد");
            Invertories.Remove(oldInvertory);
        }
            public void Guord(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (!IranianNationalIdChecker.IsValid(nationalCode))
                throw new InvalidDomainDataException("کد ملی  معتبر نیست");
        }
    }
}
