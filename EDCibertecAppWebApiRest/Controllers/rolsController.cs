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
using EDCibertecAppWebApiRest;

namespace EDCibertecAppWebApiRest.Controllers
{
    public class rolsController : ApiController
    {
        private EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();

        // GET: api/rols
        public IQueryable<rol> Getrols()
        {
            return db.rols;
        }

        // GET: api/rols/5
        [ResponseType(typeof(rol))]
        public async Task<IHttpActionResult> Getrol(int id)
        {
            rol rol = await db.rols.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        // PUT: api/rols/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putrol(int id, rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rol.idrol)
            {
                return BadRequest();
            }

            db.Entry(rol).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rolExists(id))
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

        // POST: api/rols
        [ResponseType(typeof(rol))]
        public async Task<IHttpActionResult> Postrol(rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.rols.Add(rol);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (rolExists(rol.idrol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rol.idrol }, rol);
        }

        // DELETE: api/rols/5
        [ResponseType(typeof(rol))]
        public async Task<IHttpActionResult> Deleterol(int id)
        {
            rol rol = await db.rols.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            db.rols.Remove(rol);
            await db.SaveChangesAsync();

            return Ok(rol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool rolExists(int id)
        {
            return db.rols.Count(e => e.idrol == id) > 0;
        }
    }
}