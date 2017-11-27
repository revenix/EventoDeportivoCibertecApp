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

    public class UsuarioController : ApiController
    {
        EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();

      /* [HttpGet]
        public IHttpActionResult GetUsuarios()
        {
            var consulta = from s in db.sp_listaUsuarios()
                            select new Usuario
                            {
                              nombres 

                            };

            return Ok(consulta);
        }
        */

        [HttpGet]
        [Route("usuariologin")]
        public IHttpActionResult GetUsuario(string usuario , string clave)
        {
            try
            {
                var query = from u in db.sp_login(usuario, clave)

                            select new Usuario()
                            {
                                id_participante = u.id_participante,
                                nombres = u.nombres,
                                apellidos = u.apellidos,
                                id_perfil = u.id_perfil,
                                descripcion = u.descripcion
                            };

                return Ok(query.FirstOrDefault());
                    //query.FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }

        }

        /*
        [HttpPost]

        public string PostRegistroUsuario(int id, string login, string contraseña, int idrol)
        {
            try
            {
                var query = db.sp_RegistrarUsuarios(id, login, contraseña, idrol);

                return query.ToString();
            }
            catch (Exception ex)
            {
                return BadRequest().ToString();
            }
        }

       // [HttpPost]
        /*  [HttpPut]
          public IHttpActionResult UpdateCliente(int id, string dni, string nom, string ape, int t, string Ap, int estado)
          {
              try
              {
                  var query = db.SP_ACTUALIZAR_CLIENTE(id, dni, nom, ape, t, Ap, estado);
                  return Ok("Actualizado Correctamente");
              }
              catch (Exception ex)
              {
                  return BadRequest();
              }
          }
          */
    
    }
}
