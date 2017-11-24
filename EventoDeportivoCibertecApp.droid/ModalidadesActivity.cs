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
using System.Threading.Tasks;
using EventoDeportivoCibertecApp.portable;

namespace EventoDeportivoCibertecApp.droid
{
    [Activity(Label = "ModalidadesActivity")]
    public class ModalidadesActivity : Activity
    {
        Services controller = new Services();
        ListView listModalidad;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Modalidades);

            listModalidad = FindViewById<ListView>(Resource.Id.listModalidades);

            string idmodalidad = Intent.GetStringExtra("idmodalidad");
            Toast.MakeText(this, idmodalidad, ToastLength.Long).Show();

            await GetModalidades(int.Parse(idmodalidad));

            
        }

        private async Task GetModalidades( int id)
        {
            try
            {
                var dato = await controller.ListaModalidad(id);

                listModalidad.ItemClick += ListModalidad_ItemClick;

                listModalidad.Adapter = new ModalidadesAdapter(this, dato);

            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.ToString(), ToastLength.Long).Show();
            }
        }

        private void ListModalidad_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var id = e.View.FindViewById<TextView>(Resource.Id.txtidparticipante);


            Toast.MakeText(this, id.Text, ToastLength.Long).Show();

            var activity2 = new Intent(this, typeof(InfoParticipanteActivity));

            activity2.PutExtra("idparticipante", id.Text);

           StartActivity(activity2);

        }
    }
}