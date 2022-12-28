using BigOn.Domain.Business.BlogPostModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebUI.AppCode.ViewComponents
{
    public class RecentBlogPostsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RecentBlogPostsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int size)
        {
            var query = new BlogPostRecentQuery();
            query.Size = size;

            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
