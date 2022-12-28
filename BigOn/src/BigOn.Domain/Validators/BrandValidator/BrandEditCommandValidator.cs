using BigOn.Domain.Business.BrandModule;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Validators.BrandValidator
{
    public class BrandEditCommandValidator : AbstractValidator<BrandEditCommand>
    {
        public BrandEditCommandValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id minimum 1 ola biler");

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Marka adi qeyd edilmeyib");
        }
    }
}
