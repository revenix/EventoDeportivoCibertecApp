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
using System.Threading.Tasks;

namespace ECibertecApp.droid
{
    [Activity(Label = "infoEquipo")]
    public class infoEquipo : Activity
    {

        TextView txtNombreEquipo;
        ListView lista_Participante;
        Button btnAtras;
        Services controller = new Services();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.infoEquipo);
            btnAtras = FindViewById<Button>(Resource.Id.btnAtrasInfoEquipo);
            txtNombreEquipo = FindViewById < TextView>(Resource.Id.txtNombreEquipo);
            lista_Participante = FindViewById<ListView>(Resource.Id.listParticipantes);


            btnAtras.Click += BtnAtras_Click;

            string idparticipante = Intent.GetStringExtra("idparticipante");

            var dato = await controller.EquipoInfo(int.Parse(idparticipante));

            if (dato != null)
            {
                txtNombreEquipo.Text = dato.nombre;

                await GetParticipantes(dato.id_equipo);


            }

        }
        private async Task GetParticipantes(int _id)
        {
            var dato = await controller.ListaParticipantes(_id);

            ArrayAdapter array = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, dato.Select(m => m.nombres + " " + m.apellidos).ToArray());

           lista_Participante.Adapter = array;
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        { 
            //back button
            this.Finish();
        }
    }
}