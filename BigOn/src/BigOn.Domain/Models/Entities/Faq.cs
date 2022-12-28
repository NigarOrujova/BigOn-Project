using BigOn.Domain.AppCode.Infrastructure;

namespace BigOn.Domain.Models.Entities
{
    public class Faq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
