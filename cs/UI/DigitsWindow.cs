using System;

namespace bygfoot
{
	public class DigitsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_digits = null;

		[Glade.Widget]
		static Gtk.Label label_main = null;

		[Glade.Widget]
		static Gtk.Label label_1 = null;

		[Glade.Widget]
		static Gtk.Label label_2 = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton1 = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton2 = null;

		[Glade.Widget]
		static Gtk.Button button_digits_alr = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_digits", typeof(DigitsWindow));
			return window_digits;
		}
	}
}

