using System;
using Gtk;

namespace bygfoot
{
	public class Support
	{
		public static void LoadUI(string filename, string root, Type handler)
		{
			try
			{
				string uifile = GladeHelper.ProcessGladeFile(FileHelper.FindSupportFile(filename, true));
				Glade.XML gxml = new Glade.XML(uifile, root, null);
				gxml.Autoconnect(handler);
			}
			catch (Exception ex)
			{
				Program.ExitProgram(ExitCodes.EXIT_FILE_NOT_FOUND, ": Problems found in the glade file: {0}\n", ex.Message);
			}
		}

		/* Use this function to set the directory containing installed pixmaps. */
		public static void AddPixmapDirectory(string directory)
		{
		}
	}
}

