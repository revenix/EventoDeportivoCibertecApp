﻿using Android.App;
using Android.Widget;
using Android.OS;

using EventoDeportivoCibertecApp.portable;
using System.Linq;
using System.Threading.Tasks;
using System;
using ZXing.Mobile;
using Android.Content;
using System.Collections.Generic;
using Android.Views;

using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;


namespace EventoDeportivoCibertecApp.droid
{
   [Activity(Theme = "@style/Theme.DesignDemo")]  

    public class MainActivity : Activity //AppCompatActivity
    {
        
        Button btnRegistrar;
        ListView listEvento;
        Services controller = new Services();
        Usuario usuario = new Usuario();
       // DrawerLayout drawerLayout;
      //  NavigationView navigationView;

        protected  override async void OnCreate(Bundle bundle)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
          SetContentView (Resource.Layout.Main);
            /*
            //starMenu
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Create ActionBarDrawerToggle button and add it to the toolbar  
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
               navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView); //Calling Function  
            //MenuEnd
            */

            //inicia el qr
            MobileBarcodeScanner.Initialize(Application);
            //termina qr
            
            btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);
            listEvento = FindViewById<ListView>(Resource.Id.listEventos);

           // ArrayAdapter array = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, dato.nombre_evento.ToString());

           // listEvento.Adapter = array;
            //eventos

            btnRegistrar.Click += BtnRegistrar_Click;    
            await GetEventos();
            
        }
        /*
        //menu voids
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
             navigationView.InflateMenu(Resource.Menu.nav_menu); //Navigation Drawer Layout Menu Creation  
            return true;
        }
        //end Menu Void
            */

        private async void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //lector de QR
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                var activity2 = new Intent(this, typeof(InfoParticipanteActivity));

                activity2.PutExtra("idparticipante", result.Text);

                StartActivity(activity2);

                Toast.MakeText(this, result.Text, ToastLength.Long).Show();
            }


        }
        private async Task GetEventos()
        {
            try
            {
                var dato = await controller.ListEventos();
               
                listEvento.ItemClick += ListEvento_ItemClick;

                listEvento.Adapter = new EventosAdapter(this,dato);

            }
            catch (Exception e)
            {


                Toast.MakeText(this, e.ToString(), ToastLength.Long).Show();
                 
            }
        }

        private void ListEvento_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            /*captura el txtidevento e.view.findby..*/
             var id = e.View.FindViewById<TextView>(Resource.Id.txtidEvento);
           // Toast.MakeText(this, "id de evento : "+id.Text , ToastLength.Long).Show();


            var activity2 = new Intent(this, typeof(ModalidadesActivity));

            activity2.PutExtra("idmodalidad", id.Text);

            StartActivity(activity2);

        }
        /* private async Task GetEventos()
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
}*/
    }
}

