using System;
using Gtk;

namespace bygfoot
{
	public enum AppWindowType
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

	public class AppWindow
	{
		public static Window CreateWindow (AppWindowType type)
		{
			Window window = null;
			switch (type) {
			default:
				Program.ExitProgram(ExitCodes.EXIT_INT_NOT_FOUND, "CreateWindow: Unknown window type {0}", type);
				break;
			case AppWindowType.WINDOW_MAIN:
				break;
			case AppWindowType.WINDOW_STARTUP:
				if (Variables.Window.startup != null)
					Debug.PrintMessage("CreateWindow: called on already existing window");
				else
					Variables.Window.startup = StartupWindow.Create();
				window = Variables.Window.startup;
				break;
			case AppWindowType.WINDOW_LIVE:
				break;
			case AppWindowType.WINDOW_WARNING:
				if (Variables.Window.warning != null)
					Debug.PrintMessage("CreateWindow: called on already existing window");
				else
					Variables.Window.warning = WarningWindow.Create();
				window = Variables.Window.warning;
				break;
			case AppWindowType.WINDOW_PROGRESS:
				break;
			case AppWindowType.WINDOW_DIGITS:
				break;
			case AppWindowType.WINDOW_STADIUM:
				break;
			case AppWindowType.WINDOW_JOB_OFFER:
				break;
			case AppWindowType.WINDOW_YESNO:
				break;
			case AppWindowType.WINDOW_OPTIONS:
				break;
			case AppWindowType.WINDOW_CONSTANTS:
				break;
			case AppWindowType.WINDOW_FONT_SEL:
				break;
			case AppWindowType.WINDOW_FILE_CHOOSER:
				break;
			case AppWindowType.WINDOW_CONTRACT:
				break;
			case AppWindowType.WINDOW_USER_MANAGEMENT:
				break;
			case AppWindowType.WINDOW_DEBUG:
				break;
			case AppWindowType.WINDOW_HELP:
				break;
			case AppWindowType.WINDOW_TRANSFER_DIALOG:
				break;
			case AppWindowType.WINDOW_SPONSORS:
				break;
			case AppWindowType.WINDOW_MMATCHES:
				break;
			case AppWindowType.WINDOW_BETS:
				break;
			case AppWindowType.WINDOW_SPLASH:
				if (Variables.Window.splash != null)
					Debug.PrintMessage("CreateWindow: called on already existing window");
				else
					Variables.Window.splash = SplashWindow.Create();
				window = Variables.Window.splash;
				break;
			case AppWindowType.WINDOW_END:
				break;
			case AppWindowType.WINDOW_TRAINING_CAMP:
				break;
			case AppWindowType.WINDOW_NEWS:
				break;
			case AppWindowType.WINDOW_ALR:
				break;
			}
			window.Show();
			return window;
		}

		public static void Destroy(ref Window window)
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
