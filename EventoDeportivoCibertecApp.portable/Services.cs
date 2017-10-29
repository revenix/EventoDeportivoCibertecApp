﻿using Newtonsoft.Json;
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
        List<Usuario> listUsuarios = new List<Usuario>();

        //En ésta url agregar el link tu servicio web
        const string url = "http://eventodeportivocibertec.azurewebsites.net/api/usuarios";

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

        public async Task<String> PostUsuario(Usuario usu)
        {

            var serializer = JsonConvert.SerializeObject(usu);

            var content = new StringContent(serializer, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(url, content);

            string msg = (response.IsSuccessStatusCode) ? "Registrado" : "Error";

            return msg;

        }




    }
}