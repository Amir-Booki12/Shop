using Commom.Domain.ValueObjects;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.AddUserAddress
{
    public class AddAddressUserCommand:IBaseCommand
    {
        public AddAddressUserCommand(long userId, string shire, string city, string postalCode,
            string postAdress, string nationalCode, string name, string family, PhoneNumber phoneNumber)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostAdress = postAdress;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
        }

        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostAdress { get; private set; }
        public string NationalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

    }
}
