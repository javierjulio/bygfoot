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
					if (Variables.Window.progress != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.progress = ProgressWindow.Create();
					window = Variables.Window.progress;
					break;
				case AppWindows.WINDOW_DIGITS:
					if(Variables.Window.digits != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.digits = DigitsWindow.Create();

					window = Variables.Window.digits;
					title = Catalog.GetString("Numbers...");
					break;
				case AppWindows.WINDOW_STADIUM:
					if(Variables.Window.stadium != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.stadium = StadiumWindow.Create();
					window = Variables.Window.stadium;
					title = Catalog.GetString("Your stadium");
					break;
				case AppWindows.WINDOW_JOB_OFFER:
					if(Variables.Window.job_offer != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.job_offer = JobOfferWindow.Create();
					window = Variables.Window.job_offer;
					title = Catalog.GetString("Job offer");
					break;
				case AppWindows.WINDOW_YESNO:
					if(Variables.Window.yesno != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.yesno = YesNoWindow.Create();
					window = Variables.Window.yesno;
					title = "???";
					break;
				case AppWindows.WINDOW_OPTIONS:
					if(Variables.Window.options != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.options = OptionsWindow.Create();
					window = Variables.Window.options;
					title = Catalog.GetString("Options");
					break;
				case AppWindows.WINDOW_FONT_SEL:
					if(Variables.Window.font_sel != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.font_sel = FontSelWindow.Create();
					window = Variables.Window.font_sel;
					title = Catalog.GetString("Select font");
					break;
				case AppWindows.WINDOW_FILE_CHOOSER:
					if(Variables.Window.file_chooser != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.file_chooser = FileChooserWindow.Create();
					window = Variables.Window.file_chooser;
					break;
				case AppWindows.WINDOW_CONTRACT:
					if(Variables.Window.contract != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.contract = ContractWindow.Create();
					window = Variables.Window.contract;
					title = Catalog.GetString("Contract offer");
					break;
				case AppWindows.WINDOW_USER_MANAGEMENT:
					if(Variables.Window.user_management != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.user_management = UserManagementWindow.Create();
					window = Variables.Window.user_management;
					title = Catalog.GetString("User management");
					break;
				case AppWindows.WINDOW_DEBUG:
					if(Variables.Window.wdebug != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.wdebug = DebugWindow.Create();
					window = Variables.Window.wdebug;
					title = "Bygfoot debug window";
					break;
				case AppWindows.WINDOW_HELP:
					if(Variables.Window.help != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.help = create_window_help();
					window = Variables.Window.help;
					break;
				case AppWindows.WINDOW_TRANSFER_DIALOG:
					if(Variables.Window.transfer_dialog != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.transfer_dialog = create_window_transfer_dialog();
					window = Variables.Window.transfer_dialog;
					title = Catalog.GetString("Transfer offer");
					break;
				case AppWindows.WINDOW_SPONSORS:
					if(Variables.Window.sponsors != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.sponsors = SponsorsWindow.Create();
					window = Variables.Window.sponsors;
					title = Catalog.GetString("Sponsorship offers");
					break;
				case AppWindows.WINDOW_MMATCHES:
					if(Variables.Window.mmatches != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.mmatches = create_window_mmatches();
					window = Variables.Window.mmatches;
					title = Catalog.GetString("Memorable matches");
					break;
				case AppWindows.WINDOW_BETS:
					if(Variables.Window.bets != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.bets = create_window_bets();
					window = Variables.Window.bets;
					title = Catalog.GetString("Betting");
					break;
				case AppWindows.WINDOW_SPLASH:
					if (Variables.Window.splash != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.splash = SplashWindow.Create();
					window = Variables.Window.splash;
					break;
				case AppWindows.WINDOW_TRAINING_CAMP:
					if(Variables.Window.training_camp != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.training_camp = create_window_training_camp();
					window = Variables.Window.training_camp;
					title = Catalog.GetString("Training camp");
					break;
				case AppWindows.WINDOW_ALR:
					if(Variables.Window.alr != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.alr = create_window_alr();
					window = Variables.Window.alr;
					title = Catalog.GetString("Automatic loan repayment");
					break;
				case AppWindows.WINDOW_NEWS:
					if(Variables.Window.news != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.news = create_window_news();
					window = Variables.Window.news;
					title = Catalog.GetString("Bygfoot News");
					break;
				case AppWindows.WINDOW_CONSTANTS:
					if(Variables.Window.constants != null)
						Debug.PrintMessage("CreateWindow: called on already existing window");
					else
						Variables.Window.constants = ConstantsWindow.Create();
					window = Variables.Window.constants;
					title = Catalog.GetString("Bygfoot constants");
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
