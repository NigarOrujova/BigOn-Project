using BigOn.Domain.Interfaces.Repositories;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Repositories.FakeRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BrandModule
{
    public class BrandEditCommand : IRequest<Brand>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class BrandEditCommandHandler : IRequestHandler<BrandEditCommand, Brand>
        {
            private readonly IBrandRepository repo;

            public BrandEditCommandHandler(IBrandRepository repo)
            {
                this.repo = repo;
            }

            public async Task<Brand> Handle(BrandEditCommand request, CancellationToken cancellationToken)
            {
                var brand = repo.Edit(new Brand
                {
                    Id = request.Id,
                    Name = request.Name
                });

                return brand;
            }
        }
    }
}
