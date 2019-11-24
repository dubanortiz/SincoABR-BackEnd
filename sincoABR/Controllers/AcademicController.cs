using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SincoABR.BLL;
using SincoABR.Data.Models;
namespace sincoABR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        // permite la creacion de materias
        [Route("CreateMateria")]
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            try
            {
                new Academic().SaveMateria(value);
                return Ok("Registrado");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //permite obtener de los cursos que tiene asignados un profesor
        [HttpGet]
        [Route("teacher/{id}")]
        public List<Course> GetCourses([FromRoute]int id)
        {
            return new Academic().CoursesTeacher(id);
        }

        //permite obtener de los cursos matriculados de un usuario
        [HttpGet]
        [Route("Student/{id}")]
        public List<Course> GetCoursesEstudent([FromRoute]int id)
        {
            return new Academic().CoursesStudent(id);
        }
        //permite optener todos las materias existentes
        [HttpGet]
        [Route("missing/{id}")]
        public List<Course> GetCoursesMissing([FromRoute]int id)
        {
            return new Academic().AllCourses(id);
        }

        //permite asignar curso a Docente
        [HttpPost]
        [Route("Asignar")]
        public ActionResult Asignar([FromBody]Assign course)
        {
            try
            {
                new Academic().AsignCourse(course);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //permite matricular curso estudiante
        [HttpPost]
        [Route("AsignarCourseStudent")]
        public ActionResult AsignarCourseStudent([FromBody]Enroll course)
        {
            try
            {
                new Academic().AsignCourseStudent(course);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //permite ver periodos
        [HttpGet]
        [Route("periodos")]
        public List<Period> GetPeriodos()
        {
            return new Academic().ListPeriod();
        }

        //permite asignar una calificacion 
        [HttpPost]
        [Route("Calificar")]
        public ActionResult Calificar([FromBody]Classmates course)
        {
            try
            {
                new Academic().Calificar(course);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        //permite ver los profesores de una materia
        [HttpGet]
        [Route("TeachersCourse/{id}")]
        public List<Person> TeachersCourse([FromRoute]int id)
        {
            return new Academic().teacherCourse(id);
        }
        //Permite optener los datos para generar un reporte
        [HttpGet]
        [Route("Alldata")]
        public List<Report> AllData()
        {
            return new Academic().AllData();
        }

    }
}
