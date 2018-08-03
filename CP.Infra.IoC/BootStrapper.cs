using CP.Application;
using CP.Application.Interfaces;
using CP.Domain.Interfaces.Repositories;
using CP.Domain.Interfaces.Services;
using CP.Domain.Services;
using CP.Data.Context;
using CP.Data.Interfaces;
using CP.Data.Repositories;
using CP.Data.UnitOfWork;
using SimpleInjector;

namespace CP.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ICourseTypeAppService, CourseTypeAppService>(Lifestyle.Scoped);
            container.Register<ICourseAppService, CourseAppService>(Lifestyle.Scoped);
            container.Register<IStudentAppService, StudentAppService>(Lifestyle.Scoped);

            container.Register<ICourseTypeService, CourseTypeService>(Lifestyle.Scoped);
            container.Register<ICourseService, CourseService>(Lifestyle.Scoped);
            container.Register<IStudentService, StudentService>(Lifestyle.Scoped);

            container.Register<CPContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, EFUnitOfWork>(Lifestyle.Scoped);


            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);

            container.Register<ICourseRepository, CourseRepository>(Lifestyle.Scoped);
            container.Register<ICourseTypeRepository, CourseTypeRepository>(Lifestyle.Scoped);
            container.Register<IStudentRepository, StudentRepository>(Lifestyle.Scoped);

        }
    }
}