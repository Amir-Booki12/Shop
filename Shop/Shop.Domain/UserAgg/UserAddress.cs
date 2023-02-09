using Commom.Domain;
using Commom.Domain.Exceptions;
using Commom.Domain.ValueObjects;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(string shire, string city, string postalCode, string postAdress, string nationalCode, string name, string family, PhoneNumber phoneNumber)
        {
            Guord(shire, city, postalCode, postAdress,
                 nationalCode, name, family, phoneNumber);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostAdress = postAdress;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            AddressActive = false;
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
        public bool AddressActive { get; private set; }



        public void SetActive()
        {
            AddressActive = true;
        }
        public void Edit(string shire, string city, string postalCode, string postAdress,
            string nationalCode, string name, string family, PhoneNumber phoneNumber)
        {
            Guord(shire, city, postalCode, postAdress,
                 nationalCode, name, family, phoneNumber);


            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostAdress = postAdress;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
        }


        public void Guord(string shire, string city, string postalCode, string postAdress,
            string nationalCode, string name, string family, PhoneNumber phoneNumber)
        {
            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(postAdress, nameof(postAdress));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            

            if (!IranianNationalIdChecker.IsValid(nationalCode))
            {
                throw new InvalidDomainDataException("کد ملی نامعبر است");
            }
        }
    }
}

