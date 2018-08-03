using CP.Domain.Entities;
using CP.Domain.Validation;
using CP.Domain.Validation.Base;
using CP.Domain.Specification.CourseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Validation.CursoValidation
{
    public class CourseValidValidation : FiscalBase<Course>
    {
        public CourseValidValidation()
        {
            //Course Specification
            var courseNome = new NomeEstaValidaSpecification();

            base.AddRule("CourseName", new Rule<Course>(courseNome, "The name must contain between 5 and 50 characters."));
        }
    }
}
