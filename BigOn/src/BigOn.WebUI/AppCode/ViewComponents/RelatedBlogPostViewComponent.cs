using BigOn.Domain.Business.BlogPostModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebUI.AppCode.ViewComponents
{
    public class RelatedBlogPostViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RelatedBlogPostViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(int postId, int size)
        {
            var query = new BlogPostRelatedQuery();
            query.PostId = postId;
            query.Size = size;

            var response = await mediator.Send(query);

            return View(response);
        }
    }
}
