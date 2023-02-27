using Commom.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    public interface IDomainUserService
    {
        bool IsExistEmail(string email);
        bool IsExistPhoneNumber(PhoneNumber phoneNumber);
    }
}
