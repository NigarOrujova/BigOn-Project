using BigOn.Domain.Models.Entities.Membership;
using System;

namespace BigOn.Domain.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int? CreatedByUserId { get; set; }
        public virtual BigonUser CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }
        public virtual BigonUser DeletedByUser { get; set; }
    }
}
