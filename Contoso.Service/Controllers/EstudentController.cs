using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*1 Agregando Using*/
using Microsoft.AspNetCore.Mvc.Routing;
using Contoso.Models.Entities;
using Contoso.DAL.Repos.Interfaces;//Esto para poder hacer la inyeccion
using Microsoft.EntityFrameworkCore;



namespace Contoso.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudentController : ControllerBase
    {

        /*2 Se define Variable IRepoStudent la inyeccion de dependencia se aplica en el constructor*/

        private IReportStudent Repo { get; set; }
        /*3*/
        public EstudentController(IReportStudent repo)
        {
            Repo = repo;
        }
        // GET: api/Estudent
        [HttpGet]
        //  public IEnumerable<string> Get()/*originalmente estaba asi pero como daba error el getall*/
        public IActionResult Get()/*Se cambia por IEnumerable*/
        {
            //return new string[] { "value1", "value2" };
            /*4*/
            return Ok(Repo.GetAll());
        }

        // GET: api/Estudent/5
        [HttpGet("{id}", Name = "Get")]
        //public string Get(int id)/*Originalmente estaba asi pero se cambia
        public IActionResult Get(int id)
        {
            //return "value";
            return Ok(Repo.Find(id));
        }

        // POST: api/Estudent
        [HttpPost]
        // public void Post([FromBody] string value)
        public IActionResult Post([FromBody] Student estudiante)
        {
            Repo.Add(estudiante);
            return Created(HttpContext.Request.Host + Request.Path + "/" + estudiante.Id, estudiante);
        }

        // PUT: api/Estudent/5
        [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        public IActionResult Put(int id, [FromBody] Student estudiantemod)
        {
            /*No habia nada*/
            /*Lo primero es para saber si modificas entonces hay que ir a buscarlo
             * /*porque puede ser que lo hayan eliminado*/
            var estudiante = Repo.Find(id);
            if (estudiante != null)
            {
                estudiante.Nombres = estudiantemod.Nombres;
                estudiante.Apellidos = estudiantemod.Apellidos;
                estudiante.Edad = estudiantemod.Edad;
                estudiante.UsuarioModificacion = estudiantemod.UsuarioModificacion;
                estudiante.FechaModificacion = DateTime.Now;
                Repo.Update(estudiante);
                /*Este created aplica a todo como a crear como a modificar*/
                return Created(HttpContext.Request.Host + Request.Path + "/" + estudiantemod.Id, estudiantemod);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        //public void Delete(int id)
        public IActionResult Delete(int id)
        {
            var estudiante = Repo.Find(id);
            if (estudiante != null)
            {
                Repo.Delete(estudiante);
                return NoContent();
            }
            /*  else
              {*/
            return NotFound();
            //}
        }
    }
}
