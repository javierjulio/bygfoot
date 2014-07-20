using System;

namespace bygfoot
{
	public class ProgressWindow
	{
		[Glade.Widget]
		static Gtk.Window window_progress = null;

		[Glade.Widget]
		static Gtk.Image image_match = null;

		[Glade.Widget]
		static Gtk.ProgressBar progressbar = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_progress", typeof(ProgressWindow));
			return window_progress;
		}
	}
}

