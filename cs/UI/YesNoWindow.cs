using System;

namespace bygfoot
{
	public class YesNoWindow
	{
		[Glade.Widget]
		static Gtk.Window window_yesno = null;

		[Glade.Widget]
		static Gtk.Label label_yesno = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_yesno", typeof(YesNoWindow));
			return window_yesno;
		}
	}
}

