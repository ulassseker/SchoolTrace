using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Specification.CourseSpecification;
using CP.Domain.Validation.Base;

namespace CP.Domain.Validation.CursoValidation
{
    public class CourseConsistentToUpdateValidation : FiscalBase<Course>
    {
        public CourseConsistentToUpdateValidation(ICourseRepository courseRepository)
        {
            var uniqueCourseName = new SameNameForSameSpecification(courseRepository);

            base.AddRule("RegistrationName", new Rule<Course>(uniqueCourseName, "This course has already been registered in the database."));
        }
    }
}
