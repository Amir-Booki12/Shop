using Common.Application;
using Common.Application.FileUtil.Interface;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    internal class AddImageProductCommandHandler : IBaseCommandHandler<AddImageProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public AddImageProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGallery);

            var productImage = new ProductImage(imageName, request.Sequence);

            product.AddImage(productImage);
            await _repository.Save();
           
            return OperationResult.Success();
            
        }
    }
}
