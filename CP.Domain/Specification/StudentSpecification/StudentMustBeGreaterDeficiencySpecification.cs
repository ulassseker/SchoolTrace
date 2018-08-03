using CP.Domain.Entities;
using CP.Domain.Interfaces.Specification;
using System;

namespace CP.Domain.Specification.StudentSpecification
{
    public class StudentMustBeGreaterDeficiencySpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {

            var timeSpan = DateTime.Now.Subtract(student.BirthDate);
            if (timeSpan.Days >= 365)
            {
                var idade = (new DateTime() + timeSpan).AddYears(-1).AddDays(-1);
                return idade.Year >= 18;
            }
            return false;
        }
    }
}
