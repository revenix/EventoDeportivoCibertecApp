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
using EventoDeportivoCibertecApp.portable;

namespace ECibertecApp.droid
{
   public class ModalidaAdapter : BaseAdapter<Modalidad>
    {
        List<Modalidad> _modalidadlist;
        Activity _context;

        public ModalidaAdapter(Activity context, List<Modalidad> list)
            : base()
        {
            this._modalidadlist = list;
            this._context = context;
        }

        public override Modalidad this[int position]
        {
            get { return _modalidadlist[position]; }
        }
        public override int Count
        {
            get { return _modalidadlist.Count; }
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.ModalidadListItem, parent, false);

            var item = this[position];
             
            view.FindViewById<TextView>(Resource.Id.txtDestalleModalidad).Text = item.deporte +" "+item.categoria ;

            return view;

        }
    }
}