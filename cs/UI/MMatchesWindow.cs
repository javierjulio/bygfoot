using System;

namespace bygfoot
{
	public class MMatchesWindow
	{
		[Glade.Widget]
		static Gtk.Window window_mmatches = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_mmatches = null;

		[Glade.Widget]
		static Gtk.Entry entry_mm_file = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_mmatches", typeof(MMatchesWindow));
			return window_mmatches;
		}
	}
}

