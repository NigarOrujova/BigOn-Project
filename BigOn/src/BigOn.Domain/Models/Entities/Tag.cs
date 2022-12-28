using BigOn.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Models.Entities
{
    public class Tag : BaseEntity
    {
        public string Text { get; set; }
        public virtual ICollection<BlogPostTagCloud> TagCloud { get; set; }
    }
}
