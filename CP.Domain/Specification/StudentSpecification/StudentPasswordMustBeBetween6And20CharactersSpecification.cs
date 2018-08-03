using CP.Domain.Entities;
using CP.Domain.Interfaces.Specification;

namespace CP.Domain.Specification.StudentSpecification
{
    public class StudentPasswordMustBeBetween6And20CharactersSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {
            return student.User.Password.Length >= 6 && student.User.Password.Length <= 20;
        }
    }
}
