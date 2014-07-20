using System;

namespace bygfoot
{
	public class SponsorsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_sponsors = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_sponsors = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc.glade", "window_sponsors", typeof(SponsorsWindow));
			return window_sponsors;
		}
	}
}

