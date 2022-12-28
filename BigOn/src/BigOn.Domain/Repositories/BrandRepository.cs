using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigOn.Domain.Interfaces.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(BigOnDbContext db) : base(db)
        {
        }
    }
}
