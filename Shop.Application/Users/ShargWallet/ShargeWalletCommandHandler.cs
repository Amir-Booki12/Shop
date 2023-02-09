using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.ShargWallet
{
    internal class ShargeWalletCommandHandler : IBaseCommandHandler<ShargeWalletCommand>
    {
        private readonly IUserRepository _userRepository;

        public ShargeWalletCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(ShargeWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);

            user.ShargeWallet(wallet);
            await _userRepository.Save();
            return OperationResult.Success();

        }
    }
}
