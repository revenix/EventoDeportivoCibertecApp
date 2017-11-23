using Android.Views;
using Android.App;
using Android.OS;
using Android.Widget;
using System;
using EventoDeportivoCibertecApp.portable;

namespace ECibertecApp.droid
{
    [Activity( MainLauncher = true)]
    public class Login : Activity
    {

        EditText txtlogin;
        EditText txtpassword;
        Button btnIngresar;
    
       Services controller = new Services();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            txtlogin = FindViewById<EditText>(Resource.Id.txtlogin);
            txtpassword = FindViewById<EditText>(Resource.Id.txtpassword);

            btnIngresar = FindViewById<Button>(Resource.Id.btnIngresar);

            btnIngresar.Click += BtnIngresar_Click;


        }

        private async void BtnIngresar_Click(object sender, EventArgs e)
        {
            string login = txtlogin.Text;
            string pasword = txtpassword.Text;

            if (!string.IsNullOrEmpty(login) || !string.IsNullOrEmpty(pasword))
            {
                var dato = await controller.LoginUsuario(login, pasword);

                if (dato != null)
                {
                    var tipoUsuario = dato.descripcion;


                    if (tipoUsuario.Equals("Administrador"))
                    {
                        Toast.MakeText(this, "Bienvenido " + dato.nombres, ToastLength.Short).Show();
                        StartActivity(typeof(MainActivity));
                    }
                    else
                    {
                        Toast.MakeText(this, "Bienvenido  " + dato.nombres, ToastLength.Short).Show();
                        StartActivity(typeof(MainActivity));
                    }
                }
                else
                {
                    Toast.MakeText(this, "Usuario Incorrecto ", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Campos vacios", ToastLength.Short).Show();

            }
        }
    }
}