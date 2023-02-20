using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.AddUserAddress
{
    internal class AddAddressUserCommandHandler : IBaseCommandHandler<AddAddressUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddAddressUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(AddAddressUserCommand request, CancellationToken cancellationToken)
        {
            var user =await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var address = new UserAddress(request.Shire, request.City, request.PostalCode,
                request.PostAdress, request.NationalCode, request.Name, request.Family, request.PhoneNumber);

            user.AddAdress(address);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
