using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using EventoDeportivoCibertecApp.portable;
using System.Threading.Tasks;

namespace ECibertecApp.droid.Fragments
{
    public class Fragment2 : SupportFragment
    {
        Services controller = new Services();
        ListView listParticipante;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment2, container, false);

            listParticipante = view.FindViewById<ListView>(Resource.Id.listParticipante);
            //evento sin await

            GetParticipante();

            //evento sin await

            return view;
        }

        private async Task GetParticipante()
        {
            try
            {
                var dato = await controller.ListParticipantes();

                listParticipante.ItemClick += ListParticipante_ItemClick;

                listParticipante.Adapter = new ParticipanteAdapter(this.Activity, dato);
            }
            catch (Exception e)
            {
                //this.context
                Toast.MakeText(this.Activity, e.ToString(), ToastLength.Long).Show();
            }
        }

        private void ListParticipante_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var id = e.View.FindViewById<TextView>(Resource.Id.txtidparticipante);

            Toast.MakeText(this.Activity , id.Text, ToastLength.Long).Show();
            var activity2 = new Intent(this.Activity, typeof(InfoParticipanteActivity));
            activity2.PutExtra("idparticipante", id.Text);

            StartActivity(activity2);

        }
    }
}