
using Commom.Domain.ValueObjects;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users
{
    public class UserDomainService : IDomainUserService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsExistEmail(string email)
        {
            return _repository.Exists(e => e.Email == email);
        }

        public bool IsExistPhoneNumber(string phoneNumber)
        {
            return _repository.Exists(e => e.PhoneNumber == phoneNumber);
        }
    }
}
