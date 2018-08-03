using CP.Domain.Entities;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace CP.Domain.Services
{
    public class CourseTypeService : ICourseTypeService
    {
        private readonly ICourseTypeRepository _tipoCursoRepository;
        public CourseTypeService(ICourseTypeRepository tipoCursoRepository)
        {
            _tipoCursoRepository = tipoCursoRepository;
        }
        public IEnumerable<CourseType> GetAll()
        {
            return _tipoCursoRepository.GetAll();
        }
        public CourseType GetById(Guid id)
        {
            return _tipoCursoRepository.GetById(id);
        }
        public IEnumerable<CourseType> Lists()
        {
            return _tipoCursoRepository.Listar();
        }
        public void Dispose()
        {
            _tipoCursoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
