using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.FaqModule
{
    public class FaqEditCommand : IRequest<Faq>
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public class FaqEditCommandHandler : IRequestHandler<FaqEditCommand, Faq>
        {
            private readonly BigOnDbContext db;

            public FaqEditCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<Faq> Handle(FaqEditCommand request, CancellationToken cancellationToken)
            {
                var faq = await db.Faqs.FirstOrDefaultAsync(b => b.Id == request.Id
               && b.DeletedDate == null, cancellationToken);

                if (faq == null)
                {
                    return null;
                }

                faq.Question = request.Question;
                faq.Answer = request.Answer;

                await db.SaveChangesAsync(cancellationToken);

                return faq;
            }
        }
    }
}
