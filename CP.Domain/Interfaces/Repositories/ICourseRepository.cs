using CP.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CP.Domain.Interfaces.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Course GetByName(string name);
        Course GetByIdWithDependencies(Guid courseId);
        IEnumerable<Course> GetGrid();
    }
}
