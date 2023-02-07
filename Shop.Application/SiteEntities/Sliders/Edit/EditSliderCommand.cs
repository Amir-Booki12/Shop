using Common.Application;
using Common.Application.FileUtil.Interface;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand:IBaseCommand
    {
        public EditSliderCommand(long sliderId, string title, string link, IFormFile? imageFile)
        {
            SliderId = sliderId;
            Title = title;
            Link = link;
            ImageFile = imageFile;
        }

        public long SliderId { get; private set; }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
    }

    internal class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private readonly IFileService _fileService;
        private readonly ISliderRepository _slideRepository;

        public EditSliderCommandHandler(IFileService fileService, ISliderRepository slideRepository)
        {
            _fileService = fileService;
            _slideRepository = slideRepository;
        }

        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _slideRepository.GetTracking(request.SliderId);
            if (slider == null)
                return OperationResult.NotFound();
            var currentImageName = slider.ImageName;
            var oldImage = slider.ImageName;
            if (request.ImageFile != null)
            {
                currentImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile,
                    Directories.SliderImgaes);
            }
            slider.Edit(request.Title,request.Link,currentImageName);
            await _slideRepository.Save();
            RemoveOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imgaeFile, string oldImage)
        {
            if (imgaeFile != null)
            {
                _fileService.DeleteFile(Directories.SliderImgaes, oldImage);
            }
        }
    }
}
