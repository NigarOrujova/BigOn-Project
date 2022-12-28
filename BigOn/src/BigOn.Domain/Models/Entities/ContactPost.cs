using BigOn.Domain.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace BigOn.Domain.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public string Answer { get; set; }
        public DateTime? AnsweredDate { get; set; }
    }
}
