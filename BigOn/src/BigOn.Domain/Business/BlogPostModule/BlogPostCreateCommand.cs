using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BlogPostModule
{
    public class BlogPostCreateCommand : IRequest<BlogPost>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Image { get; set; }

        public int[] TagIds { get; set; }

        public class BlogPostCreateCommandHandler : IRequestHandler<BlogPostCreateCommand, BlogPost>
        {
            private readonly BigOnDbContext db;
            private readonly IHostEnvironment env;

            public BlogPostCreateCommandHandler(BigOnDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<BlogPost> Handle(BlogPostCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new BlogPost()
                {
                    Title = request.Title,
                    Body = request.Body,
                    CategoryId = request.CategoryId,
                };

                model.ImagePath = request.Image.GetRandomImagePath("blog");

                await env.SaveAsync(request.Image, model.ImagePath, cancellationToken);

                model.Slug = model.Title.ToSlug();


                if (request.TagIds != null && request.TagIds.Length > 0)
                {
                    model.TagCloud = new List<BlogPostTagCloud>();

                    foreach (var item in request.TagIds.Distinct())
                    {
                        var tc = new BlogPostTagCloud();
                        tc.TagId = item;
                        model.TagCloud.Add(tc);
                    }
                }

                await db.AddAsync(model, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return model;
            }
        }
    }
}
