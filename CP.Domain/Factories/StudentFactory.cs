using CP.Domain.Entities;
using CP.Domain.ValueObjects;
using System;

namespace CP.Domain.Factories
{
    public class StudentFactory
    {
        public static Student CreateStudentForRegistration(string email, string password, string encryptedPassword, string name, string cpf, DateTime birthDate, bool active)
        {
            var user = new User(email, password, encryptedPassword, UserType.Student);
            var student = new Student(name, cpf, birthDate, active, user);
            student.AddHistory(new StudentHistory(student, StudentSituation.Register));

            return student;
        }
    }
}
