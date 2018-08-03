using CP.Domain.Entities;
using CP.Domain.Specification.StudentSpecification;
using CP.Domain.Validation.Base;

namespace CP.Domain.Validation.StudentValidation
{
    public class StudentEligibleForRegistrationValidation : FiscalBase<Student>
    {
        public StudentEligibleForRegistrationValidation()
        {
            //Student
            var studentName = new NameMustHaveBetween3And50CharactersSpecification();
            var studentCPF = new CPFStudentMustBeValidatedSpecification();
            var HigherClassStudent = new StudentMustBeGreaterDeficiencySpecification();

            //User
            var studentEmail = new EmailShouldBeValidatedSpecification();
            var studentPassword = new StudentPasswordMustBeBetween6And20CharactersSpecification();

            base.AddRule("studentName", new Rule<Student>(studentName, "Student name must be between 3 and 50 characters."));
            base.AddRule("studentCPF", new Rule<Student>(studentCPF, "Student's CPF is invalid."));
            base.AddRule("HigherClassStudent", new Rule<Student>(HigherClassStudent, "The student must be of legal age."));
            base.AddRule("studentEmail", new Rule<Student>(studentEmail, "The student's email is invalid."));
            base.AddRule("studentPassword", new Rule<Student>(studentPassword, "Password must be between 6 and 20 characters."));
        }
    }
}
