using System;

namespace bygfoot
{
	public class GameGUI
	{
		/** Print a message in the message area. */
		public static void PrintMessage(string format, params object[] args)
		{
#if DEBUG
			Console.WriteLine("GameGUI.PrintMessage");
#endif
			string msg = string.Format(format, args);
			// TODO: Complete the implementation
		}

		/** Show a window with a warning.
		 * @param text The text to show in the window. */
		public static void ShowWarning(string format, params object[] args)
		{
#if DEBUG
			Console.WriteLine("GameGUI.ShowWarning");
#endif
			string msg = string.Format(format, args);
			if (Option.OptInt("int_opt_prefer_messages") != 0 && Variables.Window.main != null)
				PrintMessage(msg, null);
			else
			{
				AppWindow.CreateWindow(AppWindowType.WINDOW_WARNING);
				WarningWindow.SetText(msg);
			}
		}
	}
}
