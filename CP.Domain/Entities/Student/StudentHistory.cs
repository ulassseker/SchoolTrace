using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Entities
{
    public class StudentHistory
    {
        protected StudentHistory() { }
        public StudentHistory(Student student, StudentSituation studentSituation)
        {
            StudentHistoryId = Guid.NewGuid();
            Student = student;
            StudentSituation = studentSituation;
            RegisterDate = DateTime.Now;
        }
        public Guid StudentHistoryId { get; protected set; }
        public virtual Student Student { get; protected set; }
        public StudentSituation StudentSituation { get; protected set; }
        public DateTime RegisterDate { get; protected set; }


        public override string ToString()
        {
            return StudentSituation.ToString();
        }
    }
}
