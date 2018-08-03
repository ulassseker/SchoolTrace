using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Validation;
using CP.Domain.Validation.Base;
using CP.Domain.Specification.CourseSpecification;

namespace CP.Domain.Validation.CursoValidation
{
    public class CourseConsistentValidation : FiscalBase<Course>
    {
        public CourseConsistentValidation (ICourseRepository courseRepository)
        {
            var uniqueCourseName = new NameMustBeUniqueSpecification(courseRepository);

            base.AddRule("RegisteredName", new Rule<Course>(uniqueCourseName, "This course has already been registered in the database."));
        }
    }
}
