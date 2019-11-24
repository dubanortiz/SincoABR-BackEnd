using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            Assign = new HashSet<Assign>();
            Enroll = new HashSet<Enroll>();
        }

        public int IdCourse { get; set; }
        public string NameCourse { get; set; }

        public virtual ICollection<Assign> Assign { get; set; }
        public virtual ICollection<Enroll> Enroll { get; set; }
    }
}
