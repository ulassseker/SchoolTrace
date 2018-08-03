using CP.Domain.Entities;
using CP.Domain.Interfaces.Specification;


namespace CP.Domain.Specification.CourseSpecification
{
    public class NomeEstaValidaSpecification : ISpecification<Course>
    {
        public bool IsSatisfiedBy(Course course)
        {
            if (!string.IsNullOrEmpty(course.Name))
            {
                return course.Name.Length > 5 && course.Name.Length < 50;
            }
            return false;
        }
    }
}
