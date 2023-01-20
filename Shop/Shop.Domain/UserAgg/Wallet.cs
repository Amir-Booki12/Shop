using Commom.Domain;
using Commom.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public Wallet(int price, string description, bool isActive, WalletType type, DateTime? finallyDate)
        {
            if (Price <500)
            {
                throw new InvalidDomainDataException();
            }
            Price = price;
            Description = description;
            IsActive = isActive;
            Type = type;
            FinallyDate = finallyDate;
        }

        public long UserId { get; internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
        public WalletType Type { get; private set; }
        public DateTime? FinallyDate { get; private set; }

        public void Finally(string refCode)
        {
            IsActive = true;
            FinallyDate = DateTime.Now;
            Description += $"کد پیگیری : {refCode}";
        }
        public void Finally()
        {
            IsActive = true;
            FinallyDate = DateTime.Now;
           
        }

    }
}
