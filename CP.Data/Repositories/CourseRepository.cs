using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CP.Data.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(CPContext dbContext)
            : base(dbContext)
        {

        }
        public IEnumerable<Course> GetGrid()
        {
            return DbSet
                .Include("CourseType")
                .AsNoTracking()
                .ToList();
        }

        public Course GetByIdWithDependencies(Guid cursoId)
        {
            return DbSet
                 .Include("CourseType")
                 .FirstOrDefault(x => x.CourseId == cursoId);
        }

        public Course GetByName(string description)
        {
            return Find(x => x.Name == description).FirstOrDefault();
        }
    }
}
