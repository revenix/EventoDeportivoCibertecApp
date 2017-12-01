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
    public class Fragment3 : SupportFragment
    {
        Services controller = new Services();
        ListView listModalidad;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment3, container, false);

            listModalidad = view.FindViewById<ListView>(Resource.Id.listModalidad);

            GetModalidad();

            //evento sin await

            return view;
        }

        private async Task GetModalidad()
        {
            try
            {
                var dato = await controller.ListModalidad();

                listModalidad.ItemClick += ListModalidad_ItemClick;

                listModalidad.Adapter = new ModalidaAdapter(this.Activity, dato);
            }
            catch (Exception e)
            {
                Toast.MakeText(this.Activity, e.ToString(), ToastLength.Long).Show();
            }
        }

        private void ListModalidad_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           /* var id = e.View.FindViewById<TextView>(Resource.Id.txtidparticipante);

            //Toast.MakeText(this.Activity , id.Text, ToastLength.Long).Show();
            var activity2 = new Intent(this.Activity, typeof(InfoParticipanteActivity));
            activity2.PutExtra("idparticipante", id.Text);

            StartActivity(activity2);*/
        }

    }
}