using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Enroll
    {
        public Enroll()
        {
            Classmates = new HashSet<Classmates>();
        }

        public int Id { get; set; }
        public int Course { get; set; }
        public int Student { get; set; }

        public virtual Course CourseNavigation { get; set; }
        public virtual Person StudentNavigation { get; set; }
        public virtual ICollection<Classmates> Classmates { get; set; }
    }
}
