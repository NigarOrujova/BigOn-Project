using BigOn.Domain.Business.ProductModule;
using FluentValidation;
using System.Linq;

namespace BigOn.Domain.Validators.ProductValidators
{
    public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Ad bosh buraxila bilmez");

            RuleFor(c => c.ShortDescription)
                .NotEmpty()
                .WithMessage("ShortDescription bosh buraxila bilmez")
                .MaximumLength(250)
                .WithMessage("250 simvoldan cox ola bilmez");

            RuleFor(c => c.BrandId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Marka secilmeyib")
                .NotNull()
                .WithMessage("Marka secilmeyib");

            RuleFor(c => c.CategoryId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Kategoriya secilmeyib")

                .NotNull()
                .WithMessage("Kategoriya secilmeyib");

            RuleFor(c => c.Images)
                .Custom((list, context) =>
                {
                    if (list==null || list.Count(l => l.IsMain == true) == 0)
                    {
                        context.AddFailure("Esas sekil secilmeyib");
                    }
                });

            RuleForEach(c => c.Images)
                .ChildRules(x =>
                {
                    x.RuleFor(e => e.File)
                    .NotNull()
                    .WithMessage("Fayl secilmeyib");

                });
        }
    }
}
