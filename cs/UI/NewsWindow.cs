using System;

namespace bygfoot
{
	public class NewsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_news = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_news = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc3.glade", "window_news", typeof(NewsWindow));
			return window_news;
		}
	}
}

