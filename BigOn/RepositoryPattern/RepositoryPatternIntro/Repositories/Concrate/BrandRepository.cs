using RepositoryPatternIntro.Entities;
using RepositoryPatternIntro.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternIntro.Repositories.Concrate
{
    public class BrandRepository : IBrandRepository
    {
        static List<Brand> entities = new List<Brand>();
        public Brand Add(Brand entity)
        {
            entities.Add(entity);

            return entity;
        }

        public Brand Edit(Brand entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAll()
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
