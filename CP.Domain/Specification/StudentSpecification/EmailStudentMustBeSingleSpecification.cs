using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Specification;

namespace CP.Domain.Specification.StudentSpecification
{
    public class EmailStudentMustBeSingleSpecification : ISpecification<Student>
    {
        private readonly IStudentRepository _studentRepository;

        public EmailStudentMustBeSingleSpecification(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool IsSatisfiedBy(Student student)
        {
            return _studentRepository.GetByEmail(student.User.Email) == null;
        }
    }
}
