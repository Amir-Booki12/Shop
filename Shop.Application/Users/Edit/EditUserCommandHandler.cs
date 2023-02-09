using Common.Application;
using Common.Application.FileUtil.Interface;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit
{
    internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IDomainUserService _domainUserService;
        private readonly IFileService _fileService;

        public EditUserCommandHandler(IUserRepository userRepository, IDomainUserService domainUserService, IFileService fileService)
        {
            _userRepository = userRepository;
            _domainUserService = domainUserService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();
            user.Edit(request.Name, request.Family, request.Email, request.PhoneNumber, request.Gender, _domainUserService);
            var oldImage = user.AvatarName;
            if (request.AvatarFile != null)
            {
                var imgaeName = await _fileService.SaveFileAndGenerateName(request.AvatarFile, Directories.UserAvatar);
                user.SetAvatatImage(imgaeName);
            }
            await _userRepository.Save();

            DeleteOldImage(request.AvatarFile, oldImage);
            return OperationResult.Success();
        }

        private void DeleteOldImage(IFormFile? avatarFile, string oldImage)
        {
            if (avatarFile == null || oldImage == "avatar.png")
                return;

            _fileService.DeleteFile(Directories.UserAvatar, oldImage);

        }
    }
}
