using CP.Domain.Entities;
using CP.Domain.Interfaces.Specification;
using CP.Domain.Validation.DocumentoValidation;

namespace CP.Domain.Specification.StudentSpecification
{
    public class CPFStudentMustBeValidatedSpecification : ISpecification<Student>
    {
        public bool IsSatisfiedBy(Student student)
        {
            return CPFValidation.Validar(student.CPF);
        }
    }
}
