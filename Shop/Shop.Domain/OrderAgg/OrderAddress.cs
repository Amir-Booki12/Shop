using Commom.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress: BaseEntity
    {
        public OrderAddress(string city, string postalCode, string postAdress, string nationalCode, string name, string family, string phoneNumber)
        {
            City = city;
            PostalCode = postalCode;
            PostAdress = postAdress;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
        }

        public long OrderId { get; set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostAdress { get; private set; }
        public string NationalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public Order Order { get; private set; }
    }
}
