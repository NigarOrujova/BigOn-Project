using BigOn.Domain.Business.BrandModule;
using BigOn.Domain.Business.CategoryModule;
using BigOn.Domain.Business.ProductModule;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<ProductCreateCommand> productCreateCommandValidator;

        public ProductsController(IMediator mediator
            , IValidator<ProductCreateCommand> productCreateCommandValidator)
        {
            this.mediator = mediator;
            this.productCreateCommandValidator = productCreateCommandValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var brands = await mediator.Send(new BrandsAllQuery());
            ViewBag.BrandId = new SelectList(brands, "Id", "Name");
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            //validate - with fluent validation

            var result = productCreateCommandValidator.Validate(command);

            if (result.IsValid)
            {
                var response = await mediator.Send(command);

                //return RedirectToAction(nameof(Index));

                return Json(new
                {
                    error = false,
                    message = "Elave edildi"
                });
            }

            //foreach (var error in result.Errors)
            //{
            //    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //}

            return Json(new
            {
                error = true,
                errors = result.Errors
            });
        }
    }
}
