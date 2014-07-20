using System;
using Gtk;
using Mono.Unix;

namespace bygfoot
{
	public enum AppWindows
	{
		WINDOW_MAIN = 0,
		WINDOW_STARTUP,
		WINDOW_LIVE,
		WINDOW_WARNING,
		WINDOW_PROGRESS,
		WINDOW_DIGITS,
		WINDOW_STADIUM,
		WINDOW_JOB_OFFER,
		WINDOW_YESNO,
		WINDOW_OPTIONS,
		WINDOW_CONSTANTS,
		WINDOW_FONT_SEL,
		WINDOW_FILE_CHOOSER,
		WINDOW_CONTRACT,
		WINDOW_USER_MANAGEMENT,
		WINDOW_DEBUG,
		WINDOW_HELP,
		WINDOW_TRANSFER_DIALOG,
		WINDOW_SPONSORS,
		WINDOW_MMATCHES,
		WINDOW_BETS,
		WINDOW_SPLASH,
		WINDOW_END,
		WINDOW_TRAINING_CAMP,
		WINDOW_NEWS,
		WINDOW_ALR
	}

	public static class Window
	{
		public static Gtk.Window Create (AppWindows type)
		{
			string title = string.Empty;
			Gtk.Window window = null;
			switch (type) {
			default:
				Program.ExitProgram(ExitCodes.EXIT_INT_NOT_FOUND, "CreateWindow: Unknown window type {0}", type);
				break;
			case AppWindows.WINDOW_MAIN:
				if (Variables.Window.main == null) {
					Variables.Window.main = MainWindow.Create ();
					window = Variables.Window.main;
					MainWindow.LoadGeometry ();
					GameGUI.PrintMessage (Catalog.GetString ("Welcome to Bygfoot %s"), Bygfoot.VERS);
					title = string.Format ("Bygfoot Football Manager {0}", Bygfoot.VERS);
				}
				else
					window = Variables.Window.main;
				if (Option.OptInt ("int_opt_maximize_main_window") == 1)
					window.Maximize ();
				break;
			case AppWindows.WINDOW_STARTUP:
				if (Variables.Window.startup != null)
					Debug.PrintMessage("CreateWindow: called on already existing window");
				else
					Variables.Window.startup = StartupWindow.Create();
				window = Variables.Window.startup;
				break;
			case AppWindows.WINDOW_LIVE:
				if (Variables.Window.live != null)
					Debug.PrintMessage ("Window.Create: called on already existing window\n");
				else
					Variables.Window.live = LiveWindow.Instance.Create ();
				/*
				if(((LiveGame*)statp)->fix != NULL)
					strcpy(buf, league_cup_get_name_string(((LiveGame*)statp)->fix->clid));
				window = Variables.Window.live;
				window_live_set_up();
				*/
				break;
			case AppWindows.WINDOW_WARNING:
				if (Variables.Window.warning != null)
					Debug.PrintMessage("CreateWindow: called on already existing window");
				else
					Variables.Window.warning = WarningWindow.Create();
				window = Variables.Window.warning;
				break;
			case AppWindows.WINDOW_PROGRESS:
				break;
			case AppWindows.WINDOW_DIGITS:
				break;
			case AppWindows.WINDOW_STADIUM:
				break;
			case AppWindows.WINDOW_JOB_OFFER:
				break;
			case AppWindows.WINDOW_YESNO:
				break;
			case AppWindows.WINDOW_OPTIONS:
				break;
			case AppWindows.WINDOW_CONSTANTS:
				break;
			case AppWindows.WINDOW_FONT_SEL:
				break;
			case AppWindows.WINDOW_FILE_CHOOSER:
				break;
			case AppWindows.WINDOW_CONTRACT:
				break;
			case AppWindows.WINDOW_USER_MANAGEMENT:
				break;
			case AppWindows.WINDOW_DEBUG:
				break;
			case AppWindows.WINDOW_HELP:
				break;
			case AppWindows.WINDOW_TRANSFER_DIALOG:
				break;
			case AppWindows.WINDOW_SPONSORS:
				break;
			case AppWindows.WINDOW_MMATCHES:
				break;
			case AppWindows.WINDOW_BETS:
				break;
			case AppWindows.WINDOW_SPLASH:
				if (Variables.Window.splash != null)
					Debug.PrintMessage("CreateWindow: called on already existing window");
				else
					Variables.Window.splash = SplashWindow.Create();
				window = Variables.Window.splash;
				break;
			case AppWindows.WINDOW_END:
				break;
			case AppWindows.WINDOW_TRAINING_CAMP:
				break;
			case AppWindows.WINDOW_NEWS:
				break;
			case AppWindows.WINDOW_ALR:
				break;
			}

			if (type != AppWindows.WINDOW_FILE_CHOOSER)
				window.Title = title;

			if (type != AppWindows.WINDOW_PROGRESS && type != AppWindows.WINDOW_STARTUP)
				GLib.Timeout.Add (20, () => {
					return ShowWindow(window);
				});
			else
				window.Show ();

			return window;
		}

		public static bool ShowWindow(Gtk.Window window)
		{
			#if DEBUG
			Console.WriteLine("Window.ShowWindow");
			#endif

			window.Show ();
			return false;
		}

		public static void Destroy(ref Gtk.Window window)
		{
#if DEBUG
			Console.WriteLine("Window.Destroy");
#endif
			if (window == null)
				return;

			if (window == Variables.Window.splash)
			{
				int counterIndex = (int)CounterType.COUNT_HINT_NUMBER;
				Variables.Counters[counterIndex] = (Variables.Counters[counterIndex] + 1) % Variables.hints.list.Count;
				SplashWindow.SaveHintNumber();
			}

			window.Destroy();
			window = null;
		}
	}
}
