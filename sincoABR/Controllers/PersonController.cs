using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SincoABR.Data.Models;
using SincoABR.BLL;

namespace sincoABR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // permite ver los tipos de personas (estudiantes, docentes)
        [HttpGet]
        [Route("TypePerson")]
        public IEnumerable<TypePerson> GetType()
        {
            return new Users().GetTypePerson();
        }
        // permite ver los usuarios del sistema
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Person> GetPeople()
        {
            return new Users().GetPeople();
        }
        //permite ver los datos de un usuario
        [HttpGet]
        [Route("GetSingle/{id}")]
        public Person GetPeopleSIngle([FromRoute]int id)
        {
            return new Users().GetSinglePeople(id);
        }

        //permite crear un usuario
        [HttpPost]
        [Route("create")]
        public ActionResult Post([FromBody] Person value)
        {
            try
            {
                new Users().SaveUser(value);
                return Ok("Registrado");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //Permite la eliminacion de un usuario 
        [HttpPost]
        [Route("delete")]
        public ActionResult Delete([FromBody] Person value)
        {
            try
            {
                new Users().Delete(value);
                return Ok("Registrado");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


    }
}
