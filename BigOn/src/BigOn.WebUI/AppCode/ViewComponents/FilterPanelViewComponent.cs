using BigOn.Domain.Business.FilterModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebUI.AppCode.ViewComponents
{
    public class FilterPanelViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public FilterPanelViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new SearchPanelQuery();
            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
