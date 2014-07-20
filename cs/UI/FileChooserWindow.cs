using System;

namespace bygfoot
{
	public class FileChooserWindow
	{
		[Glade.Widget]
		static Gtk.Window window_file_chooser = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc.glade", "window_file_chooser", typeof(FileChooserWindow));
			return window_file_chooser;
		}
	}
}

