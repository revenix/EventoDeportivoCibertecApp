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

namespace EventoDeportivoCibertecApp.droid
{
    [Activity(Label = "Login", MainLauncher = true, Icon = "@drawable/icon")]
    public class Login : Activity
    {

        EditText txtlogin;
        EditText txtpassword;
        Button btnIngresar;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
          Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Login);

             txtlogin = FindViewById<EditText>(Resource.Id.txtlogin);
             txtpassword = FindViewById<EditText>(Resource.Id.txtpassword);

             btnIngresar = FindViewById<Button>(Resource.Id.btnIngresar);

            btnIngresar.Click += BtnIngresar_Click;




        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string login = txtlogin.Text;
            string pasword = txtpassword.Text;

            Toast.MakeText(this, "hola " + login, ToastLength.Short).Show();

        }
    }
}