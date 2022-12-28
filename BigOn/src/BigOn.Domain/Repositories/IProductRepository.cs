using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities;
using System.Collections.Generic;

namespace BigOn.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        double SetRate(Product product, int rate);
    }
}
