
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CP.Application.ViewModels.Course
{
    public class NewCourseViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "The name field is required")]
        [MaxLength(50, ErrorMessage = "Field {0} must be a maximum of {1} characters")]
        [MinLength(5, ErrorMessage = "Field {0} must be a minimum of {1} characters")]
        public string Name { get; set; }
        [Display(Name = "Situation")]
        public bool Active { get; set; }
        [Display(Name = "Type of course")]
        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")]
        [Required(ErrorMessage = "Choose a Course Type")]
        public Guid CourseTypeId { get; set; }
        public IEnumerable<SelectListItem> CourseType { get; set; }
    }
}
