using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Classmates
    {
        public int? Id { get; set; }
        public int Enrolls { get; set; }
        public int Assign { get; set; }
        public int? Nota { get; set; }
        public int Period { get; set; }

        public virtual Assign AssignNavigation { get; set; }
        public virtual Enroll EnrollsNavigation { get; set; }
        public virtual Period PeriodNavigation { get; set; }
        

    }
}
