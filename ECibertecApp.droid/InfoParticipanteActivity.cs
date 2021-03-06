﻿using System;
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
    [Activity(Label = "InfoParticipanteActivity")]
    public class InfoParticipanteActivity : Activity
    {
        TextView nombres;
        Button btnAtras;

        TextView sexo;
        RatingBar rating;
        TextView equipo;
        Services controller = new Services();
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.InfoParticipante);

            nombres = FindViewById<TextView>(Resource.Id.txtNombres);
            sexo = FindViewById<TextView>(Resource.Id.txtsexo);
            rating = FindViewById<RatingBar>(Resource.Id.txtratingbar);
            equipo = FindViewById<TextView>(Resource.Id.txtequipo);
            btnAtras = FindViewById<Button>(Resource.Id.btnAtras);

            rating.Enabled = false;

            btnAtras.Click += BtnAtras_Click;


            string idparticipante = Intent.GetStringExtra("idparticipante");
          //  Toast.MakeText(this, idparticipante, ToastLength.Long).Show();


            var dato = await controller.ParticipanteInfo(int.Parse(idparticipante));

            if (dato != null)
            {
                nombres.Text = dato.nombres + " " + dato.apellidos;
                sexo.Text = dato.sexo;
                rating.Rating = int.Parse(dato.valoracion);
                
                // rating.NumStars =int.Parse(dato.valoracion);
                equipo.Text = dato.nombre;
            }
        }
       

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            //back button
            this.Finish();
        }
    }
}