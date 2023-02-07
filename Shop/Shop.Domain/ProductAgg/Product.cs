using Commom.Domain;
using Commom.Domain.Exceptions;
using Commom.Domain.Utils;
using Commom.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class Product:AggregateRoot
    {
        public Product(string title, string imageName, string description, string slug,
            long categoryId, long subCategoryId, long secendrySubCategoryId, SeoData seoData
            ,IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guord(title, description, slug, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            Slug = slug.ToSlug();
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecendrySubCategoryId = secendrySubCategoryId;
            SeoData = seoData;
        }
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long? SecendrySubCategoryId { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> ProductImages { get; private set; }
        public List<ProductSpecification> ProductSpecifications { get; private set; }

        public void Edit(string title, string description, string slug,
            long categoryId, long subCategoryId, long secendrySubCategoryId, SeoData seoData
            , IProductDomainService domainService)
        {
            Guord(title, description, slug, domainService);
            Title = title;
            Description = description;
            Slug = slug.ToSlug();
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecendrySubCategoryId = secendrySubCategoryId;
            SeoData = seoData;
        }
        public void SetImageProduct(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;

        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            ProductImages.Add(image);
        }
        public string RemoveImage(long imageId)
        {
            var image = ProductImages.FirstOrDefault(p=>p.Id== imageId);
            if (image == null)
            {
                throw new InvalidDomainDataException("عکس یافت نشد");
            }
            ProductImages.Remove(image);
            return image.ImageName;
        }
        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(s => s.ProductId = Id);
            ProductSpecifications = specifications;
        }
        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }
        public void Guord(string title,string description, string slug, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (domainService.IsSlugExists(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}
