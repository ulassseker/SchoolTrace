using CP.Domain.Entities;
using CP.Domain.Validation;
using CP.Domain.Validation.Base;
using CP.Domain.Specification.CourseSpecification;

namespace CP.Domain.Validation.CursoValidation
{
    public class CourseForRegistrationValidation : FiscalBase<Course>
    {
        public CourseForRegistrationValidation()
        {
            //Course Specification
            var courseName = new NomeEstaValidaSpecification();

            base.AddRule("NameInvalid", new Rule<Course>(courseName, "The name must contain between 5 and 50 characters."));

        }
    }
}
