using System;
using Gtk;

namespace bygfoot
{
	public class LiveWindow
	{
		private LiveWindow() {
		}

		private static LiveWindow _instance = null;
		public static LiveWindow Instance
		{
			get {
				if (_instance == null)
					_instance = new LiveWindow ();
				return _instance;
			}
		}

		[Glade.Widget]
		private Gtk.Window window_live = null;

		[Glade.Widget]
		private Button button_live_close = null;
		[Glade.Widget]
		private Button button_pause = null;
		[Glade.Widget]
		private Button button_resume = null;
		[Glade.Widget]
		private EventBox eventbox_poss0 = null;
		[Glade.Widget]
		private EventBox eventbox_poss1 = null;
		[Glade.Widget]
		private HScale hscale_area = null;
		[Glade.Widget]
		private Image image_lg_boost = null;
		[Glade.Widget]
		private Image image_lg_opp_boost = null;
		[Glade.Widget]
		private Image image_lg_opp_style = null;
		[Glade.Widget]
		private Image image_lg_style = null;
		[Glade.Widget]
		private Label label_lg_avskill = null;
		[Glade.Widget]
		private Label label_lg_formation = null;
		[Glade.Widget]
		private ProgressBar progressbar_live = null;
		[Glade.Widget]
		private ScrolledWindow scrolledwindow9 = null;
		[Glade.Widget]
		private SpinButton spinbutton_speed = null;
		[Glade.Widget]
		private SpinButton spinbutton_verbosity = null;
		[Glade.Widget]
		private TreeView treeview_commentary = null;
		[Glade.Widget]
		private TreeView treeview_lg_opponent = null;
		[Glade.Widget]
		private TreeView treeview_result = null;
		[Glade.Widget]
		private TreeView treeview_stats = null;
		[Glade.Widget]
		private EventBox eventbox_lg_style = null;
		[Glade.Widget]
		private EventBox eventbox_lg_boost = null;

		public Gtk.Window Create()
		{
			string filename = GladeHelper.ProcessGladeFile(FileHelper.FindSupportFile("bygfoot_misc.glade", true));
			Glade.XML gxml = new Glade.XML(filename, "window_live", null);
			gxml.Autoconnect(this);

			return window_live;
		}
	}
}

