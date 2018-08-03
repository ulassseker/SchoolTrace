using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CP.Domain.Entities
{
    public class User
    {
        protected User() { }
        public User(string email, string password, string encryptedPassword, UserType userType)
        {
            UserId = Guid.NewGuid();
            Email = email;
            Password = password;
            EncryptedPassword = encryptedPassword;
            UserType = userType;
            RegisterDate = DateTime.Now;
        }
        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string EncryptedPassword { get; protected set; }
        public bool Active { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
        public UserType UserType { get; protected set; }
        public ICollection<Student> StudentUsers { get; protected set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
