using Common.Application;
using Common.Application.FileUtil.Interface;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductDomainService _domainService;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductRepository productRepository,
            IProductDomainService domainService, IFileService fileService)
        {
            _productRepository = productRepository;
            _domainService = domainService;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var imageName =await _fileService.SaveFileAndGenerateName(request.ImageFile,Directories.ProductImages);

            var product =new Product(request.Title,imageName,request.Description,request.Slug,
                request.CategoryId,request.SubCategoryId,request.SecendrySubCategoryId,request.SeoData,_domainService);

            _productRepository.Add(product);

            var specifications = new List<ProductSpecification>();

            request.ProductSpecifications.ToList().ForEach(specification =>
            {
                specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            });
            product.SetSpecification(specifications);
            await _productRepository.Save();
            return OperationResult.Success();
                
        }
    }
}
