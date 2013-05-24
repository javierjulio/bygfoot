using System;
using Gtk;

namespace bygfoot
{
	public class WarningWindow
	{
		[Glade.Widget]
		static Window window_warning = null;

		[Glade.Widget]
		private static Label label_warning = null;

		public static Window Create()
		{
			string filename = GladeHelper.ProcessGladeFile(FileHelper.FindSupportFile("bygfoot_misc2.glade", true));
			Glade.XML gxml = new Glade.XML(filename, "window_warning", null);
			gxml.Autoconnect(typeof(WarningWindow));
			
			return window_warning;
		}

		public static void SetText(string text)
		{
			label_warning.Text = text;
		}
	}
}
