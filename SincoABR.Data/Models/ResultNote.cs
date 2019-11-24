using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class ResultNote
    {
        public int Matriculate { get; set; }
        public int Period { get; set; }
        public double? Note { get; set; }
        public int NoteType { get; set; }

        public virtual Matriculate MatriculateNavigation { get; set; }
        public virtual TypeNote NoteTypeNavigation { get; set; }
        public virtual Period PeriodNavigation { get; set; }
    }
}
