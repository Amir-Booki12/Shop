using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using System.Runtime.Intrinsics.Arm;

namespace Shop.Application.Users.Register
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IDomainUserService _domainUserService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IDomainUserService domainUserService)
        {
            _userRepository = userRepository;
            _domainUserService = domainUserService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Register(request.PhoneNumber,Sha256Hasher.Hash(request.Password), _domainUserService);
            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();
            
        }
    }
}
