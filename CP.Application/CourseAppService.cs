using CP.Application.Interfaces;
using CP.Application.Validation;
using CP.Application.ViewModels.Course;
using CP.Domain.Entities;
using CP.Domain.Interfaces.Services;
using CP.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CP.Application
{
    public class CourseAppService : AppServiceBase, ICourseAppService
    {
        private readonly ICourseService _courseService;
        private readonly ICourseTypeService _courseTypeService;

        public CourseAppService(ICourseService courseService, ICourseTypeService courseTypeService, IUnitOfWork uow)
            : base(uow)
        {
            _courseService = courseService;
            _courseTypeService = courseTypeService;
        }

        public ValidationAppResult RegisterNewCourse(NewCourseViewModel newCourseViewModel)
        {
            var validationResult = new ValidationAppResult();
            BeginTransaction();

            var novoCurso = new Course(newCourseViewModel.Name, newCourseViewModel.Active, _courseTypeService.GetById(newCourseViewModel.CourseTypeId));

            validationResult = DomainToApplicationResult(_courseService.AddNewCourse(novoCurso));

            if (validationResult.IsValid)
                Commit();

            return validationResult;
        }

        public ValidationAppResult EditCourse(EditionCourseViewModel courseViewModel)
        {
            BeginTransaction();
            var course = _courseService.GetById(courseViewModel.CourseId);
            var courseType = _courseTypeService.GetById(courseViewModel.CourseTypeId);
            course.UpdateCourse(courseViewModel.Name, courseViewModel.Active, courseType);

            var validationAppResult = DomainToApplicationResult(_courseService.UpdateCourse(course));

            if (validationAppResult.IsValid)
                Commit();

            return validationAppResult;
        }
        public IEnumerable<GridCourseViewModel> ListGrid()
        {
            var cursos = _courseService.GetGrid();
            var viewModels = new List<GridCourseViewModel>();
            foreach (var item in cursos)
            {
                viewModels.Add(new GridCourseViewModel
                {
                    CourseId = item.CourseId,
                    Name = item.Name,
                    RegistrationDate = item.RegisterDate,
                    Active = item.Active,
                    CourseType = item.CourseType.Description
                });
            }

            return viewModels;
        }
        public EditionCourseViewModel GetToEdit(Guid id)
        {
            var course = _courseService.GetByIdWithDependecies(id);

            var courseViewModel = new EditionCourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                CourseTypeId = course.CourseType.CourseTypeId,
                Active = course.Active
            };

            return courseViewModel;
        }
        public void Dispose()
        {
            _courseService.Dispose();
            _courseTypeService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
