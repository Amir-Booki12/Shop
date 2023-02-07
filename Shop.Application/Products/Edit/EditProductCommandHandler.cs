using Common.Application;
using Common.Application.FileUtil.Interface;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit
{
    internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _domainService;
        private readonly IFileService _fileService;

        public EditProductCommandHandler(IProductRepository productRepository, IProductDomainService domainService, IFileService fileService)
        {
            _productRepository = productRepository;
            _domainService = domainService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product =await _productRepository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();
            product.Edit(request.Title,request.Description,request.Slug,request.CategoryId,request.SubCategoryId
                ,request.SecendrySubCategoryId,request.SeoData,_domainService);

            var oldImage = product.ImageName;

            if (request.ImageFile != null)
            {
                var imageName =await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                product.SetImageProduct(imageName);
            }
            var specifications = new List<ProductSpecification>();
            request.ProductSpecifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifications);
            await _productRepository.Save();
            RemoveOldImage(request.ImageFile,oldImage);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imageFile,string oldImage)
        {
            if (imageFile!=null)
            {
                _fileService.DeleteFile(Directories.ProductImages, oldImage);
            }
        }
    }
}
