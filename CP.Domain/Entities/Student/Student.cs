using CP.Domain.Interfaces.Validation;
using CP.Domain.Validation.StudentValidation;
using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Entities
{
    public class Student : ISelfValidator
    {
        protected Student() { }
        public Student(string name, string cpf, DateTime birthDate, bool active, User user)
        {
            StudentId = Guid.NewGuid();
            Name = name;
            CPF = cpf;
            BirthDate = birthDate;
            RegisterDate = DateTime.Now;
            StudentHistory = new List<StudentHistory>();
            User = user;

            var fiscal = new StudentEligibleForRegistrationValidation();
            ValidationResult = fiscal.Validate(this);
        }
        public Guid StudentId { get; protected set; }
        public string Name { get; protected set; }
        public string CPF { get; protected set; }
        public virtual User User { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public virtual ICollection<StudentHistory> StudentHistory { get; protected set; }
        public ValidationResult ValidationResult { get; private set; }

        public void AddHistory(StudentHistory studentHistory) => StudentHistory.Add(studentHistory);

        public bool IsValid
        {
            get { return ValidationResult.IsValid; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
