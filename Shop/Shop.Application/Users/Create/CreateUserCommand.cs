using Commom.Domain.ValueObjects;
using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommand:IBaseCommand
    {
        public CreateUserCommand(string name, string family, string password, string email, string phoneNumber, Gender gender)
        {
            Name = name;
            Family = family;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Gender Gender { get; private set; }
    }
}
