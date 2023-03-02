using Commom.Domain.ValueObjects;
using Common.Application;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUser(RegisterUserCommand command);
        Task<OperationResult> EditUser(EditUserCommand command);
        Task<OperationResult> CreateUser(CreateUserCommand command);
        Task<OperationResult> AddToken(AddUserTokenCommand command);
      

        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
        Task<UserDto?> GetUserById(long userId);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
    }
}
