using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Java.Lang;
using ECibertecApp.droid.Fragments;

namespace ECibertecApp.droid
{
    [Activity(Label = "ECibertecApp.droid", Theme = "@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity //cambiar a AppCompatActivity para usar el SetSupportActionBar,SupportActionBar
    {
        private DrawerLayout mDrawerLayout;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);





            //MENU 
            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.login);
            ab.SetDisplayHomeAsUpEnabled(true);

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);

            tabs.SetupWithViewPager(viewPager);
            /*Boton Flotante*/
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            fab.Click += (o, e) =>
            {
                View anchor = o as View;

                Snackbar.Make(anchor, "Yay Snackbar!!", Snackbar.LengthLong)
                        .SetAction("Action", v =>
                        {
                            //Do something here
                            //Intent intent = new Intent(fab.Context, typeof(MainActivity /*BottomSheetActivity*/ ));//agregar algun activiti a mostrar
                            //  StartActivity(intent);
                        })
                        .Show();
            };
            /*Boton Flotante*/

            //MENU
        }

        private void SetUpViewPager(ViewPager viewPager)
        {

            //tabs agregar tabs 
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Fragment1(), "Fragment 1");
            adapter.AddFragment(new Fragment2(), "Fragment 2");
            adapter.AddFragment(new Fragment3(), "Fragment 3");

            viewPager.Adapter = adapter;
        }

        //Evento de botones del Menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
        //Evento de botones del Menu

        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();
            };
        }
    }


    //TABS
    public class TabAdapter : FragmentPagerAdapter
    {
        public List<SupportFragment> Fragments { get; set; }
        public List<string> FragmentNames { get; set; }

        public TabAdapter(SupportFragmentManager sfm) : base(sfm)
        {
            Fragments = new List<SupportFragment>();
            FragmentNames = new List<string>();
        }

        public void AddFragment(SupportFragment fragment, string name)
        {
            Fragments.Add(fragment);
            FragmentNames.Add(name);
        }

        public override int Count
        {
            get
            {
                return Fragments.Count;
            }
        }

        public override SupportFragment GetItem(int position)
        {
            return Fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(FragmentNames[position]);
        }
    }
    //TABS


}

