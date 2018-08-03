using CP.Application.Validation;
using CP.Application.ViewModels.Student;
using System;
using System.Collections.Generic;

namespace CP.Application.Interfaces
{
    public interface IStudentAppService : IDisposable
    {
        ValidationAppResult RegisterNewStudent(NewStudentViewModel newStudentVeiwModel);

        IEnumerable<GridStudentViewModel> ListGrid();
    }
}
