using BigOn.Domain.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace BigOn.Domain.Models.Entities
{
    public class Brand : BaseEntity
    {
        [Required(ErrorMessage = "{0} bosh buraxia bilmez")]
        public string Name { get; set; }

    }
}
