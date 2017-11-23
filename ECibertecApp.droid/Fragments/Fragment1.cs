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
    public class Fragment1 : SupportFragment
    {
        Services controller = new Services();
        ListView listEvento;


        public override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.fragment1, container, false);

            listEvento = view.FindViewById<ListView>(Resource.Id.listEventos);
            //evento sin await

            GetEventos();
            
            //evento sin await

            return view;
            

        }
        

        private void ListEvento_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            /*captura el txtidevento e.view.findby..*/
            var id = e.View.FindViewById<TextView>(Resource.Id.txtidEvento);
            /*var activity2 = new Intent(this, typeof(ModalidadesActivity));
             activity2.PutExtra("idmodalidad", id.Text);
             StartActivity(activity2);*/
            Toast.MakeText(this.Activity, "id de evento : " + id.Text, ToastLength.Long).Show();

        }

        private async Task GetEventos()
        {
            try
            {
                var dato = await controller.ListEventos();
                listEvento.ItemClick += ListEvento_ItemClick;
                listEvento.Adapter = new EventosAdapter(this.Activity, dato);
            }
            catch (Exception e)
            {
                //this.context
                Toast.MakeText(this.Activity, e.ToString(), ToastLength.Long).Show();
            }
        }

    }
}