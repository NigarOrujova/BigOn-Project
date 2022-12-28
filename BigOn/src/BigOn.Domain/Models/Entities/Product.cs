using BigOn.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string StockKeepingUnit { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rate { get; set; } = 0;
        public bool? InStock { get; set; } = false;
        public int? Quantity { get; set; } = 0;
        public int BrandId { get; set; } = 0;
        public virtual Brand Brand { get; set; }
        public int CategoryId { get; set; } = 0;
        public virtual Category Category { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
}
