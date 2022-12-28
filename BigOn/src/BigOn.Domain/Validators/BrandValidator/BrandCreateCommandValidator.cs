using BigOn.Domain.Business.BrandModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Validators.BrandValidator
{
    public class BrandCreateCommandValidator : AbstractValidator<BrandCreateCommand>
    {
        public BrandCreateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Marka adi qeyd edilmeyib");
        }
    }
}
