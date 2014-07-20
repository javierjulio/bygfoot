using System;

namespace bygfoot
{
	public class DebugWindow
	{
		[Glade.Widget]
		static Gtk.Window window_debug = null;

		[Glade.Widget]
		static Gtk.Entry entry_debug = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_debug", typeof(DebugWindow));
			return window_debug;
		}
	}
}

