using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Specification;

namespace CP.Domain.Specification.CourseSpecification
{
    public class NameMustBeUniqueSpecification : ISpecification<Course>
    {
        private readonly ICourseRepository _courseRepository;
        public NameMustBeUniqueSpecification(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public bool IsSatisfiedBy(Course course)
        {
            return _courseRepository.GetByName(course.Name) == null;
        }
    }
}
