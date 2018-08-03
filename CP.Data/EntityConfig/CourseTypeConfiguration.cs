using CP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Data.EntityConfig
{
    public class CourseTypeConfiguration : EntityTypeConfiguration<CourseType>
    {
        public CourseTypeConfiguration()
        {
            HasKey(x => x.CourseTypeId);

            Property(x => x.Description)
              .IsRequired()
              .HasMaxLength(100);
        }
    }
}
