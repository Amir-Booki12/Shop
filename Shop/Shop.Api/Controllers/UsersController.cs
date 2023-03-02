using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using System.Security;

namespace Shop.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserFacade _userFacade;
        
        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
            
        }
        
        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
        {
            var result = await _userFacade.GetUserByFilter(filterParams);
            return QueryResult(result);
        }
        [HttpGet("Current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await _userFacade.GetUserById(User.GetUserId());
            return QueryResult(result);
        }

        
        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto?>> GetById(long userId)
        {
            var result = await _userFacade.GetUserById(userId);
            return QueryResult(result);
        }

        
        [HttpPost]
        public async Task<ApiResult> Create(CreateUserCommand command)
        {
            var result = await _userFacade.CreateUser(command);
            return CommandResult(result);
        }
        
        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
        {
            var result = await _userFacade.EditUser(command);
            return CommandResult(result);
        }
    }
}
