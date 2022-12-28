using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.TagModule
{
    public class TagsAllQuery :IRequest<List<Tag>>
    {
        public class TagsAllQueryHandler : IRequestHandler<TagsAllQuery, List<Tag>>
        {
            private readonly BigOnDbContext db;

            public TagsAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<List<Tag>> Handle(TagsAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Tags
                 .Where(m => m.DeletedDate == null)
                 .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
