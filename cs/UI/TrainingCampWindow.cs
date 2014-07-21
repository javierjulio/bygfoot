using System;

namespace bygfoot
{
	public class TrainingCampWindow
	{
		[Glade.Widget]
		static Gtk.Window window_training_camp = null;

		[Glade.Widget]
		static Gtk.Entry tf_costs = null;

		[Glade.Widget]
		static Gtk.RadioButton rb_camp1 = null;

		[Glade.Widget]
		static Gtk.RadioButton rb_camp2 = null;

		[Glade.Widget]
		static Gtk.RadioButton rb_camp3 = null;

		[Glade.Widget]
		static Gtk.Label l_costs = null;

		[Glade.Widget]
		static Gtk.Label l_recreation = null;

		[Glade.Widget]
		static Gtk.Label l_training = null;

		[Glade.Widget]
		static Gtk.Label l_camp_points = null;

		[Glade.Widget]
		static Gtk.HSeparator hs_recreation = null;

		[Glade.Widget]
		static Gtk.HSeparator hs_training = null;

		[Glade.Widget]
		static Gtk.HSeparator hs_camp_points = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_save = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_training.glade", "window_training_camp", typeof(TrainingCampWindow));
			return window_training_camp;
		}
	}
}

