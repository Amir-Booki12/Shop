using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public string City { get; private set; }
        public string Shire { get; private set; }
        public string PostalCode { get; private set; }
        public string PostAddress { get; private set; }
        public string NationalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }

        public CheckOutOrderCommand(long userId, string city, string shire, string postalCode, string postAddress,
           string nationalCode, string name, string family, string phoneNumber)
        {
            UserId = userId;
            City = city;
            Shire = shire;
            PostalCode = postalCode;
            PostAddress = postAddress;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
        }
    }
}
