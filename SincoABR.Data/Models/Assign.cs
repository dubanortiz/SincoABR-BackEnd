using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Assign
    {
        public Assign()
        {
            Classmates = new HashSet<Classmates>();
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int Teacher { get; set; }

        public virtual Course Course { get; set; }
        public virtual Person TeacherNavigation { get; set; }
        public virtual ICollection<Classmates> Classmates { get; set; }
    }
}
