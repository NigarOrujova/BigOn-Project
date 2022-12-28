using BigOn.Domain.Interfaces.Repositories;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BrandModule
{
    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }

        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            private readonly IBrandRepository repo;

            public BrandCreateCommandHandler(IBrandRepository repo)
            {
                this.repo = repo;
            }

            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                var brand = new Brand()
                {
                    Name = request.Name
                };

                repo.Add(brand);

                //await db.Brands.AddAsync(brand,cancellationToken);
                //await db.SaveChangesAsync(cancellationToken);

                return brand;
            }
        }
    }
}
