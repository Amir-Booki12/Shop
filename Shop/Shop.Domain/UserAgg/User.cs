using Commom.Domain;
using Commom.Domain.Exceptions;
using Commom.Domain.ValueObjects;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User()
        {

        }
        public User(string name, string family, string password, string email, string phoneNumber, Gender gender,IDomainUserService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            Family = family;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            AvatarName = "avatar.png";
            IsActive = true;
            Addresses = new();
            Wallets = new();
            Tokens = new();

        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get; private set; }
        public bool IsActive { get; private set; }
        public string Email { get; private set; }
        [NotMapped]
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserRole> UserRoles { get; private set; }
        public List<UserToken> Tokens { get; private set; }

        public void Edit(string name, string family, string email, string phoneNumber,
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

        public static User Register(string phoneNumber,string password,IDomainUserService domainService)
        {
            return new User("","", password, "", phoneNumber,Gender.None, domainService);
        }

        public void AddToken(string hashJwtToken, string hashJwtRefreshToken,
            DateTime expireDateToken, DateTime expireDateRefreshToken, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.ExpireDateRefreshToken > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه وجود ندارد");
            var userToken = new UserToken(hashJwtToken, hashJwtRefreshToken, expireDateToken, expireDateRefreshToken, device);
            userToken.UserId = Id;
            Tokens.Add(userToken);
        }
        public void Guard(string email, string phoneNumber, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));



            if (EmailValidation.IsValidEmail(email) == false)
                throw new InvalidDomainDataException("ایمیل معتبر نیست");

            if (Email != email)
                if (domainService.IsExistEmail(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");

            
        }
    }
}


