
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventoDeportivoCibertecApp.portable
{
    public class Services
    {
        HttpClient http = new HttpClient();
        Usuario usuario = new Usuario();

       // List<Usuario> listUsuarios = new List<Usuario>();
       private const string url = "http://eventodeportivocibertec.azurewebsites.net/api/";

        public async Task<Usuario> LoginUsuario(string _usuario ,string _clave)
        {
            var login =$"usuariologin?usuario={_usuario}&clave={_clave}";

            var uri = url + login;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var usuario = JsonConvert.DeserializeObject<Usuario>(contenido);
            return usuario;

        }

        public async Task<Participante> ParticipanteInfo(int _id)
        {
            var par = $"infoparticipante?id={_id}";

            var uri = url + par;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var participante = JsonConvert.DeserializeObject<Participante>(contenido);
            return participante;

        }
        public async Task<Equipoxparticipante> EquipoInfo(int _id)
        {
            var par = $"infoequipo?id={_id}";

            var uri = url + par;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var participante = JsonConvert.DeserializeObject<Equipoxparticipante>(contenido);
            return participante;

        }
        public async Task<List<Evento>> ListEventos()
        {
            var par = $"listaeventos";

            var uri = url + par;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var evento = JsonConvert.DeserializeObject<List<Evento>>(contenido);
            return evento;

        }
        public async Task<List<Participantelista>> ListParticipantes()
        {
            var par = $"listaparticipantes";

            var uri = url + par;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var evento = JsonConvert.DeserializeObject<List<Participantelista>>(contenido);
            return evento;

        }

        public async Task<List< Modalidad>> ListaModalidad (int id)
        {
            var link = $"listamod?id={id}";
            var uri = url + link;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var lista = JsonConvert.DeserializeObject<List< Modalidad>>(contenido);
            return lista;

        }
        public async Task<List<Modalidad>> ListModalidad()
        {
            var link = $"listamodalidad";
            var uri = url + link;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var lista = JsonConvert.DeserializeObject<List<Modalidad>>(contenido);
            return lista;
        }
        public async Task<List<Equipo>> ListaEquipos(int id)
        {
            var link = $"listaequipos?id={id}";
            var uri = url + link;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var lista = JsonConvert.DeserializeObject<List<Equipo>>(contenido);
            return lista;

        }

        public async Task<List<Participantelista>> ListaParticipantes(int id)
        {
            var link = $"listaparti?id={id}";
            var uri = url + link;
            var respuestaService = await http.GetAsync(uri);
            var contenido = respuestaService.Content.ReadAsStringAsync().Result.ToString();
            var lista = JsonConvert.DeserializeObject<List<Participantelista>>(contenido);
            return lista;

        }

        /*

                public async Task<List<Usuario>> GetUsuarios()
                {

                    var response = await http.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStringAsync();
                        listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

                    }

                    return listUsuarios;

                }
                /*
                public async Task<Usuario> GetUsuariosId(int id)
                {

                    var getUrl = $"{url}/{id}";

                    var response = await http.GetAsync(getUrl);

                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStringAsync();
                        usuario = JsonConvert.DeserializeObject<Usuario>(content);
                        return usuario;

                    }
                    else
                    {
                        return null;
                    }


                }
                public async Task<string> RegistrarUsuario(int id, string login , string contraseña, int idrol)
                {

                    var url = String.Format("http://eventodeportivocibertec.azurewebsites.net/api/Usuario?id={0}&login={1}&contraseña={2}&idrol={3}",id, login ,contraseña,idrol );
                    var http = new HttpClient();
                    var response = await http.PutAsync(url, null);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject(content).ToString();
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }

                public async Task<Usuario> DeleteUsuario(int id)
                {

                    var deleteUrl = $"{url}/{id}";

                    var response = http.DeleteAsync(deleteUrl);

                    var content = await response.Result.Content.ReadAsStringAsync();

                    if (response.IsCompleted)
                    {

                        usuario = JsonConvert.DeserializeObject<Usuario>(content);
                        return usuario;

                    }
                    else
                    {
                        return null;
                    }


                }
                /*
                public async Task<String> PostUsuario(Usuario usu)
                {

                    var serializer = JsonConvert.SerializeObject(usu);

                    var content = new StringContent(serializer, Encoding.UTF8, "application/json");

                    var response = await http.PostAsync(url, content);

                    string msg = (response.IsSuccessStatusCode) ? "Registrado" : "Error";

                    return msg;

                }
                */



    }
}
