using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using EventoDeportivoCibertecApp.portable;


namespace EventoDeportivoCibertecApp.droid
{
    [Activity(Label = "RegistroActivity")]
    public class RegistroActivity : Activity
    {
        EditText txtId, txtLogin, txtContraseña,txtidrol;
     
        Button btnRegistrar;

        Services controller = new Services();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registro);

            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtLogin = FindViewById<EditText>(Resource.Id.txtLogin);
            txtContraseña = FindViewById<EditText>(Resource.Id.txtContraseña);
            txtidrol = FindViewById<EditText>(Resource.Id.txtIdRol);
            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrarUsuario);

            btnRegistrar.Click += BtnRegistrar_Click;

        }

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string respuesta;

            if (!string.IsNullOrEmpty(txtId.Text) || !string.IsNullOrEmpty(txtLogin.Text) || !string.IsNullOrEmpty(txtContraseña.Text) || !string.IsNullOrEmpty(txtidrol.Text))
            {

              var  idusuario = int.Parse(txtId.Text);
              var  login = txtLogin.Text;
              var  contraseña = txtContraseña.Text;
               var idrol = int.Parse(txtidrol.Text);
               
                respuesta = await controller.RegistrarUsuario(idusuario , login, contraseña, idrol);

                //Llamamos a nuestro activity Principal (La vieja confiable)
                StartActivity(typeof(MainActivity));

            }
            else
            {
                respuesta = "completar campos vacios";
            }

            Toast.MakeText(this, respuesta, ToastLength.Long).Show();
        }
    }
}