using BigOn.Domain.Business.CategoryModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebUI.AppCode.ViewComponents
{
    public class AllCategoriesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public AllCategoriesViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new CategoryTreeQuery();
            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
