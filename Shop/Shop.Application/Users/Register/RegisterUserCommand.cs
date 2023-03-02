using Commom.Domain.ValueObjects;
using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Register
{
    public record RegisterUserCommand(string PhoneNumber,string Password):IBaseCommand;
}
