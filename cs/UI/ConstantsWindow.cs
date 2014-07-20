using System;

namespace bygfoot
{
	public class ConstantsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_constants = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_constants_integer = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_constants_float = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_constants_string = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_constants_app = null;

		[Glade.Widget]
		static Gtk.Notebook notebook_constants = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_options.glade", "window_constants", typeof(ConstantsWindow));
			return window_constants;
		}
	}
}

