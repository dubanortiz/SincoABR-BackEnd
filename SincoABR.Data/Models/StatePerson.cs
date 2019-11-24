using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class StatePerson
    {
        public StatePerson()
        {
            Person = new HashSet<Person>();
        }

        public int IdState { get; set; }
        public string NameState { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
