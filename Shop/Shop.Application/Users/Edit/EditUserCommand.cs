using Commom.Domain.ValueObjects;
using Common.Application;
using Common.Application.Validation;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public EditUserCommand(long userId, string name, string family, string password,
            IFormFile? avatarFile, string email, string phoneNumber, Gender gender)
        {
            UserId = userId;
            Name = name;
            Family = family;
            Password = password;
            AvatarFile = avatarFile;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }

        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Password { get; private set; }
        public IFormFile? AvatarFile { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
    }
}
