using System;
using System.IO;

namespace bygfoot
{
	public enum DebugOutput
	{
		DEBUG_OUT_STDOUT = 0,
		DEBUG_OUT_LOGFILE,
		DEBUG_OUT_STDOUT_LOGFILE
	}

	public static class Debug
	{
		public static void PrintMessage(string format, params object[] args)
		{
			if (!string.IsNullOrEmpty(format))
			{
				string msg = format;
				if (msg.Contains("{"))
					msg = string.Format(format, args);

				if (Variables.debugOutput != DebugOutput.DEBUG_OUT_LOGFILE)
					Console.WriteLine(msg, msg);

				if (Variables.debugOutput != DebugOutput.DEBUG_OUT_STDOUT)
				{
					string home = FileHelper.GetHomeDir();
					string filepath = string.Format("{0}{1}{2}", home, Path.DirectorySeparatorChar, "bygfoot.log");

					StreamWriter sw = new StreamWriter(filepath, true);
					sw.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString(), msg));
					sw.Close();
				}
			}
		}
	}
}

