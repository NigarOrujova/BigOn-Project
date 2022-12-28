using BigOn.Domain.Business.BlogPostModule;
using BigOn.Domain.Business.CategoryModule;
using BigOn.Domain.Business.TagModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.blogposts.index")]
        public async Task<IActionResult> Index(BlogPostPagedQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        [Authorize(Policy = "admin.blogposts.details")]
        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.blogposts.create")]
        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            var tags = await mediator.Send(new TagsAllQuery());
            ViewBag.TagId = new SelectList(tags, "Id", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.blogposts.create")]
        public async Task<IActionResult> Create(BlogPostCreateCommand command)
        {
            //check image file or not via c#

            if (command.Image == null)
            {
                ModelState.AddModelError("Image", "Sekil secilmeyib");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", command.CategoryId);


            var tags = await mediator.Send(new TagsAllQuery());
            ViewBag.TagId = new SelectList(tags, "Id", "Text");

            return View(command);
        }

        [Authorize(Policy = "admin.blogposts.edit")]
        public async Task<IActionResult> Edit(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", response.CategoryId);

            var tags = await mediator.Send(new TagsAllQuery());
            ViewBag.TagId = new SelectList(tags, "Id", "Text");

            var command = new BlogPostEditCommand();
            command.Title = response.Title;
            command.Body = response.Body;
            command.CategoryId = response.CategoryId;
            command.ImagePath = response.ImagePath;
            command.TagIds = response.TagCloud.Select(tc=>tc.TagId).ToArray();

            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.blogposts.edit")]
        public async Task<IActionResult> Edit(BlogPostEditCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                var categories = await mediator.Send(new CategoryAllQuery());
                ViewBag.CategoryId = new SelectList(categories, "Id", "Name", response.CategoryId);


                var tags = await mediator.Send(new TagsAllQuery());
                ViewBag.TagId = new SelectList(tags, "Id", "Text");

                return View(command);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
