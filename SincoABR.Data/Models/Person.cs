using System;
using System.Collections.Generic;

namespace SincoABR.Data.Models
{
    public partial class Person
    {
        public Person()
        {
            Assign = new HashSet<Assign>();
            Enroll = new HashSet<Enroll>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? PersonType { get; set; }
        public int? PersonState { get; set; }

        public virtual StatePerson PersonStateNavigation { get; set; }
        public virtual TypePerson PersonTypeNavigation { get; set; }
        public virtual ICollection<Assign> Assign { get; set; }
        public virtual ICollection<Enroll> Enroll { get; set; }
    }
}
