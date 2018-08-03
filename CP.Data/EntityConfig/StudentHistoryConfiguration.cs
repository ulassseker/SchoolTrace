using CP.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CP.Data.EntityConfig
{
    public class StudentHistoryConfiguration : EntityTypeConfiguration<StudentHistory>
    {
        public StudentHistoryConfiguration()
        {
            ToTable("StudentHistory");
            HasKey(x => x.StudentHistoryId);

            HasRequired(x => x.Student)
                .WithMany(x => x.StudentHistory)
                .Map(m => m.MapKey("StudentId"));

            Property(x => x.StudentSituation)
                .IsRequired();

            Property(x => x.RegisterDate)
                .IsRequired();

        }
    }
}
