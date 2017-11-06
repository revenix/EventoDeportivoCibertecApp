using EDCibertecAppWebApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EDCibertecAppWebApiRest.Controllers
{
    [RoutePrefix("Api")]

    public class EventoController : ApiController
    {

        EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();
        [HttpGet]
        [Route("listaeventos")]
        public IHttpActionResult GetEvento()
        {
            try
            {
                var query = from s in db.sp_ListarEventos()

                            select new Evento()
                            {
                                idevento = s.idevento,
                                nombre_evento = s.nombre_evento,
                                lugar = s.lugar,
                                fecha_inicio = s.fecha_inicio.ToString()
                            };

                return Ok(query.ToList());
                //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
