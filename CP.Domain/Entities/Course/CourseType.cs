using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Entities
{
    public class CourseType
    {
        protected CourseType() { }
        public CourseType(string description, bool active)
        {
            CourseTypeId = Guid.NewGuid();
            Description = description;
            Active = active;
        }

        public Guid CourseTypeId { get; protected set; }
        public string Description { get; protected set; }
        public bool Active { get; protected set; }
        public virtual ICollection<Course> CourseList { get; protected set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
