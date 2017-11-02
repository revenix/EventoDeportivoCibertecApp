using Android.App;
using Android.Widget;
using Android.OS;

using EventoDeportivoCibertecApp.portable;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EventoDeportivoCibertecApp.droid
{
    [Activity(Label = "EventoDeportivoCibertecApp.droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        EditText txtID;
        ListView listUsuarios;
        Button btnBuscar, btnEliminar, btnRegistrar;

        Services controller = new Services();
        Usuario usuario = new Usuario();


        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
          SetContentView (Resource.Layout.Main);


            txtID = FindViewById<EditText>(Resource.Id.txtID);

            listUsuarios = FindViewById<ListView>(Resource.Id.listUsuarios);
            btnBuscar = FindViewById<Button>(Resource.Id.btnBuscar);
            btnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);
            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);


           //eventos

            btnRegistrar.Click += delegate {
                StartActivity(typeof(RegistroActivity));
            };

            btnBuscar.Click += BtnBuscar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            //

            await GetUsuarios();

        }

        private async Task GetUsuarios()
        {
            try
            {
                var dato = await controller.GetUsuarios();


                ArrayAdapter array = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, dato.Select(m => m.login).ToArray());

                listUsuarios.Adapter = array;
            }
            catch (System.Exception e)
            {
                Toast.MakeText(this, e.ToString() , ToastLength.Long).Show();
              //  Console.WriteLine(e.ToString());
               // Console.WriteLine("listo");
            }
            
        }


        private async void BtnEliminar_Click(object sender, System.EventArgs e)
        {
            string mensaje = null;

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                var id = int.Parse(txtID.Text);

                usuario = await controller.DeleteUsuario(id);

                mensaje = (usuario != null) ? usuario.login + " ha sido eliminado" : "Error al eliminar";

                Toast.MakeText(this, mensaje, ToastLength.Long).Show();

                await GetUsuarios();
            }
        }

        private async  void BtnBuscar_Click(object sender, System.EventArgs e)
        {
            string mensaje = null;

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                var id = int.Parse(txtID.Text);

                usuario = await controller.GetUsuariosId(id);

                mensaje = (usuario != null) ? "Hola: " + usuario.login : " Dato no encontrado";

                Toast.MakeText(this, mensaje, ToastLength.Long).Show();
            }
        }
    }
}

