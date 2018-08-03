using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Specification.StudentSpecification;
using CP.Domain.Validation.Base;

namespace CP.Domain.Validation.StudentValidation
{
    public class StudentConsistentForRegistrationValidation : FiscalBase<Student>
    {
        public StudentConsistentForRegistrationValidation(IStudentRepository studentRepository)
        {
            var cpfSingleStudent = new CPFShouldBeUniqueSpecification(studentRepository);
            var emailUserSingleStudent = new EmailStudentMustBeSingleSpecification(studentRepository);

            base.AddRule("CPFSingleStudent", new Rule<Student>(cpfSingleStudent, "There is already a student with this CPF."));
            base.AddRule("EmailUserSingleStudent", new Rule<Student>(emailUserSingleStudent, "There is already a student with this email."));
        }
    }
}
