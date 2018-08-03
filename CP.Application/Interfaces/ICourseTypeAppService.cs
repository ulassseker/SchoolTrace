using CP.Application.ViewModels.CourseType;
using System;
using System.Collections.Generic;

namespace CP.Application.Interfaces
{
    public interface ICourseTypeAppService : IDisposable
    {
        IEnumerable<CourseTypeViewModel> ListAll();
    }
}
