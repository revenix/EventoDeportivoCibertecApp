using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EventoDeportivoCibertecApp.portable;

namespace EventoDeportivoCibertecApp.droid
{
    [Activity(Label = "ParticipanteActivity")]
    public class ParticipanteActivity : Activity
    {
        Services controller = new Services();
        ListView listParticipante;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Participantes);
            listParticipante = FindViewById<ListView>(Resource.Id.listParticipante);

            string idpart = Intent.GetStringExtra("idpart");


            await GetParticipantes(int.Parse(idpart));
        }

        private async Task GetParticipantes(int id)
        {
            try
            {
                var dato = await controller.ListaParticipantes(id);

                listParticipante.ItemClick += ListParticipante_ItemClick;

                listParticipante.Adapter = new ParticipantesAdapter(this, dato);

            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.ToString(), ToastLength.Long).Show();
            }
        }

        private void ListParticipante_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var id = e.View.FindViewById<TextView>(Resource.Id.txtidparticipante);

            Toast.MakeText(this,"clic", ToastLength.Long).Show();

           var activity2 = new Intent(this, typeof(InfoParticipanteActivity));

           activity2.PutExtra("idparticipante", id.Text);

           StartActivity(activity2);


        }
    }
}