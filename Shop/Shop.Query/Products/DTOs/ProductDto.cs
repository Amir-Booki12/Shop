using Commom.Domain.ValueObjects;
using Common.Query;
using Common.Query.Filter;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Products.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Title { get;  set; }
        public string ImageName { get;  set; }
        public string Description { get;  set; }
        public string Slug { get;  set; }
        public ProductCategoryDto Category { get;  set; }
        public ProductCategoryDto SubCategory { get;  set; }
        public ProductCategoryDto? SecendrySubCategory { get;  set; }
        public SeoData SeoData { get;  set; }
        public List<ProductImageDto> ProductImages { get;  set; }
        public List<ProductSpecificationDto> ProductSpecifications { get;  set; }
    }

    public class ProductFilterData: BaseDto
    {
        public string Title { get;  set; }
        public string ImageName { get;  set; }       
        public string Slug { get;  set; }
    }
    public class ProductFilterParam:BaseFilterParam
    {
        public string? Title { get; set; }
        public long? Id { get; set; }
        public string? Slug { get; set; }
    }
    public class ProductFilterResult:BaseFilter<ProductFilterData, ProductFilterParam>
    {

    }
}
   

