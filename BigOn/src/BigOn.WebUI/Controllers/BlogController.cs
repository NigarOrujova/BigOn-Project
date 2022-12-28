using BigOn.Domain.Business.BlogPostModule;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BigOn.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator mediator;
        private readonly BigOnDbContext db;

        public BlogController(IMediator mediator,BigOnDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(BlogPostPagedQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }

        [AllowAnonymous]
        [Route("/blog/tags/{tagId}")]
        public async Task<IActionResult> PostsByTag(BlogPostByTagQuery query)
        {
            var response = await mediator.Send(query);

            return View("Index",response);
        }

        [AllowAnonymous]
        [Route("/blog/{slug}")]
        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response==null)
            {
                return NotFound();
            }

            return View(response);
        }

        public async Task<IActionResult> PostComment(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }
    }
}
