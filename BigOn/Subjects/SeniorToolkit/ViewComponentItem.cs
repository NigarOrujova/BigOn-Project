using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace $rootnamespace$
{
    public class $safeitemrootname$ViewComponent: ViewComponent
    {
        private readonly IMediator mediator;

        public $safeitemrootname$ViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
