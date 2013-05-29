using System;
using Gtk;
using System.Collections;
using System.Collections.Generic;

namespace bygfoot
{
	public class Variables
	{
		/**
		 * The main variable of the game.
		 * @see Country
		 */
		public static Country Country = new Country();
		/** The array of human players. @see #User */
		public static List<User> Users = new List<User>();
		/** The season, week and week round numbers.
		 * We keep track of the time in the game with these variables. */
		public static int Season;
		public static int Week;
		public static int WeekRound;
		/** Array of options that get read from
		 * bygfoot.conf. */
		public static OptionList Options = new OptionList();
		/** Array of constants that get read from the constants
		 * file specified in bygfoot.conf. */
		public static OptionList Constants = new OptionList();
		/** Array of constants affecting game appearance rather than
		 * behaviour. */
		public static OptionList ConstantsApp = new OptionList();
		/** Array with internal settings. */
		public static OptionList Settings = new OptionList();
		/* Array holding string replacement tokens. */
		public static OptionList Tokens = new OptionList();

		/** The array containing the live game commentary strings. */
		public static ArrayList Commentary = new ArrayList(Convert.ToInt32(LiveGameEventType.LIVE_GAME_EVENT_END));
		/** The array containing the news article strings. */
		public static ArrayList News = new ArrayList(Convert.ToInt32(NewsArticleTypes.NEWS_ARTICLE_TYPE_END));
		/** Newspaper containing the news articles. */
		public static NewsPaper Newspaper;

		/** The array containing players to be transfered.
		 * @see TransferPlayer */
		public static ArrayList TransferList;
		
		/** Array with season statistics (updated at the
		 * end of each season. */
		public static ArrayList SeasonStats;
		
		/** Array of available CPU strategies. */
		public static ArrayList Strategies;
		
		/** Array of current and recent bets. */
		public static ArrayList Bets = new ArrayList(2);
		
		/** Loan interest for the current week. */
		public static double current_interest;
		
		/** Array of jobs in the job exchange and
		 * teams going with the international jobs. */
		public static ArrayList Jobs;
		public static ArrayList JobTeams;
		
		/** Some counters we use. */
		public static int[] Counters = new int[Convert.ToInt32(CounterType.COUNT_END)];
		
		/** These help us keep track of what's happening. */
		public static StatusValue[] status = new StatusValue[6];
		
		/** A pointer we store temporary stuff in. */
		//TODO: gpointer statp;
		
		/** The currently selected row in the treeview. */
		public static int selected_row;
		
		/** An array of name lists. */
		public static ArrayList NameLists;

		/** The struct containing the window pointers. */
		public static Windows Window = new Windows();
		
		/** The variables for non-user live games (which aren't shown). */
		public static ArrayList live_games;
		
		/** The index of the current user in the #users array. */
		public static int cur_user;
		
		public static int timeout_id;
		
		public static Random RandGenerator;
		
		/** Debug information. */
		public static int debug_level;
		public static DebugOutput debugOutput;
		
		/**
		 * The list of directories the file_find_support_file() function
		 * searches for support files (e.g. pixmaps or text files).
		 * @see file_find_support_file()
		 * @see file_add_support_directory_recursive()
		 **/
		public static List<string> SupportDirectories; // TODO: GList
		
		/**
		 * The list of root defintions directories found (ending in definitions)
		 **/ 
		public static List<string> root_definitions_directories = new List<string>(); // TODO: GList
		
		/**
		 * The list of defintions directories found
		 **/ 
		public static List<string> definitions_directories = new List<string>(); // TODO: GList
		
		/** The name of the current save file (gets updated when a game is
		 * saved or loaded).  */
		public static string save_file;
		
		/** Whether we are using a Unix system or Windows. */
		public static bool os_is_unix;

		/** The hints displayed in the splash screen. */
		public static OptionList hints = new OptionList();
	}
}
