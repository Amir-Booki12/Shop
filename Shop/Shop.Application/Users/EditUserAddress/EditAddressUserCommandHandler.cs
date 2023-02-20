using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditUserAddress
{
    internal class EditAddressUserCommandHandler : IBaseCommandHandler<EditAddressUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditAddressUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(EditAddressUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Shire, request.City, request.PostalCode,
                request.PostAdress, request.NationalCode, request.Name, request.Family, request.PhoneNumber);
            user.EditAdress(address,request.AddresId);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
