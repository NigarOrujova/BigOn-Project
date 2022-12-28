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

namespace BigOn.Domain.Business.FaqModule
{
    public class FaqSingleQuery : IRequest<Faq>
    {
        public int Id { get; set; }


        public class FaqSingleQueryHandler : IRequestHandler<FaqSingleQuery, Faq>
        {
            private readonly BigOnDbContext db;

            public FaqSingleQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<Faq> Handle(FaqSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Faqs.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                return entity;
            }
        }
    }
}
