using Common.Application;
using MediatR;
using Shop.Application.Users.AddUserAddress;
using Shop.Application.Users.DeleteUserAddress;
using Shop.Application.Users.EditUserAddress;

namespace Shop.Presentation.Facade.Users.Addresses
{
    internal class UserAddressFacade: IUserAddressFacade
    {

        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddAddress(AddAddressUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddress(EditAddressUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);

        }

       

       
    }
}

