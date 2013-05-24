using System;
using System.Configuration;
using System.IO;
using Gtk;
using Mono.Unix;
using NDesk.Options;

namespace bygfoot
{
	public class Program
	{
		private static string GETTEXT_PACKAGE = ConfigurationManager.AppSettings["GETTEXT_PACKAGE"];
		private static string PACKAGE_DATA_DIR = ConfigurationManager.AppSettings["PACKAGE_DATA_DIR"];
		private static string PACKAGE_LOCALE_DIR = FileHelper.GetCurrentDir();

		private static bool _loadLastSave = false;

		/** Parse the command line arguments given by the user. */
		private static void ParseCLArguments(string[] args)
		{
#if DEBUG
			Console.WriteLine("Program.ParseCLArguments");
#endif
			bool testcom = false, calodds = false;
			string supportDir = null, testcomFile = null, tokenFile = null;
			string eventName = null, lang  = null, countrySid = null;
			int numberOfPasses = 1, numMatches = 100, skillDifMax = 20;

			// TODO
			OptionSet optionSet = new OptionSet()
					.Add("l|last-save", Catalog.GetString("Load last savegame"), l => _loadLastSave = l != null)
					.Add("s|support-dir", Catalog.GetString("Specify additional support directory (takes priority over default ones)"), s => supportDir = s)
					.Add("c|country", Catalog.GetString("String id of the country to load"), c => countrySid = c)
					.Add("L|lang", Catalog.GetString("Language to use (a code like 'de')"), L => lang = L)
					.Add("t|testcom", Catalog.GetString("Test an XML commentary file"), t => testcom = t != null)
					.Add("C|commentary-file", Catalog.GetString("Commentary file name (may be in a support dir)"), C => testcomFile = C)
					.Add("T|token-file", Catalog.GetString("File containing live game tokens (may be in a support dir)"), T => tokenFile = T)
					.Add("e|event-name", Catalog.GetString("Commentary event to test; leave out to test all commentaries"), e => eventName = e)
					.Add("n|num-passes", Catalog.GetString("How many commentaries to generate per event"), n => Int32.TryParse(n, out numberOfPasses))
					.Add("O|calodds", Catalog.GetString("[developer] Calibrate the betting odds by simulating a lot of matches"), O => calodds = O != null)
					.Add("m|num-matches", Catalog.GetString("[developer] How many matches to simulate per skill diff step"), m => Int32.TryParse(m, out numMatches))
					.Add("S|num-skilldiff", Catalog.GetString("[developer] How many skill diff steps to take"), S => Int32.TryParse(S, out skillDifMax));

			if (args == null)
				return;
			optionSet.Parse(args);

			if (calodds)
			{
				Option.Add(Variables.Options, "int_opt_calodds", 1, null);
				Option.Add(Variables.Options, "int_opt_calodds_skilldiffmax", skillDifMax, null);
				Option.Add(Variables.Options, "int_opt_calodds_matches", numMatches, null);
			}

			if (testcom)
			{
				// TODO
				//lg_commentary_test(testcom_file, token_file, event_name, number_of_passes);
				ExitProgram(ExitCodes.EXIT_OK, null);
			}

			if (!string.IsNullOrEmpty(supportDir))
			{
				string fullPath = supportDir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? supportDir : string.Format("{0}{1}", supportDir, Path.DirectorySeparatorChar);
				FileHelper.AddSupportDirectoryRecursive(fullPath);
			}

			if (!string.IsNullOrEmpty(lang))
			{
				Language.Set(Language.GetCodeIndex(lang) + 1);
				FileHelper.LoadHintsFile();
			}

			if (!string.IsNullOrEmpty(countrySid))
			{
				Variables.Country.sid = countrySid;
			}
		}

		/** Parse the command line arguments given by the user. */
		private static void ParseDebugCLArguments(string[] args)
		{
#if DEBUG
			Console.WriteLine("Program.ParseDebugCLArguments");
#endif
		}

