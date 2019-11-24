using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SincoABR.Data.Models;

namespace SincoABR.BLL
{
    public class Users
    {
        protected SincoABRContext context;

        public Users()
        {
            context = new SincoABRContext(); 
        }
        //Scaffold-DbContext "Server=localhost;Database=SincoABR;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f
        public List<TypePerson> GetTypePerson()
        {
            return ( from type in  context.TypePerson select new TypePerson{IdType=type.IdType, NameType=type.NameType }).ToList();
        }
        public List<Person> GetPeople()
        {
            return  (from person in context.Person where person.PersonState==0 select  new Person 
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                PersonTypeNavigation = person.PersonTypeNavigation,
                PersonStateNavigation = person.PersonStateNavigation
            }  ).ToList();
        }

        public List<Person> GetTeachers()
        {
            return (from person in context.Person
                    where person.PersonState == 0 && person.PersonType == 0
                    select new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        Surname = person.Surname,
                        PersonTypeNavigation = person.PersonTypeNavigation,
                        PersonStateNavigation = person.PersonStateNavigation
                    }).ToList();
        }
        public List<Person> GetStudent()
        {
            return (from person in context.Person
                    where person.PersonState == 0 && person.PersonType == 1
                    select new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        Surname = person.Surname,
                        PersonTypeNavigation = person.PersonTypeNavigation,
                        PersonStateNavigation = person.PersonStateNavigation
                    }).ToList();
        }

        public Person GetSinglePeople(int id)
        {
            return (from person in context.Person where person.Id.Equals(id)
                    select new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        Surname = person.Surname,
                        PersonTypeNavigation = person.PersonTypeNavigation,
                        PersonStateNavigation = person.PersonStateNavigation
                    }).ToList()[0];
        }
        public Boolean SaveUser(Person person)
        {
            Person persona = context.Person.Find(person.Id);
            if (persona == null)
            {
                context.Person.Add(person);               
            }
            else
            {
                persona.Name= person.Name;
                persona.Surname = person.Surname;
                persona.PersonState = 0;
                context.Person.Update(persona);              
            }
            context.SaveChanges();
            return true;
        }
        public Boolean Delete(Person person)
        {
            Person persona = context.Person.Find(person.Id);
            persona.PersonState = 1;
            context.Person.Update(persona);
            context.SaveChanges();
            return true;
        }
    }
}
