using CP.Application.Interfaces;
using CP.Application.ViewModels.Student;
using System.Web.Mvc;

namespace CP.Presentation.Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }
        // GET: Student
        public ActionResult Index()
        {
            var model = _studentAppService.ListGrid();
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(NewStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _studentAppService.RegisterNewStudent(model);

                if (result.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Erros)
                        ModelState.AddModelError("", item.Message);
                }

            }
            return View(model);
        }

    }
}