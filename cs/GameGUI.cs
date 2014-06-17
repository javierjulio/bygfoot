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

			// TODO
			//gtk_entry_set_text(GTK_ENTRY(lookup_widget(window.main, "entry_message")), text);

			if (Variables.timeout_id != -1) {
				// TODO: Confirm
				GLib.Source.Remove ((uint)Variables.timeout_id);
			}

			uint interval = (uint)Option.ConstInt ("int_game_gui_message_duration") * 1000;
			Variables.timeout_id = (int)GLib.Timeout.Add (interval, new GLib.TimeoutHandler(ClearEntryMessage));
		}

		/** Function that gets called from time to time. */
		public static bool ClearEntryMessage()
		{
#if DEBUG
			Console.WriteLine("GameGUI.ClearEntryMessage");
#endif
			// TODO
			//if(window.main != NULL)
			//	gtk_entry_set_text(GTK_ENTRY(lookup_widget(window.main, "entry_message")), "");

			return false;
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
				Window.Create(AppWindows.WINDOW_WARNING);
				WarningWindow.SetText(msg);
			}
		}
	}
}
