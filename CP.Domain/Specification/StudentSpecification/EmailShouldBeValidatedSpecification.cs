using CP.Domain.Entities;
using CP.Domain.Interfaces.Specification;
using CP.Domain.Validation.UserValidation;

namespace CP.Domain.Specification.StudentSpecification
{
    public class EmailShouldBeValidatedSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {
            return EmailValidation.Validate(student.User.Email);
        }
    }
}
