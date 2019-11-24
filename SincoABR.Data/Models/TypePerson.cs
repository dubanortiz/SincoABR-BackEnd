using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class TypePerson
    {
        public TypePerson()
        {
            Person = new HashSet<Person>();
        }

        public int IdType { get; set; }
        public string NameType { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
