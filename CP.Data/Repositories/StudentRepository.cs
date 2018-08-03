using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CP.Data.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(CPContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<Student> GetGrid()
        {
            return DbSet
             .Include("User")
             .AsNoTracking()
             .ToList();

        }

        public Student GetByCPF(string cpf)
        {
            return DbSet.FirstOrDefault(x => x.CPF == cpf);
        }

        public Student GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(x => x.User.Email == email);
        }
    }
}
