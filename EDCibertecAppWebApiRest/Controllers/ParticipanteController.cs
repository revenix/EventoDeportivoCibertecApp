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
    public class ParticipanteController : ApiController
    {
        EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();

        [HttpGet]
        [Route("infoparticipante")]
        public IHttpActionResult GetParticipante(int id)
        {
            try
            {
                var query = from s in db.sp_Participanteinfo(id)

                            select new Participante()
                            {
                                id_participante = s.id_participante,
                                nombres = s.nombres,
                                apellidos = s.apellidos,
                                sexo = s.sexo,
                                valoracion =s.valoracion,
                                nombre = s.nombre
                            };

                return Ok(query.FirstOrDefault());
                //query.FirstOrDefault();

            }
            catch (Exception )
            {
                return null;
            }

        }


        [HttpGet]
        [Route("listaparti")]
        public IHttpActionResult GetParticipantexid(int id)
        {
            try
            {
                var query = from s in db.sp_listaParticipantexEquipo(id)

                            select new Participantelista()
                            {
                                nombre =s.nombre ,
                                puesto =s.puesto,
                                id_participante =s.id_participante,
                                nombres =s.nombres,
                                apellidos =s.apellidos,
                                valoracion =s.valoracion,

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
