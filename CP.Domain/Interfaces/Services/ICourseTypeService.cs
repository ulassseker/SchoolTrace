using CP.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CP.Domain.Interfaces.Services
{
    public interface ICourseTypeService : IDisposable
    {
        IEnumerable<CourseType> GetAll();
        IEnumerable<CourseType> Lists();
        CourseType GetById(Guid id);
    }
}
