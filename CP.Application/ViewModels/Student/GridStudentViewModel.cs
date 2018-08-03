using System;
using System.ComponentModel.DataAnnotations;

namespace CP.Application.ViewModels.Student
{
    public class GridStudentViewModel
    {
        public Guid StudentId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Situation")]
        public bool Active { get; set; }
    }
}
