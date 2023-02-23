using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            return new ProductDto()
            {
                Title = product.Title,
                Slug = product.Slug,
                CreationDate = product.CreationDate,
                Description = product.Description,
                ImageName = product.ImageName,
                SeoData = product.SeoData,
                ProductImages = product.ProductImages.Select(s => new ProductImageDto()
                {
                    Id = s.Id,
                    ImageName = s.ImageName,
                    Sequence = s.Sequence,
                    CreationDate = s.CreationDate,
                    ProductId = s.ProductId


                }).ToList(),
                ProductSpecifications = product.ProductSpecifications.Select(s => new ProductSpecificationDto()
                {
                    CreationDate = s.CreationDate,
                    Id = s.Id,
                    Key = s.Key,
                    Value = s.Value
                }).ToList(),

                Category = new ProductCategoryDto()
                {
                    Id = product.CategoryId,
                },
                SubCategory = new ProductCategoryDto()
                {
                    Id = product.SubCategoryId
                },
                SecendrySubCategory =product.SecendrySubCategoryId!=null? new ProductCategoryDto()
                {
                    Id = (long)product.SecendrySubCategoryId
                }:null
            };

        }

        public static ProductFilterData MapData(this Product product)
        {
            return new ProductFilterData()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title
            };
        }

        public static async Task SetCategories(this ProductDto product, ShopContext context)
        {
            var category =await context.Categories.Where(s => s.Id == product.Category.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    SeoData = s.SeoData,
                    Slug = s.Slug,
                    Title = s.Title

                }).FirstOrDefaultAsync();
            var subCategory =await context.Categories.Where(s => s.Id == product.SubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    SeoData = s.SeoData,
                    Slug = s.Slug,
                    Title = s.Title

                }).FirstOrDefaultAsync();
            if (product.SecendrySubCategory != null)
            {
                var secendryCategory =await context.Categories.Where(s => s.Id == product.SecendrySubCategory.Id)
               .Select(s => new ProductCategoryDto()
               {
                   Id = s.Id,
                   CreationDate = s.CreationDate,
                   SeoData = s.SeoData,
                   Slug = s.Slug,
                   Title = s.Title

               }).FirstOrDefaultAsync();

                if (secendryCategory != null)
                    product.SecendrySubCategory = secendryCategory;
            }
            if (category != null)
                product.Category = category;

            if (subCategory != null)
                product.SubCategory = subCategory;

           
        }
    }
}
