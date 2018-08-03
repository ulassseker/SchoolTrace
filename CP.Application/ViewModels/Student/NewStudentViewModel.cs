using System;
using System.ComponentModel.DataAnnotations;

namespace CP.Application.ViewModels.Student
{
    public class NewStudentViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Field {0} is required")]
        [MaxLength(50, ErrorMessage = "Field {0} must be a maximum of {1} characters")]
        [MinLength(3, ErrorMessage = "Field {0} must be a minimum of {1} characters")]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string CPF { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Field {0} is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Field {0} is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Field {0} is required")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Field {0} must be a maximum of {1} characters")]
        [MinLength(6, ErrorMessage = "Field {0} must be a minimum of {1} characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords are not the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Situation")]
        public bool Active { get; set; }
    }
}
