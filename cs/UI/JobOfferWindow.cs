using System;

namespace bygfoot
{
	public class JobOfferWindow
	{
		[Glade.Widget]
		static Gtk.Window window_job_offer = null;

		[Glade.Widget]
		static Gtk.Label label_text = null;

		[Glade.Widget]
		static Gtk.Label label_text2 = null;

		[Glade.Widget]
		static Gtk.Label label_name = null;

		[Glade.Widget]
		static Gtk.Label label_league = null;

		[Glade.Widget]
		static Gtk.Label label_rank = null;

		[Glade.Widget]
		static Gtk.Label label_money = null;

		[Glade.Widget]
		static Gtk.Label label_cap = null;

		[Glade.Widget]
		static Gtk.Label label_saf = null;

		[Glade.Widget]
		static Gtk.Label label_average_skill = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_players = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_job_offer", typeof(JobOfferWindow));
			return window_job_offer;
		}
	}
}

