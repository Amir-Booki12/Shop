using Commom.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.Products.DTOs
{
    public class ProductCategoryDto: BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
    }
}
   

