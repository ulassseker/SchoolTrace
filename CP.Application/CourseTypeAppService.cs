using CP.Application.Interfaces;
using CP.Application.ViewModels.CourseType;
using CP.Domain.Interfaces.Services;
using CP.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace CP.Application
{
    public class CourseTypeAppService : AppServiceBase, ICourseTypeAppService
    {
        private readonly ICourseTypeService _courseTypeService;

        public CourseTypeAppService(ICourseTypeService courseTypeService, IUnitOfWork uow)
            : base(uow)
        {
            _courseTypeService = courseTypeService;
        }

        public void Dispose()
        {
            _courseTypeService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CourseTypeViewModel> ListAll()
        {
            var types = _courseTypeService.Lists();
            var viewModels = new List<CourseTypeViewModel>();
            foreach (var item in types)
            {
                viewModels.Add(new CourseTypeViewModel
                {
                    CourseTypeId = item.CourseTypeId,
                    Description = item.Description
                });
            }

            return viewModels;
        }
    }
}
