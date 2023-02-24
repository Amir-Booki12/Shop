using Common.Application;
using Shop.Application.Users.AddUserAddress;
using Shop.Application.Users.DeleteUserAddress;
using Shop.Application.Users.EditUserAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddAddressUserCommand command);

        Task<OperationResult> EditAddress(EditAddressUserCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);
    }
}

