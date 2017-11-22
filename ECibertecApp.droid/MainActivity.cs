﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace ECibertecApp.droid
{
    [Activity(Label = "ECibertecApp.droid", MainLauncher = true , Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