		/**
		 * Initialize some global variables. Most of them get nullified.
		 **/
		private static void InitVariables()
		{
#if DEBUG
			Console.WriteLine("Program.InitVariables");
#endif
			// TODO: proper initialization of leagues and cups
			//Variables.Country.leagues = new Array();
			//Variables.Country.cups = new Array();
			//Variables.Country.allcups = new Array();
			Variables.Country.name = null;
			Variables.Country.symbol = null;
			Variables.Country.sid = null;

			Variables.Season = Variables.Week = Variables.WeekRound = 1;

			for (int i = 0; i < (int)CounterType.COUNT_END; i++)
				Variables.Counters[i] = 0;

			Variables.Counters[(int)CounterType.COUNT_LEAGUE_ID] = Bygfoot.ID_LEAGUE_START;
			Variables.Counters[(int)CounterType.COUNT_CUP_ID] = Bygfoot.ID_CUP_START;
			Variables.Counters[(int)CounterType.COUNT_HINT_NUMBER] = -1;

			Variables.Window.main = Variables.Window.startup =
					Variables.Window.live = Variables.Window.warning = Variables.Window.progress = Variables.Window.digits =
					Variables.Window.stadium = Variables.Window.job_offer = Variables.Window.yesno =
					Variables.Window.options = Variables.Window.font_sel =
					Variables.Window.file_chooser = Variables.Window.contract =
					Variables.Window.menu_player = Variables.Window.user_management =
					Variables.Window.mmatches = Variables.Window.bets = Variables.Window.splash =
					Variables.Window.training_camp = null;

			// TODO: initialise
			/*
			users = g_array_new(FALSE, FALSE, sizeof(User));
			transfer_list = g_array_new(FALSE, FALSE, sizeof(Transfer));
			season_stats = g_array_new(FALSE, FALSE, sizeof(SeasonStat));
			name_lists = g_array_new(FALSE, FALSE, sizeof(NameList));
			strategies = g_array_new(FALSE, FALSE, sizeof(Strategy));
			live_games = g_array_new(FALSE, FALSE, sizeof(LiveGame));
			bets[0] = g_array_new(FALSE, FALSE, sizeof(BetMatch));
			bets[1] = g_array_new(FALSE, FALSE, sizeof(BetMatch));
			jobs = g_array_new(FALSE, FALSE, sizeof(Job));
			job_teams = g_array_new(FALSE, FALSE, sizeof(Team));
			*/
			Variables.save_file = null;

			Variables.ConstantsApp.list = Variables.Settings.list =
				Variables.Constants.list = Variables.Options.list = Variables.hints.list = null;

			Variables.ConstantsApp.datalist = Variables.Settings.datalist =
				Variables.Constants.datalist = Variables.Options.datalist = Variables.hints.datalist = null;

			Variables.selected_row = -1;
			Variables.timeout_id = -1;

			/* TODO
		    for(i=0;i<LIVE_GAME_EVENT_END;i++)
		        lg_commentary[i] = g_array_new(FALSE, FALSE, sizeof(LGCommentary));

		    for(i=0;i<NEWS_ARTICLE_TYPE_END;i++)
		        news[i] = g_array_new(FALSE, FALSE, sizeof(NewsArticle));

  			newspaper.articles = g_array_new(FALSE, FALSE, sizeof(NewsPaperArticle));
        	*/
			FileHelper.LoadConfFiles();
		}

		/**
		 * Process the command line arguments and do some things
		 * that have to be done at the beginning (like initializing the
		 * random number generator).
		 * @param argc Number of command line arguments.
		 * @param argv Command line arguments array.
		 **/
		private static void MainInit(string[] args)
		{
#if DEBUG
			Console.WriteLine("Program.MainInit");
#endif
			Variables.SupportDirectories = null;
			Variables.RandGenerator = new Random();
			ParseDebugCLArguments(args);

			switch(Environment.OSVersion.Platform)
			{
			case PlatformID.Win32NT:
			case PlatformID.Win32S:
			case PlatformID.Win32Windows:
			case PlatformID.WinCE:
				Variables.os_is_unix = false;
				break;
			default:
				Variables.os_is_unix = true;
				break;
			}

			string currentSupportDir = string.Format("{0}{1}{2}", PACKAGE_DATA_DIR, Path.DirectorySeparatorChar, "support_files");
			FileHelper.AddSupportDirectoryRecursive(currentSupportDir);
			string homeSupportDir = string.Format("{0}{1}{2}", FileHelper.GetHomeDir(), Path.DirectorySeparatorChar, Bygfoot.HOMEDIRNAME);
			FileHelper.AddSupportDirectoryRecursive(homeSupportDir);

			InitVariables();

			_loadLastSave = false;
			ParseCLArguments(args);
		}

		public static void Main(string[] args)
		{
#if DEBUG
			Console.WriteLine("Program.Main");
#endif
			Catalog.Init(GETTEXT_PACKAGE, PACKAGE_LOCALE_DIR);
			Application.Init();
			MainInit(args);

			if ((_loadLastSave && !LoadSave.LoadGameFromCommandLine("last_save")) ||
			    (!_loadLastSave && (args.Length <= 1 ||
			                    (args.Length > 1 && !LoadSave.LoadGameFromCommandLine(args[1])))))
			{
				if (string.IsNullOrEmpty(Variables.Country.sid))
				{
					Variables.status[0] = StatusValue.STATUS_SPLASH;
					SplashWindow.ShowSplash();

					if (Variables.os_is_unix)
						FileHelper.CheckHomeDir();
				}
				else
				{
					StartupWindow.ShowStartup();
					Variables.status[0] = StatusValue.STATUS_TEAM_SELECTION;
				}
			}

			Application.Run();
			ExitProgram(ExitCodes.EXIT_OK, null);
		}

		public static void ExitProgram(ExitCodes exitCode, string format, params object[] args)
		{
#if DEBUG
			Console.WriteLine("Program.ExitProgram");
#endif
			Debug.PrintMessage(format, args);

			if (!Variables.os_is_unix && exitCode != ExitCodes.EXIT_OK)
			{
				Debug.PrintMessage("Press RETURN. Program will exit.");
				Console.ReadLine();
			}

			Application.Quit();
		}
	}
}
