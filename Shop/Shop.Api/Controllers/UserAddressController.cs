using AutoMapper;

using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddUserAddress;
using Shop.Application.Users.DeleteUserAddress;
using Shop.Application.Users.EditUserAddress;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddress;
        private readonly IMapper _mapper;
        public UserAddressController(IUserAddressFacade userAddress, IMapper mapper)
        {
            _userAddress = userAddress;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ApiResult<List<AddressDto>>> GetList()
        {
            var result = await _userAddress.GetList(User.GetUserId());
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<AddressDto?>> GetById(long id)
        {
            var result = await _userAddress.GetById(id);
            return QueryResult(result);
        }
        [HttpPost]
        public async Task<ApiResult> AddAddress(AddUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<AddAddressUserCommand>(viewModel);
            var result = await _userAddress.AddAddress(command);
            return CommandResult(result);
        }

        [HttpDelete("{addressId}")]
        public async Task<ApiResult> Delete(long addressId)
        {
            var result = await _userAddress.DeleteAddress(new DeleteUserAddressCommand(User.GetUserId(), addressId));
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<EditAddressUserCommand>(viewModel);
            var result = await _userAddress.EditAddress(command);
            return CommandResult(result);
        }
       
      
    }
}
