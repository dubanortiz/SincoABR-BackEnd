using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Matriculate
    {
        public Matriculate()
        {
            ResultNote = new HashSet<ResultNote>();
        }

        public int Id { get; set; }
        public DateTime? DateMatriculate { get; set; }
        public int? Student { get; set; }
        public int? Teacher { get; set; }
        public int? Course { get; set; }

        public virtual Course CourseNavigation { get; set; }
        public virtual Person StudentNavigation { get; set; }
        public virtual Person TeacherNavigation { get; set; }
        public virtual ICollection<ResultNote> ResultNote { get; set; }
    }
}
