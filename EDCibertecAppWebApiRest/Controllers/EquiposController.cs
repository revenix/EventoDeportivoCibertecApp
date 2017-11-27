using EDCibertecAppWebApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;

namespace EDCibertecAppWebApiRest.Controllers
{
    [RoutePrefix("Api")]
  
   
    public class EquiposController : ApiController
    {
        EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();

        [HttpGet]

        [Route("listaequipos")]
        public IHttpActionResult GetEquipos(int id)
        {
            try
            {
                var query = from s in db.sp_listaEquipos(id)

                            select new Equipo()
                            {
                               num_ficha =s.num_ficha,
                               id_equipo =s.id_equipo,
                               nombre =s.nombre
                            };

                return Ok(query.ToList());
                //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }



        [HttpGet]

        [Route("infoequipo")]
        public IHttpActionResult GetinfoEquipo(int id)
        {
            try
            {
                var query = from s in db.sp_equipoxparticipante(id)

                            select new Equipoxparticipante()
                            {
                                id_equipo = s.id_equipo,
                                nombre = s.nombre,
                               colorUniforme=s.color_uniforme

                            };

                return Ok(query.FirstOrDefault());
                //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
