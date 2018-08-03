using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Specification;

namespace CP.Domain.Specification.CourseSpecification
{
    public class SameNameForSameSpecification : ISpecification<Course>
    {
        private readonly ICourseRepository _courseRepository;
        public SameNameForSameSpecification(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool IsSatisfiedBy(Course course)
        {
            var courseDb = _courseRepository.GetByName(course.Name);

            if (courseDb != null)
                return (courseDb.CourseId == course.CourseId);

            return true;
        }
    }
}
