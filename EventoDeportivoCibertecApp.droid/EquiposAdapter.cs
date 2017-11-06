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
using Java.Lang;
using EventoDeportivoCibertecApp.portable;

namespace EventoDeportivoCibertecApp.droid
{
    public class EquiposAdapter : BaseAdapter<Equipo>
        
    {
       
        List<Equipo> _equipolist;
        Activity _context;
        //Services controller = new Services();

        public EquiposAdapter(Activity context, List<Equipo> list)
            :base()
        {
            this._equipolist = list;
            this._context = context;
        }

        public override Equipo this[int position]
        {
            get { return _equipolist[position]; }
        }
        public override int Count {
            get { return _equipolist.Count; }
        }
        
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
       
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.EquiposListItem, parent, false);

            var item = this[position];

           
            view.FindViewById<TextView>(Resource.Id.txtidequipo).Text = item.id_equipo.ToString();
           // view.FindViewById<TextView>(Resource.Id.txtmodadeporte).Text = item.deporte;
            view.FindViewById<TextView>(Resource.Id.txtnombreequipo).Text = item.nombre;

            return view;

        }
    }
}