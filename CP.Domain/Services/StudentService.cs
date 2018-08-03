using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Services;
using CP.Domain.Validation.StudentValidation;
using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ValidationResult AddNewStudent(Student student)
        {
            var validationResult = new ValidationResult();

            if (!student.IsValid)
            {
                validationResult.AddError(student.ValidationResult);
                return validationResult;
            }

            var consistencyResult = new StudentConsistentForRegistrationValidation(_studentRepository).Validate(student);

            if (!consistencyResult.IsValid)
            {
                validationResult.AddError(consistencyResult);
                return validationResult;
            }
            _studentRepository.Add(student);

            return validationResult;
        }

        public IEnumerable<Student> GetGrid()
        {
            return _studentRepository.GetGrid();
        }

        public void Dispose()
        {
            _studentRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
