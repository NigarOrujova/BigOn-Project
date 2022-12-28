using BigOn.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;

namespace BigOn.Domain.Models.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BlogPostComment> Comments { get; set; }
        public virtual ICollection<BlogPostTagCloud> TagCloud { get; set; }
    }
}
