using System;
using System.IO;
using Gtk;

namespace bygfoot
{
	public class MainWindow
	{
		[Glade.Widget]
		static Gtk.Window main_window = null;

		[Glade.Widget]
		static Gtk.Entry entry_message = null;

		[Glade.Widget]
		static Gtk.HPaned hpaned2 = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot.glade", "main_window", typeof(MainWindow));
			return main_window;
		}

		/** Set the main window geometry according to the file
		 * settings. */
		public static void LoadGeometry()
		{
			#if DEBUG
			Console.WriteLine("WindowMain.LoadGeometry");
			#endif

			string dir = FileHelper.GetHomeDir ();
			string filename = Path.Combine (dir, "window_settings");
			if (File.Exists (filename)) {
				OptionList optionList = null;
				FileHelper.LoadOptFile (filename, ref optionList, false);

				main_window.Resize (Option.OptionInt ("int_windows_settings_width", optionList),
					Option.OptionInt ("int_window_settings_height", optionList));
				main_window.Move (Option.OptionInt ("int_window_settings_pos_x", optionList),
					Option.OptionInt ("int_window_settings_pos_y", optionList));
				hpaned2.Position = Option.OptionInt ("int_window_settings_paned_pos", optionList);
			}
			Variables.Window.PannedPos = hpaned2.Position;
    	}
	}
}

