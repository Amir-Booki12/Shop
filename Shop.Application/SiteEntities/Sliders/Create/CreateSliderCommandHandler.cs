using Common.Application;
using Common.Application.FileUtil.Interface;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ISliderRepository _slideRepository;
        private readonly IFileService _fileService;

        public CreateSliderCommandHandler(ISliderRepository slideRepository, IFileService fileService)
        {
            _slideRepository = slideRepository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImgaes);
            var slider = new Slider(request.Title,request.Link,imageName);

            _slideRepository.Add(slider);
            await _slideRepository.Save();
            return OperationResult.Success();
        }
    }
}
