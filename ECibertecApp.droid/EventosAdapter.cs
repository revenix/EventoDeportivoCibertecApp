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

namespace ECibertecApp.droid
{
   public class EventosAdapter : BaseAdapter<Evento>
    {
        List<Evento> _eventolist;
        Activity _context;

        public EventosAdapter(Activity context, List<Evento> list)
            : base()
        {
            this._eventolist = list;
            this._context = context;
        }

        public override Evento this[int position]
        {
            get { return _eventolist[position]; }
        }
        public override int Count
        {
            get { return _eventolist.Count; }
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.EventoListItem, parent, false);

            var item = this[position];

            // var item = _eventolist[position];
            view.FindViewById<TextView>(Resource.Id.txtidEvento).Text = item.idevento.ToString();
            view.FindViewById<TextView>(Resource.Id.txtSedeEvento).Text = item.lugar;
            view.FindViewById<TextView>(Resource.Id.txtNombreEvento).Text = item.nombre_evento;

            return view;

        }
    }
}