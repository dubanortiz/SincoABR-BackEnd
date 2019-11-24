using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Period
    {
        public Period()
        {
            Classmates = new HashSet<Classmates>();
        }

        public int IdPeriod { get; set; }
        public string NamePeriod { get; set; }

        public virtual ICollection<Classmates> Classmates { get; set; }
    }
}
