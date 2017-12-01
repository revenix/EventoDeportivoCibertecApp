using EDCibertecAppWebApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Http;

namespace EDCibertecAppWebApiRest.Controllers
{
    [RoutePrefix("Api")]
  
    public class ModalidadesController : ApiController
    {
        EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();



        [HttpGet]
        [Route("listamod")]
        public IHttpActionResult GetModalidades(int id)
        {
            try
            {
                var query = from s in db.sp_listaModalidades(id)

                            select new Modalidad()
                            {
                                id_modalidad = s.id_modalidad,
                                id_disciplina =s.id_disciplina ,
                                deporte = s.deporte,
                                id_categoria =s.id_categoria,
                                categoria = s.categoria
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
        [Route("listamodalidad")]
        public IHttpActionResult GetModalidad()
        {
            try
            {
                var query = from s in db.sp_listaModalidad()

                            select new Modalidad()
                            {
                                id_modalidad = s.id_modalidad,
                                id_disciplina = s.id_disciplina,
                                deporte = s.deporte,
                                id_categoria = s.id_categoria,
                                categoria = s.categoria
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
