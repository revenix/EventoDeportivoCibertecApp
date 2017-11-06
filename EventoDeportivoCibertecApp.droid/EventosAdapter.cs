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
    public class EventosAdapter : BaseAdapter
        
    {

        List<Evento> _eventolist;
        Activity _context;
        //Services controller = new Services();

        public EventosAdapter(Activity context, IEnumerable<Evento> list) :base()
        {
            _context = context;
            _eventolist = list.ToList();

            //  FillContacts();
            //_eventolist = controller.ListEventos();
        }


        public override int Count {
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
            var item = _eventolist[position];

            var view = (convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.EventosListItem, parent, false)) as LinearLayout;
            var txtnombre =(EditText)view.FindViewById(Resource.Id.txtNombreEvento);
            txtnombre.Text = item.nombre_evento.ToString();
            return view;
            // txtnombre.

        }
    }
}