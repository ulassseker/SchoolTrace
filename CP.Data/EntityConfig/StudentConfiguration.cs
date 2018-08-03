using CP.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CP.Data.EntityConfig
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Student");
            HasKey(x => x.StudentId);

            Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.CPF)
             .HasMaxLength(30)
             .IsRequired();

            HasRequired(x => x.User)
                .WithMany(x => x.StudentUsers)
                .Map(m => m.MapKey("UserId"));

            Property(x => x.RegisterDate)
               .IsRequired();

            Property(x => x.BirthDate)
                .IsRequired();

            Property(x => x.UpdateDate)
                .IsOptional();

            Ignore(x => x.ValidationResult);
        }
    }
}
