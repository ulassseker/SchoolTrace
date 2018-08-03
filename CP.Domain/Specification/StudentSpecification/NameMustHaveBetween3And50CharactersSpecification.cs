using CP.Domain.Entities;
using CP.Domain.Interfaces.Specification;

namespace CP.Domain.Specification.StudentSpecification
{
    public class NameMustHaveBetween3And50CharactersSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {
            return student.Name.Length >= 3 && student.Name.Length <= 50;
        }
    }
}
