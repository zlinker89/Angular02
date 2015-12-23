using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Angular02.Models;
using Angular02.DTO;

namespace Angular02.Controllers
{
    public class PersonaController : ApiController
    {
        private ConsecionarioEntities db = new ConsecionarioEntities();

        // GET api/Persona
        public IQueryable<PersonaDTO> GetPersona()
        {
            var personas = from p in db.Persona
                           select new PersonaDTO()
                           {
                               idpersona = p.idpersona,
                               nombre = p.nombre,
                               apellido = p.apellido,
                               tdocumento = p.tdocumento,
                               docmento = p.docmento,
                               fecha_nacimiento = p.fecha_nacimiento

                           };
            return personas;
        }

        // GET api/Persona/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(long id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT api/Persona/5
        public async Task<IHttpActionResult> PutPersona(long id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.idpersona)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Persona
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(persona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persona.idpersona }, persona);
        }

        // DELETE api/Persona/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(long id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Persona.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(long id)
        {
            return db.Persona.Count(e => e.idpersona == id) > 0;
        }
    }
}