using CP.Domain.Entities;
using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CP.Domain.Interfaces.Services
{
    public interface ICourseService : IDisposable
    {
        ValidationResult AddNewCourse(Course course);
        ValidationResult UpdateCourse(Course course);
        IEnumerable<Course> GelAll();
        IEnumerable<Course> GetGrid();
        Course GetById(Guid courseId);
        Course GetByIdWithDependecies(Guid courseId);
    }
}
