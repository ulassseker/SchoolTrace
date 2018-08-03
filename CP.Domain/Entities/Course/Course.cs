using CP.Domain.Interfaces.Validation;
using CP.Domain.ValueObjects;
using CP.Domain.Validation.CursoValidation;
using System;

namespace CP.Domain.Entities
{
    public class Course : ISelfValidator
    {
        protected Course() { }

        public Course(string name, bool active, CourseType courseType)
        {
            CourseId = Guid.NewGuid();
            Name = name;
            CourseType = courseType;
            Active = active;
            RegisterDate = DateTime.Now;

            var fiscal = new CourseForRegistrationValidation();
            ValidationResult = fiscal.Validate(this);
        }

        public Guid CourseId { get; protected set; }
        public string Name { get; protected set; }
        public bool Active { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
        public DateTime? UpdatedDate { get; protected set; }
        public ValidationResult ValidationResult { get; private set; }
        public virtual CourseType CourseType { get; protected set; }

        public bool IsValid
        {
            get { return ValidationResult.IsValid; }
        }

        public void UpdateCourse(string name, bool active, CourseType courseType)
        {
            Name = name;
            Active = active;
            CourseType = courseType;
            UpdatedDate = DateTime.Now;

            var fiscal = new CourseValidValidation();
            ValidationResult = fiscal.Validate(this);
        }

    }
}
