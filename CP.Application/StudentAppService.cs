using CP.Application.Interfaces;
using CP.Application.Validation;
using CP.Application.ViewModels.Student;
using CP.Domain.Factories;
using CP.Domain.Interfaces.Services;
using CP.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.Infra.Common.Security;
using CP.Infra.Common.HelperTools;

namespace CP.Application
{
    public class StudentAppService : AppServiceBase, IStudentAppService
    {
        private readonly IStudentService _studentService;

        public StudentAppService(IStudentService studentService, IUnitOfWork uow)
            : base(uow)
        {
            _studentService = studentService;
        }
        public ValidationAppResult RegisterNewStudent(NewStudentViewModel newStudentVeiwModel)
        {
            BeginTransaction();

            var student = StudentFactory.CreateStudentForRegistration(newStudentVeiwModel.Email, newStudentVeiwModel.Password, EncryptHelper.Encrypt(newStudentVeiwModel.Password), newStudentVeiwModel.Name, CharacterHelper.SomenteNumeros(newStudentVeiwModel.CPF), newStudentVeiwModel.DateOfBirth, newStudentVeiwModel.Active);

            var resultValidation = DomainToApplicationResult(_studentService.AddNewStudent(student));

            if (resultValidation.IsValid)
                Commit();

            return resultValidation;
        }

        public IEnumerable<GridStudentViewModel> ListGrid()
        {
            var courses = _studentService.GetGrid();
            var viewModels = new List<GridStudentViewModel>();
            foreach (var item in courses)
            {
                viewModels.Add(new GridStudentViewModel
                {
                    StudentId = item.StudentId,
                    Name = item.Name,
                    CPF = item.CPF,
                    DateOfBirth = item.BirthDate,
                    Email = item.User.Email,
                    Active = item.User.Active
                });
            }

            return viewModels;
        }

        public void Dispose()
        {
            _studentService.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }
}
