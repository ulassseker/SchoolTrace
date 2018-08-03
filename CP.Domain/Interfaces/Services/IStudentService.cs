using CP.Domain.Entities;
using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CP.Domain.Interfaces.Services
{
    public interface IStudentService : IDisposable
    {
        ValidationResult AddNewStudent(Student student);
        IEnumerable<Student> GetGrid();
    }
}
