using CP.Domain.Entities;
using CP.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CP.Data.Context
{
    public class CPContext: DbContext
    {
        public CPContext()
            : base("CPContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<CourseType> CourseTypes { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<StudentHistory> StudentHistory { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new CourseTypeConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new StudentHistoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
