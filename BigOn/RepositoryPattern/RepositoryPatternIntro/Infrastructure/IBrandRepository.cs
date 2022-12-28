using RepositoryPatternIntro.Entities;
using System.Collections.Generic;

namespace RepositoryPatternIntro.Infrastructure
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand GetById(int id);
        Brand Add(Brand entity);
        Brand Edit(Brand entity);
        bool Remove(Brand entity);
    }
}
