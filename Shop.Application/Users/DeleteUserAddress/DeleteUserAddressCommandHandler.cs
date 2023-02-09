using Common.Application;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.DeleteUserAddress
{
    internal class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.DeleteAdress(request.AddressId);

            await _userRepository.Save();
            return OperationResult.Success();

        }
    }

   
}
