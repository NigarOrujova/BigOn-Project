using BigOn.Domain.AppCode.Infrastructure;
using System;

namespace BigOn.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
