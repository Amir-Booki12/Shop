using Commom.Domain;
using Commom.Domain.Exceptions;
using Commom.Domain.ValueObjects;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string name, string family, string password, string email, PhoneNumber phoneNumber, Gender gender,IDomainUserService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            Family = family;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            AvatarName = "avatar.png";
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get; private set; }
        public string Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserRole> UserRoles { get; private set; }

        public void Edit(string name, string family, string email, PhoneNumber phoneNumber,
            Gender gender, IDomainUserService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            Family = family;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            
        }
        public void SetAvatatImage(string avatarName)
        {
            if (string.IsNullOrEmpty(avatarName))
                AvatarName = "avatar.png";
            AvatarName = avatarName;
        }
        public void SetRoles(List<UserRole> roles)
        {
            UserRoles.ForEach(r =>r.UserId=Id); 
            UserRoles.Clear();
            UserRoles.AddRange(roles);
        }

        public void AddAdress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void EditAdress(UserAddress address,long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Addres is not found");

            oldAddress.Edit(address.Shire, address.City, address.PostalCode, address.PostAdress,
                address.NationalCode, address.Name, address.Family, address.PhoneNumber);
        }
        public void DeleteAdress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Addres is not found");
            Addresses.Remove(oldAddress);
        }
        public void ShargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public static User Register(PhoneNumber phoneNumber,string password,IDomainUserService domainService)
        {
            return new User("","", password, "", phoneNumber,Gender.None, domainService);
        }

        public void Guard(string email, PhoneNumber phoneNumber, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            
            if(phoneNumber==null)
                throw new InvalidDomainDataException("شماره موبایل معتبر نیست");

            if (EmailValidation.IsValidEmail(email) == false)
                throw new InvalidDomainDataException("ایمیل معتبر نیست");

            if (Email != email)
                if (domainService.IsExistEmail(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");

            
        }
    }
}


