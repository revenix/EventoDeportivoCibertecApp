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
    public class ParticipantesAdapter : BaseAdapter<Participantelista>
        
    {
       
        List<Participantelista> _participantelist;
        Activity _context;
        //Services controller = new Services();

        public ParticipantesAdapter(Activity context, List<Participantelista> list)
            :base()
        {
            this._participantelist = list;
            this._context = context;
        }

        public override Participantelista this[int position]
        {
            get { return _participantelist[position]; }
        }
        public override int Count {
            get { return _participantelist.Count; }
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.ParticipantesListItem, parent, false);

            var item = this[position];

            // var item = _eventolist[position];
            view.FindViewById<TextView>(Resource.Id.txtidparticipante).Text = item.id_participante.ToString();
            view.FindViewById<TextView>(Resource.Id.txtnombreParticipante).Text = item.nombres +" " +item.apellidos;
            view.FindViewById<TextView>(Resource.Id.txtpuesto).Text = item.puesto;
            view.FindViewById<RatingBar>(Resource.Id.txtratingbarParticipante).Rating =int.Parse(item.valoracion);

            return view;

        }
    }
}