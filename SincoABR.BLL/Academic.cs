using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SincoABR.Data.Models;

namespace SincoABR.BLL
{
    public class Academic
    {
        protected SincoABRContext context;

        public Academic()
        {
            context = new SincoABRContext();
        }

        public Boolean SaveMateria(string Name)
        {
            Course curso = new Course();
            curso.NameCourse = Name;
            context.Course.Add(curso);           
            context.SaveChanges();
            return true;
        }
        public List<Course> CoursesTeacher(int id)
        {
            return (from  cursos in context.Course  join 
                    asignadas in context.Assign  on cursos.IdCourse equals asignadas.CourseId
                    where asignadas.Teacher==id                    
                    select cursos
                    ).ToList();
        }

        public List<Course> CoursesStudent(int id)
        {
            return (from cursos in context.Course
                    join asignadas in context.Enroll on cursos.IdCourse equals asignadas.Course
                    where asignadas.Student == id
                    select cursos
                    ).ToList();
        }

        public List<Course> AllCourses(int id)
        {
            return (from cursos in context.Course
                    join asignadas in context.Assign.Where(x => x.Teacher == id)
                    on cursos.IdCourse equals asignadas.CourseId

                    into FactDesc
                    from fd in FactDesc.DefaultIfEmpty()
                    select cursos
                    ).ToList();

        }
        public Course Course(int id)
        {
            return (from curso in context.Course where curso.IdCourse == id select curso).First();
        }

        public void AsignCourse(Assign datos)
        {
            Assign assign = new Assign();
            assign.CourseId = datos.CourseId;
            assign.Teacher = datos.Teacher;
            context.Assign.Add(assign);
            context.SaveChanges();
           
        }

        public void AsignCourseStudent(Enroll datos)
        {
            Enroll enroll = new Enroll();
            enroll.Course = datos.Course;
            enroll.Student = datos.Student;
            context.Enroll.Add(enroll);
            context.SaveChanges();

        }

        public List<Period> ListPeriod()
        {
            return (from periodo in context.Period
                    select periodo
                    ).ToList();
        }

        public void Calificar(Classmates notas)
        {
            Enroll matriculada = context.Enroll.Where(x=>x.Course==notas.EnrollsNavigation.Course && x.Student == notas.EnrollsNavigation.Student).First();
            Assign asignada = context.Assign.Where(x => x.Teacher == notas.AssignNavigation.Teacher && x.CourseId == notas.AssignNavigation.CourseId).First();

            Classmates classmates = new Classmates()
            {
                Nota = notas.Nota,
                Enrolls=matriculada.Id,
                Assign = asignada.Id,
                Period = notas.Period,
            };

            var datos = context.Classmates.Find(classmates.Assign, classmates.Enrolls, classmates.Period);
            if (datos !=null)
            {
                datos.Nota = notas.Nota;
                context.Classmates.Update(datos);
            }
            else
            {
                context.Classmates.Add(classmates);
            }
            context.SaveChanges();

        }

        public List<Person> teacherCourse(int course)
        {
            return (from  assign in context.Assign
                    join personas in context.Person on assign.Teacher equals personas.Id
                    where assign.CourseId==course
                    select personas
                    ).ToList();
        }
        public List<Report> AllData()
        {
            Report reportes = new Report();
            var data = (from clase in context.Classmates select 
                        new Report()
                        {
                            Docentes =  clase.AssignNavigation.TeacherNavigation.Name+" "+ clase.AssignNavigation.TeacherNavigation.Surname,
                            Nota=clase.Nota+"",
                            Estudiante = clase.EnrollsNavigation.StudentNavigation.Name+" "+ clase.EnrollsNavigation.StudentNavigation.Surname,
                            Periodo = clase.PeriodNavigation.NamePeriod,
                            Asignatura = clase.AssignNavigation.Course.NameCourse
                        }
                        ).ToList();
         
            return data;
            
            //return (
            //from personas in context.Person join 
            //        tiposPersonas in context.TypePerson on personas.PersonType equals tiposPersonas.IdType join
            //from Course in context.Course ///join 
            ////matriculadas in context.Enroll on Course.IdCourse equals matriculadas.Course
            ////join asignadas in context.Assign on Course.
            //select Course
            //).ToList();
        }
    }
}
