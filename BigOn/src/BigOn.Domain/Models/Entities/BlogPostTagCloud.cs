namespace BigOn.Domain.Models.Entities
{
    public class BlogPostTagCloud
    {
        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
