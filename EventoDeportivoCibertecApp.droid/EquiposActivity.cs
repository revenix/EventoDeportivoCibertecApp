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
    [Activity(Label = "EquiposActivity")]
    public class EquiposActivity : Activity
    {
        Services controller = new Services();
        ListView listEquipo;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Equipos);

            listEquipo = FindViewById<ListView>(Resource.Id.listEquipos);

            string idequipo = Intent.GetStringExtra("idequipo");


            await GetEquipos(int.Parse(idequipo));


        }


        private async Task GetEquipos(int id)
        {
            try
            {
                var dato = await controller.ListaEquipos(id);

                listEquipo.ItemClick += ListEquipo_ItemClick;

                listEquipo.Adapter = new EquiposAdapter(this, dato);

            }
            catch (Exception e)
            {


                Toast.MakeText(this, e.ToString(), ToastLength.Long).Show();

            }
        }

        private void ListEquipo_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var id = e.View.FindViewById<TextView>(Resource.Id.txtidequipo);
            //test error
            Toast.MakeText(this, id.Text, ToastLength.Long).Show();

           var activity2 = new Intent(this, typeof(ParticipanteActivity));

           activity2.PutExtra("idpart", id.Text);

            StartActivity(activity2);

        }
    }
}