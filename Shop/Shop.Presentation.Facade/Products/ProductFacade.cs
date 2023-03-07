using Common.Application;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;
using Shop.Query.Products.GetForShop;

namespace Shop.Presentation.Facade.Products
{
    public class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;

        public ProductFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> CreateProduct(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditProduct(EditProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddImage(AddImageProductCommand command)
        {
           return await _mediator.Send(command);
           
        }

        public async Task<OperationResult> RemoveImage(RemoveImageProductCommand command)
        {
            return await _mediator.Send(command);
            
        }

        public async Task<ProductDto?> GetProductById(long productId)
        {
            return await _mediator.Send(new GetProductByIdQuery(productId));
        }

        public async Task<ProductDto?> GetProductBySlug(string slug)
        {
            return await _mediator.Send(new GetProductBySlugQuery(slug));
        }



        public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParam filterParams)
        {
            return await _mediator.Send(new GetByProductByFilterQuery(filterParams));
        }
        public async Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams)
        {
            return await _mediator.Send(new GetProductsForShopQuery(filterParams));
        }

    }
}
