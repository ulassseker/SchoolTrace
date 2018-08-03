using CP.Application.Interfaces;
using CP.Application.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CP.Presentation.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseAppService _courseAppService;
        private readonly ICourseTypeAppService _courseTypeAppService;
        public CourseController(ICourseAppService courseAppService, ICourseTypeAppService courseTypeAppService)
        {
            _courseAppService = courseAppService;
            _courseTypeAppService = courseTypeAppService;
        }

        public ActionResult Index()
        {
            var model = _courseAppService.ListGrid();
            return View(model);
        }

        public ActionResult Register()
        {
            var model = new NewCourseViewModel();
            model.CourseType = FillCourseType();
            model.Active = false;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NewCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _courseAppService.RegisterNewCourse(model);

                if (result.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Erros)
                        ModelState.AddModelError("", item.Message);
                }

            }
            model.CourseType = FillCourseType();
            return View(model);
        }

        public ActionResult Edit(Guid cursoId)
        {
            var model = _courseAppService.GetToEdit(cursoId);
            model.CourseType = FillCourseType();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditionCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _courseAppService.EditCourse(model);

                if (result.IsValid)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Erros)
                        ModelState.AddModelError("", item.Message);
                }

            }
            model.CourseType = FillCourseType();
            return View(model);
        }

        [OutputCache(Duration = 300, VaryByParam = "none")]
        [NonAction]
        private IEnumerable<SelectListItem> FillCourseType()
        {
            return _courseTypeAppService.ListAll()
            .Select(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.CourseTypeId.ToString()
            });
        }




    }
}