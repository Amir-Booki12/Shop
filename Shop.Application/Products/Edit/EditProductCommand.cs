using Commom.Domain.ValueObjects;
using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommand:IBaseCommand
    {
        public EditProductCommand(string title, IFormFile? imageFile, string description, string slug, 
            long categoryId, long subCategoryId, long secendrySubCategoryId, SeoData seoData, 
            Dictionary<string, string> productSpecifications)
        {
            Title = title;
            ImageFile = imageFile;
            Description = description;
            Slug = slug;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecendrySubCategoryId = secendrySubCategoryId;
            SeoData = seoData;
            ProductSpecifications = productSpecifications;
        }

        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecendrySubCategoryId { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> ProductSpecifications { get; private set; }
    }
}
