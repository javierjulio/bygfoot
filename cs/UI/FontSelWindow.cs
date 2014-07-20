using System;

namespace bygfoot
{
	public class FontSelWindow
	{
		[Glade.Widget]
		static Gtk.Window window_font_sel = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc.glade", "window_font_sel", typeof(FontSelWindow));
			return window_font_sel;
		}
	}
}

