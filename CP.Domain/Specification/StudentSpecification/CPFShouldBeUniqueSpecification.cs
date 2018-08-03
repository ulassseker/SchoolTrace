using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Specification;

namespace CP.Domain.Specification.StudentSpecification
{
    public class CPFShouldBeUniqueSpecification : ISpecification<Student>
    {
        private readonly IStudentRepository _studentRepository;

        public CPFShouldBeUniqueSpecification(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool IsSatisfiedBy(Student student)
        {
            return _studentRepository.GetByCPF(student.CPF) == null;
        }
    }
}
