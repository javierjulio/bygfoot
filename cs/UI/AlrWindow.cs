using System;

namespace bygfoot
{
	public class AlrWindow
	{
		[Glade.Widget]
		static Gtk.Window window_alr = null;

		[Glade.Widget]
		static Gtk.Label label_current_start_week = null;

		[Glade.Widget]
		static Gtk.Label label_current_weekly_installment = null;

		[Glade.Widget]
		static Gtk.Label label_alr_debt = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_start_week = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_weekly_installment = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc3.glade", "window_alr", typeof(AlrWindow));
			return window_alr;
		}
	}
}

