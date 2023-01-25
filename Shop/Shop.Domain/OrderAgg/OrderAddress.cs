using Commom.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress: BaseEntity
    {
        public OrderAddress(string city,string shire, string postalCode, string postAddress, string nationalCode, string name, string family, string phoneNumber)
        {
            City = city;
            Shire = shire;
            PostalCode = postalCode;
            PostAddress = postAddress;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
        }

        public long OrderId { get; set; }
        public string City { get; private set; }
        public string Shire { get; private set; }
        public string PostalCode { get; private set; }
        public string PostAddress { get; private set; }
        public string NationalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public Order Order { get; private set; }
    }
}
