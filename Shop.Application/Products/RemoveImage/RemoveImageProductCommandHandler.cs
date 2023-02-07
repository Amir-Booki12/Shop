using Common.Application;
using Common.Application.FileUtil.Interface;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage
{
    internal class RemoveImageProductCommandHandler : IBaseCommandHandler<RemoveImageProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public RemoveImageProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(RemoveImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.imageId);
            await _repository.Save();
            _fileService.DeleteFile(Directories.ProductGallery, imageName);
            return OperationResult.Success();
        }
    }
}
