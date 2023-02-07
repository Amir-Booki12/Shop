using Common.Application;
using Common.Application.FileUtil.Interface;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IFileService _fileService;

        public EditBannerCommandHandler(IBannerRepository bannerRepository, IFileService fileService)
        {
            _bannerRepository = bannerRepository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetTracking(request.BannerId);
            if (banner == null)
                return OperationResult.NotFound();
            var currentImageName = banner.ImageName;
            var oldImage = banner.ImageName;
            if (request.ImageFile != null)
            {
                currentImageName =await _fileService.SaveFileAndGenerateName(request.ImageFile,
                    Directories.BannerImgaes);
            }
            banner.Edit(request.Link, currentImageName, request.Position);
           await _bannerRepository.Save();
            RemoveOldImage(request.ImageFile,oldImage);
            return OperationResult.Success();

        }

        private void RemoveOldImage(IFormFile imgaeFile,string oldImage)
        {
            if(imgaeFile != null)
            {
                _fileService.DeleteFile(Directories.BannerImgaes,oldImage);
            }
        }
    }
}
