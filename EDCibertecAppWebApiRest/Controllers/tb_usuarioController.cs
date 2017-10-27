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
    public class tb_usuarioController : ApiController
    {
        private EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();

        // GET: api/tb_usuario
        public IQueryable<tb_usuario> Gettb_usuario()
        {
            return db.tb_usuario;
        }


        // GET: api/tb_usuario/5
        [ResponseType(typeof(tb_usuario))]
        public async Task<IHttpActionResult> Gettb_usuario(int id)
        {
            tb_usuario tb_usuario = await db.tb_usuario.FindAsync(id);
            if (tb_usuario == null)
            {
                return NotFound();
            }

            return Ok(tb_usuario);
        }

        // PUT: api/tb_usuario/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttb_usuario(int id, tb_usuario tb_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_usuario.idusuario)
            {
                return BadRequest();
            }

            db.Entry(tb_usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_usuarioExists(id))
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

        // POST: api/tb_usuario
        [ResponseType(typeof(tb_usuario))]
        public async Task<IHttpActionResult> Posttb_usuario(tb_usuario tb_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_usuario.Add(tb_usuario);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tb_usuarioExists(tb_usuario.idusuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tb_usuario.idusuario }, tb_usuario);
        }

        // DELETE: api/tb_usuario/5
        [ResponseType(typeof(tb_usuario))]
        public async Task<IHttpActionResult> Deletetb_usuario(int id)
        {
            tb_usuario tb_usuario = await db.tb_usuario.FindAsync(id);
            if (tb_usuario == null)
            {
                return NotFound();
            }

            db.tb_usuario.Remove(tb_usuario);
            await db.SaveChangesAsync();

            return Ok(tb_usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_usuarioExists(int id)
        {
            return db.tb_usuario.Count(e => e.idusuario == id) > 0;
        }
    }
}