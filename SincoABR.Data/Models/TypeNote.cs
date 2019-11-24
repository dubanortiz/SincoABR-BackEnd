using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class TypeNote
    {
        public TypeNote()
        {
            ResultNote = new HashSet<ResultNote>();
        }

        public int IdType { get; set; }
        public string NameType { get; set; }

        public virtual ICollection<ResultNote> ResultNote { get; set; }
    }
}
