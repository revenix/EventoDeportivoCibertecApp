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
    public class ModalidadesAdapter : BaseAdapter<Modalidad>
        
    {
       
        List<Modalidad> _modalidadlist;
        Activity _context;
        //Services controller = new Services();

        public ModalidadesAdapter(Activity context, List<Modalidad> list)
            :base()
        {
            this._modalidadlist = list;
            this._context = context;
        }

        public override Modalidad this[int position]
        {
            get { return _modalidadlist[position]; }
        }
        public override int Count {
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.ModalidadesListItem, parent, false);

            var item = this[position];

            // var item = _eventolist[position];
            view.FindViewById<TextView>(Resource.Id.txtidmodalidad).Text = item.id_modalidad.ToString();
            view.FindViewById<TextView>(Resource.Id.txtmodadeporte).Text = item.deporte;
            view.FindViewById<TextView>(Resource.Id.txtmodacategoria).Text = item.categoria;

            return view;

        }
    }
}