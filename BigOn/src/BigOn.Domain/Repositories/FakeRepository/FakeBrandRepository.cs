using BigOn.Domain.Interfaces.Repositories;
using BigOn.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Repositories.FakeRepository
{
    public class FakeBrandRepository : IBrandRepository
    {
        public Brand Add(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Edit(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brand> GetAll(Expression<Func<Brand, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
