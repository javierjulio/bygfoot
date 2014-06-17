using System;
using System.IO;
using Gtk;

namespace bygfoot
{
	public class SplashWindow
	{
		[Glade.Widget]
		static Gtk.Window window_splash = null;

		[Glade.Widget]
		static TreeView treeview_splash_contributors = null;

		[Glade.Widget]
		static Label label_splash_hint = null;
		[Glade.Widget]
		static Label label_splash_hintcounter = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc3.glade", "window_splash", typeof(SplashWindow));
			return window_splash;
		}

		public static void ShowSplash()
		{
#if DEBUG
			Console.WriteLine("Window.ShowSplash");
#endif
			Window.Create(AppWindows.WINDOW_SPLASH);

			TreeViewHelper.ShowContributors(treeview_splash_contributors);

			LoadHintNumber();
			ShowHint();
		}
		
		/** Load the index of the hint to show in the splash screen. */
		private static void LoadHintNumber()
		{
#if DEBUG
			Console.WriteLine("SplashWindow.LoadHintNumber");
#endif
			string filename = string.Format("{0}{1}hint_num", FileHelper.GetBygfootDir(), Path.DirectorySeparatorChar);
			int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
			if (!File.Exists(filename))
			{
				Variables.Counters[counterIndex] = 0;
				return;
			}

			string sCounter = File.ReadAllText(filename);
			Variables.Counters[counterIndex] = 0;
			if (Int32.TryParse(sCounter, out Variables.Counters[counterIndex]))
			{
				if (Variables.Counters[counterIndex] < 0 ||
				    Variables.Counters[counterIndex] >= Variables.hints.list.Count)
				{
					Debug.PrintMessage("Hint counter out of bounds: {0} (bounds 0 and {1}).\n", Variables.Counters[counterIndex], Variables.hints.list.Count - 1);
					Variables.Counters[counterIndex] = 0;
				}
			}
		}

		public static void SaveHintNumber()
		{
#if DEBUG
			Console.WriteLine("SplashWindow.SaveHintNumber");
#endif
			string filename = string.Format("{0}{1}hint_num", FileHelper.GetBygfootDir(), Path.DirectorySeparatorChar);
			int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
			File.WriteAllText(filename, Variables.Counters[counterIndex].ToString());
		}

		public static void ShowHint()
		{
#if DEBUG
			Console.WriteLine("SplashWindow.ShowHint");
#endif
			int index = Variables.Counters[(int)CounterType.COUNT_HINT_NUMBER];
			label_splash_hint.Text = ((OptionStruct)Variables.hints.list[index]).stringValue;
			label_splash_hintcounter.Text = string.Format("({0}/{1})", index + 1, Variables.hints.list.Count);
		}

		public static void on_window_splash_delete_event(object o, DeleteEventArgs args)
		{
#if DEBUG
			Console.WriteLine("on_window_splash_delete_event");
#endif
		}

		public static void on_button_splash_hint_back_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_splash_hint_back_clicked");
#endif
			int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
			Variables.Counters[counterIndex] = Variables.Counters[counterIndex] == 0 ? Variables.hints.list.Count - 1 : Variables.Counters[counterIndex] - 1;
			ShowHint();
		}

		public static void on_button_splash_hint_next_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_splash_hint_next_clicked");
#endif
			int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
			Variables.Counters[counterIndex] = (Variables.Counters[counterIndex] + 1) % Variables.hints.list.Count;
			ShowHint();
		}

		public static void on_button_splash_new_game_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_splash_new_game_clicked");
#endif
			Window.Destroy(ref Variables.Window.splash);
			StartupWindow.ShowStartup();

			Variables.status[0] = StatusValue.STATUS_TEAM_SELECTION;
		}

		public static void on_button_splash_load_game_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_splash_load_game_clicked");
#endif
			Variables.status[5] = StatusValue.STATUS_LOAD_GAME_SPLASH;
			// TODO
			//window_show_file_sel()
		}

		public static void on_button_splash_resume_game_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_splash_resume_game_clicked");
#endif
		}
			
		public static void on_button_splash_quit_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_splash_quit_clicked");
#endif
			Window.Destroy(ref Variables.Window.splash);
			Program.ExitProgram(ExitCodes.EXIT_OK, null);
		}
	}
}

