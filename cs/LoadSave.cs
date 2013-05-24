using System;

namespace bygfoot
{
	public class LoadSave
	{
		public static bool LoadGame(string filename, bool createMainWindow)
		{
			return false;
		}

		public static bool LoadGameFromCommandLine(string filename)
		{
#if DEBUG
			Console.WriteLine("LoadSaveFromCommandLine");
#endif
			string fullname = null;
			string supportFilename = null;

			if (filename.ToLower().Equals("last_save"))
				return LoadGame(filename, true);

			return false;
		}
	}
}

