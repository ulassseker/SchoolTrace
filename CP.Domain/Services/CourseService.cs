using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Services;
using CP.Domain.ValueObjects;
using CP.Domain.Validation.CursoValidation;
using System;
using System.Collections.Generic;

namespace CP.Domain.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public ValidationResult AddNewCourse(Course course)
        {
            var resultValidation = new ValidationResult();

            if (!course.IsValid)
            {
                resultValidation.AddError(course.ValidationResult);
                return resultValidation;
            }

            var resultadoConsistencia = new CourseConsistentValidation (_courseRepository).Validate(course);

            if (!resultadoConsistencia.IsValid)
            {
                resultValidation.AddError(resultadoConsistencia);
                return resultValidation;
            }
            _courseRepository.Add(course);

            return resultValidation;
        }
        public IEnumerable<Course> GelAll()
        {
            return _courseRepository.GetAll();
        }
        public Course GetById(Guid courseId)
        {
            return _courseRepository.GetById(courseId);
        }
        public Course GetByIdWithDependecies(Guid courseId)
        {
            return _courseRepository.GetByIdWithDependencies(courseId);
        }
        public ValidationResult UpdateCourse(Course course)
        {
            var resultValidation = new ValidationResult();
            var courseDb = _courseRepository.GetById(course.CourseId);

            courseDb.UpdateCourse(course.Name, course.Active, course.CourseType);

            if (!courseDb.IsValid)
            {
                resultValidation.AddError(courseDb.ValidationResult);
                return resultValidation;
            }

            var resultadoConsistencia = new CourseConsistentToUpdateValidation(_courseRepository).Validate(courseDb);

            if (!resultadoConsistencia.IsValid)
            {
                resultValidation.AddError(resultadoConsistencia);
                return resultValidation;
            }

            _courseRepository.Update(courseDb);

            return resultValidation;
        }
        public IEnumerable<Course> GetGrid()
        {
            return _courseRepository.GetGrid();
        }
        public void Dispose()
        {
            _courseRepository.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
