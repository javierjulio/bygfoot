using System;

namespace bygfoot
{
	public class HelpWindow
	{
		[Glade.Widget]
		static Gtk.Window window_help = null;

		[Glade.Widget]
		static Gtk.Label label_about = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_contributors = null;

		[Glade.Widget]
		static Gtk.Label label_help_text1 = null;

		[Glade.Widget]
		static Gtk.Label label_help_text2 = null;

		[Glade.Widget]
		static Gtk.Notebook notebook1 = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_help", typeof(HelpWindow));
			return window_help;
		}
	}
}

