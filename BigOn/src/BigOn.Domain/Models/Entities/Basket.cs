using BigOn.Domain.AppCode.Infrastructure;

namespace BigOn.Domain.Models.Entities
{
    public class Basket : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
