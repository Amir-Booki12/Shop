using Commom.Domain;
using Commom.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;
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
        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guord(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            if (domainService.CheckSellerInfo(this) == false)
                throw new InvalidDomainDataException("اطلاعات نامعتبر است");
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
        public void Edit(string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guord(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
            if (domainService.NationalCodeExistInDataBase(nationalCode))
                throw new NullOrEmptyDomainDataException("کد ملی مشخض به فرد دیگری استت");
         }

        public void AddInvertory(SellerInvertory invertoriy)
        {
            if (Invertories.Any(f => f.ProductId == invertoriy.ProductId))
                throw new InvalidDomainDataException();
            Invertories.Add(invertoriy);
        }
        public void EditInvertory(long invertoryId,int price,int count,int? discountParcentAge)
        {
            var oldInvertory = Invertories.FirstOrDefault(f => f.Id == invertoryId);
            if (oldInvertory == null)
                throw new InvalidDomainDataException("محصول یافت نشد");

            oldInvertory.Edit(price,count,discountParcentAge);
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
