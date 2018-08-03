using CP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Interfaces.Repositories
{
    public interface ICourseTypeRepository : IRepositoryBase<CourseType>
    {
        IEnumerable<CourseType> Listar();
    }
}
