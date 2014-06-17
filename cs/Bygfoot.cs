using System;
using System.Xml;
using Gtk;

namespace bygfoot
{
	public class Bygfoot
	{
		/**
		 * Program version number and year (copyright).
		 */
		public const string VERS = "2.3.3";
		public const string YEAR = "2005 - 2011";

		/** Home dir name */
		public const string HOMEDIRNAME = ".bygfoot";

		/** Starting numbers of league, cup and supercup numerical ids. */
		public const int ID_LEAGUE_START = 1000;
		public const int ID_CUP_START = 7000;

		public static string WindowTitle
		{
			get { return "Bygfoot Football Manager"; }
		}

		
		public static int NewPlayerId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_PLAYER_ID]++; }
		}

		public static int NewTeamId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_TEAM_ID]++; }
		}

		public static int NewCupId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_CUP_ID]++; }
		}

		public static int NewLeagueId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_LEAGUE_ID]++; }
		}

		public static int NewFixtureId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_FIX_ID]++; }
		}

		public static int NewLGCommentaryId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_LG_COMM_ID]++; }
		}

		public static int NewNewsTitleId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_NEWS_TITLE_ID]++; }
		}

		public static int NewNewsSubTitleId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_NEWS_SUBTITLE_ID]++; }
		}

		public static int NewNewsArticleId
		{
			get { return Variables.Counters [(int)CounterType.COUNT_NEWS_ARTICLE_ID]++; }
		}
	}

	public enum ExitCodes
	{
		EXIT_OK = 0, /**< Normal exit. */
		EXIT_GENERAL, /**< A general, multi-purpose exit code. */
		EXIT_NO_COUNTRY_FILES, /**< Exit when no country files have been found. */
		EXIT_FILE_OPEN_FAILED, /**< A file could not be opened. */
		EXIT_PRINT_ERROR, /**< Exit when the print_error function is called on a set error.*/
		EXIT_NO_LEAGUES, /**< The game must contain at least one league. */
		EXIT_CHOOSE_TEAM_ERROR, /**< There was a problem loading the choose_teams. @see cup_load_choose_teams() */
		EXIT_FIXTURE_WRITE_ERROR, /**< There was an error writing the fixtures. */
		EXIT_USER_FIRED, /**< Single user was fired and didn't accept the new offer. */
		EXIT_FIRST_WEEK_ERROR, /**< First week of cup was negative. */
		EXIT_OPTION_NOT_FOUND, /**< An option couldn't be found. */
		EXIT_POINTER_NOT_FOUND, /**< We didn't find a pointer needed. */
		EXIT_INT_NOT_FOUND, /**< We didn't find an integer value (mostly indices). */
		EXIT_FILE_NOT_FOUND, /**< Some file couldn't be found. */
		EXIT_NO_SUPPORT_DIR, /**< No support directory found. */
		EXIT_CUP_ROUND_ERROR, /**< Too few cup rounds. */
		EXIT_LOAD_TEAM_DEF, /**< Error loading a team definition file. */
		EXIT_DEF_SORT, /**< Error sorting a team after loading the definition. */
		EXIT_PROM_REL, /**< Error when executing the promotion/relegation stuff. */
		EXIT_STRATEGY_ERROR, /**< Error related to CPU strategies. */
		EXIT_BET_ERROR, /**< Error related to betting. */
		EXIT_END
	}

	public class Windows
	{
		public Gtk.Window main;
		public Gtk.Window startup;
		public Gtk.Window live;
		public Gtk.Window warning;
		public Gtk.Window progress;
		public Gtk.Window digits;
		public Gtk.Window stadium;
		public Gtk.Window job_offer;
		public Gtk.Window yesno;
		public Gtk.Window options;
		public Gtk.Window constants;
		public Gtk.Window font_sel;
		public Gtk.Window file_chooser;
		public Gtk.Window contract;
		public Gtk.Window menu_player;
		public Gtk.Window menu_youth;
		public Gtk.Window user_management;
		public Gtk.Window wdebug;
		public Gtk.Window help;
		public Gtk.Window transfer_dialog;
		public Gtk.Window sponsors;
		public Gtk.Window mmatches;
		public Gtk.Window bets;
		public Gtk.Window splash;
		public Gtk.Window training_camp;
		public Gtk.Window news;
		public Gtk.Window alr;
	}
}

