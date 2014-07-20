using System;

namespace bygfoot
{
	public class StadiumWindow
	{
		[Glade.Widget]
		static Gtk.Window window_stadium = null;

		[Glade.Widget]
		static Gtk.Label label_capacity = null;

		[Glade.Widget]
		static Gtk.Label label_stadium_status = null;

		[Glade.Widget]
		static Gtk.Label label_average_attendance = null;

		[Glade.Widget]
		static Gtk.Label label_stadium_name = null;

		[Glade.Widget]
		static Gtk.SpinButton spin_ticket_price = null;

		[Glade.Widget]
		static Gtk.ProgressBar progressbar_safety = null;

		[Glade.Widget]
		static Gtk.ProgressBar progressbar_average_attendance = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_capacity = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_safety = null;

		[Glade.Widget]
		static Gtk.Label label_costs_capacity = null;

		[Glade.Widget]
		static Gtk.Label label_costs_safety = null;

		[Glade.Widget]
		static Gtk.Label label_duration_capacity = null;

		[Glade.Widget]
		static Gtk.Label label_duration_safety = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc.glade", "window_stadium", typeof(StadiumWindow));
			return window_stadium;
		}
	}
}

