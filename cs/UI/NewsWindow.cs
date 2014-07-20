using System;

namespace bygfoot
{
	public class NewsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_constants = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_options.glade", "window_constants", typeof(NewsWindow));
			return window_constants;
		}
	}
}

