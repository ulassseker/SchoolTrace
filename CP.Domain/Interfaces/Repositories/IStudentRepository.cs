using CP.Domain.Entities;
using System.Collections.Generic;

namespace CP.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        Student GetByCPF(string cpf);
        Student GetByEmail(string email);
        IEnumerable<Student> GetGrid();
    }
}
