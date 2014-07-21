using System;

namespace bygfoot
{
	public class BetsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_bets = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_bet_all_leagues = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_bet_cups = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_bet_user_recent = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_bets = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc3.glade", "window_bets", typeof(BetsWindow));
			return window_bets;
		}
	}
}

