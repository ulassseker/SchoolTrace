using CP.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CP.Data.EntityConfig
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Course");
            HasKey(x => x.CourseId);

            Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(100);

            Property(x => x.RegisterDate)
                .IsRequired();

            Property(x => x.UpdatedDate)
                .IsOptional();

            HasRequired(x => x.CourseType)
             .WithMany(x => x.CourseList)
              .Map(m => m.MapKey("CourseTypeId"));

            Ignore(x => x.ValidationResult);

            ToTable("Course");
        }
    }
}
