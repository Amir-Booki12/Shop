using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Products
{
    public interface IProductFacade
    {
        Task<OperationResult> CreateProduct(CreateProductCommand command);
        Task<OperationResult> EditProduct(EditProductCommand command);
        Task<OperationResult> AddImage(AddImageProductCommand command);
        Task<OperationResult> RemoveImage(RemoveImageProductCommand command);

        Task<ProductDto?> GetProductById(long productId);
        Task<ProductDto?> GetProductBySlug(string slug);

        Task<ProductFilterResult> GetProductsByFilter(ProductFilterParam filterParams);
        Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);

    }
}
