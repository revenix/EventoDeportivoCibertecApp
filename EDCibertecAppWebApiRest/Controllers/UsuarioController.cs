using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EDCibertecAppWebApiRest.Models;

namespace EDCibertecAppWebApiRest.Controllers
{
    public class UsuarioController : ApiController
    {
        EventoDeportivoCibertecEntities db = new EventoDeportivoCibertecEntities();
        [HttpGet]

        public List<Usuario> GetUsuarios()
        {
            var consulta = (from s in db.sp_listaUsuarios()
                            select new Usuario
                            {
                                idusuario = s.idusuario,
                                login = s.login,
                                contraseña = s.contraseña,
                                idrol = s.idrol,
                              
                            }).ToList();

            return consulta;
        }

        [HttpPost]
        
        public string PostBuscaUsuario(int id)
        {
            try
            {
                var query = db.sp_BuscaUsuario(id);
              
                return query.ToString();

            }
            catch (Exception ex)
            {
                return BadRequest().ToString();
            }
        }

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
        [HttpPost]

     
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
