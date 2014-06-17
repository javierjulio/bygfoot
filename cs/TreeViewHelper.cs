using System;
using System.IO;
using System.Collections.Generic;
using Gtk;
using Gdk;
using Mono.Unix;

namespace bygfoot
{
	public partial class TreeViewHelper
	{
		/** Select the row that's been clicked on. */
		public static bool SelectRow(TreeView treeview, EventButton btnEvent)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.SelectRow");
#endif
			// TODO
			return true;
		}

		/** Return the number in the 'column'th column of the currently
		 * selected row of the treeview.
		 * @param treeview The treeview argument.
		 * @param column The column we'd like to get the contents of.
		 * @return The number in the given column of the selected row.
		 **/
		public static int GetIndex(TreeView treeview, int column)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.GetIndex");
#endif
			TreeSelection selection = treeview.Selection;
			TreeIter iter;
			selection.GetSelected (out iter);
			int value = -1;
			Int32.TryParse (treeview.Model.GetValue (iter, column).ToString(), out value);
			return value;
		}

		/** Return the pointer in the 'column'th column of the currently
		 * selected row of the treeview.
		 * @param treeview The treeview argument.
		 * @param column The column we'd like to get the content of.
		 * @return The pointer in the given column of the selected row.
		 **/
		public static object GetPointer(TreeView treeview, int column)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.GetPointer");
#endif
			TreeSelection selection = treeview.Selection;
			TreeIter iter;
			selection.GetSelected (out iter);
			return treeview.Model.GetValue (iter, column);
		}

		/**
		 * Removes all columns from a GTK treeview. I didn't find a better way
		 * to completely clear a treeview :-/.
		 * @param treeview The pointer to the treeview widget we'd like to clear.
		 **/
		public static void Clear(TreeView treeview)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.Clear");
#endif
			if (treeview != null) {
				for (int i = treeview.Columns.Length - 1; i >= 0; i--) {
					treeview.RemoveColumn(treeview.Columns[i]);
				}
				treeview.Model = null;
			}
		}

		/** Return number of given column or -1 if not found or on error.
		 * @param col The column pointer.
		 * @return The index of the column within the treeview. */
		public static int GetColumnNumber(TreeViewColumn column)
		{
#if DEBUG
			Console.WriteLine("TreeviewHelper.GetColumnNumber");
#endif
			if (column != null && column.TreeView != null) {
				// TODO
			}
			return -1;
		}

		/** Return the row index of the iter in the model. 
		 * Since we only work with flat models (no children),
		 * the path is a single number. */
		public static int IterGetRow(TreeModel model, TreeIter iter)
		{
#if DEBUG
			Console.WriteLine("TreeviewHelper.IterGetRow");
#endif
			string path = model.GetStringFromIter (iter);
			//gint row_idx = (gint)g_ascii_strtod(path, NULL); // Is following correct?
			int rowIndex = -1;
			Int32.TryParse (path, out rowIndex);
			return rowIndex;
		}

		/** Return a cell renderer with font name set
		 * according to the font option. */
		public static CellRenderer TextCellRenderer()
		{
			CellRendererText renderer = new CellRendererText();

			string fontName = Option.OptStr("string_opt_font_name");
			if (!string.IsNullOrEmpty(fontName))
				renderer.Font = fontName;

			return renderer;
		}

		/** Return the filename of the icon going with the LiveGameEvent
		 * with type event_type.
		 * @param event_type The type of the event.
		 * @return A filename specifying a pixmap. */
		public static string LiveGameIcon(LiveGameEventType eventType)
		{
#if DEBUG
			Console.WriteLine("TreeviewHelper.LiveGameIcon");
#endif
			if(eventType == LiveGameEventType.LIVE_GAME_EVENT_START_MATCH ||
			   eventType == LiveGameEventType.LIVE_GAME_EVENT_END_MATCH ||
			   eventType == LiveGameEventType.LIVE_GAME_EVENT_HALF_TIME ||
			   eventType == LiveGameEventType.LIVE_GAME_EVENT_EXTRA_TIME ||
			   eventType == LiveGameEventType.LIVE_GAME_EVENT_PENALTIES)
				return Option.ConstApp("string_live_game_event_start_match_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_LOST_POSSESSION)
				return Option.ConstApp("string_live_game_event_lost_possession_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_PENALTY)
				return Option.ConstApp("string_live_game_event_penalty_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_SCORING_CHANCE ||
			        eventType == LiveGameEventType.LIVE_GAME_EVENT_FREE_KICK)
				return Option.ConstApp("string_live_game_event_scoring_chance_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_HEADER)
				return Option.ConstApp("string_live_game_event_header_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_GOAL)
				return Option.ConstApp("string_live_game_event_goal_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_OWN_GOAL)
				return Option.ConstApp("string_live_game_event_own_goal_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_POST)
				return Option.ConstApp("string_live_game_event_post_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_CROSS_BAR)
				return Option.ConstApp("string_live_game_event_cross_bar_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_SAVE)
				return Option.ConstApp("string_live_game_event_save_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_MISS)
				return Option.ConstApp("string_live_game_event_miss_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_FOUL)
				return Option.ConstApp("string_live_game_event_foul_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_FOUL_YELLOW)
				return Option.ConstApp("string_live_game_event_foul_yellow_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_SEND_OFF ||
			        eventType == LiveGameEventType.LIVE_GAME_EVENT_FOUL_RED ||
			        eventType == LiveGameEventType.LIVE_GAME_EVENT_FOUL_RED_INJURY)
				return Option.ConstApp("string_live_game_event_send_off_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_INJURY)
				return Option.ConstApp("string_live_game_event_injury_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_TEMP_INJURY)
				return Option.ConstApp("string_live_game_event_temp_injury_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STADIUM_BREAKDOWN)
				return Option.ConstApp("string_live_game_event_stadium_breakdown_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STADIUM_FIRE)
				return Option.ConstApp("string_live_game_event_stadium_fire_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STADIUM_RIOTS)
				return Option.ConstApp("string_live_game_event_stadium_riots_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_SUBSTITUTION)
				return Option.ConstApp("string_live_game_event_substitution_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STRUCTURE_CHANGE)
				return Option.ConstApp("string_live_game_event_structure_change_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STYLE_CHANGE_ALL_OUT_DEFEND)
				return Option.ConstApp("string_game_gui_style_all_out_defend_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STYLE_CHANGE_DEFEND)
				return Option.ConstApp("string_game_gui_style_defend_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STYLE_CHANGE_BALANCED)
				return Option.ConstApp("string_game_gui_style_balanced_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STYLE_CHANGE_ATTACK)
				return Option.ConstApp("string_game_gui_style_attack_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_STYLE_CHANGE_ALL_OUT_ATTACK)
				return Option.ConstApp("string_game_gui_style_all_out_attack_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_BOOST_CHANGE_ANTI)
				return Option.ConstApp("string_game_gui_boost_anti_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_BOOST_CHANGE_OFF)
				return Option.ConstApp("string_game_gui_boost_off_icon");
			else if(eventType == LiveGameEventType.LIVE_GAME_EVENT_BOOST_CHANGE_ON)
				return Option.ConstApp("string_game_gui_boost_on_icon");
			else
				return "";
		}

		/** Return the appropriate symbol name from the constants
		 * for the user history type. */
		public static string GetUserHistoryIcon(UserHistoryType historyType)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.GetUserHistoryIcon");
#endif
			switch(historyType)
			{
			default:
				Debug.PrintMessage ("treeview_helper_get_user_history_icon: unknown type {0}.\n", historyType);
				return null;
			case UserHistoryType.USER_HISTORY_START_GAME:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_start_game_icon");
			case UserHistoryType.USER_HISTORY_FIRE_FINANCE:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_fire_finances_icon");
			case UserHistoryType.USER_HISTORY_FIRE_FAILURE:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_fire_failure_icon");
			case UserHistoryType.USER_HISTORY_JOB_OFFER_ACCEPTED:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_job_offer_accepted_icon");
			case UserHistoryType.USER_HISTORY_END_SEASON:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_end_season_icon");
			case UserHistoryType.USER_HISTORY_WIN_FINAL:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_win_final_icon");
			case UserHistoryType.USER_HISTORY_LOSE_FINAL:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_lose_final_icon");
			case UserHistoryType.USER_HISTORY_PROMOTED:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_promoted_icon");
			case UserHistoryType.USER_HISTORY_RELEGATED:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_relegated_icon");
			case UserHistoryType.USER_HISTORY_REACH_CUP_ROUND:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_reach_cup_round_icon");
			case UserHistoryType.USER_HISTORY_CHAMPION:
				return Option.ConstApp("string_treeview_helper_user_history_symbol_champion_icon");
			}
			return null;
		}

		/** Return a new pixbuf created from the specified filename.
		 * @param filename Name of a pixmap file located in one of the support directories.
		 * @return A new pixbuf or NULL on error.
		 **/
		public static Pixbuf PixbufFromFilename(string filename)
		{
			Pixbuf symbol = null;
			if (!string.IsNullOrEmpty (filename)) {
				string symbolFile = FileHelper.FindSupportFile (filename, false);
				if (!string.IsNullOrEmpty (symbolFile)) {
					symbol = new Pixbuf (symbolFile);
				}
			}
			return symbol;
		}

		/** Unref an object if non-null (mostly it's a pixbuf added to a treeview).*/
		public static void Unref(object obj)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.Unref");
#endif
		}

		public static void ShowContributors(TreeView treeview)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowContributors");
#endif
			string helpFile = FileHelper.FindSupportFile("bygfoot_help", true);
			if (string.IsNullOrEmpty(helpFile))
			{
				GameGUI.ShowWarning(Mono.Unix.Catalog.GetString("Didn't find file 'bygfoot_help'."));
				return;
			}
			OptionList helpList = null;
			FileHelper.LoadOptFile(helpFile, ref helpList, false);
			
			// Set treeview properties
			treeview.Selection.Mode = SelectionMode.None;
			treeview.RulesHint = false;
			treeview.HeadersVisible = false;
			
			TreeViewColumn column = new TreeViewColumn();
			treeview.AppendColumn(column);
			CellRenderer cell = TreeViewHelper.TextCellRenderer();
			column.PackStart(cell, true);
			column.AddAttribute(cell, "markup", 0);
			
			ListStore ls = new ListStore(typeof(string));
			for (int i = 0; i < helpList.list.Count; i++)
			{
				TreeIter iter = ls.Append();
				OptionStruct option = (OptionStruct)helpList.list[i];
				if (option.name.StartsWith("string_contrib_title"))
				{
					string value = string.Format("\n<span {0}>{1}</span>", Option.ConstApp("string_help_window_title_attribute"), option.stringValue);
					ls.SetValue(iter, 0, value);
				}
				else
				{
					ls.SetValue(iter, 0, option.stringValue);
				}
			}
			
			treeview.Model = ls;
		}

		public static TreeModel CreateLeagueList(Country country)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateLeagueList");
#endif
			TreeStore ls = new TreeStore (typeof(string));
			TreeIter iter = ls.AppendNode ();
			ls.SetValue (iter, 0, Catalog.GetString ("Current league"));
			foreach (League league in country.Leagues) {
				iter = ls.AppendNode ();
				ls.SetValue (iter, 0, league.name);
			}
			return ls;
		}

		/** Create the model for the startup country files combo.
		 * @param countryList The List of country files found */
		public static TreeModel CreateCountryList(string[] countryList)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateCountryList");
#endif
			TreeStore ls = new TreeStore(typeof(Pixbuf), typeof(string));
			TreeIter iterContinent = new TreeIter ();
			string currentContinent = string.Empty;
			foreach (string country in countryList) {
				string[] elements = country.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
				string continent = elements [0];
				if (continent != currentContinent) {
					iterContinent = ls.AppendNode ();
					ls.SetValue(iterContinent, 1, continent);
					currentContinent = continent;
				}

				Pixbuf flag = PixbufFromFilename (string.Format ("flag_{0}.png", elements [1]));
				TreeIter iterCountry = ls.AppendNode (iterContinent);
				ls.SetValues(iterCountry, flag, elements[1]);
			}
			return ls;
		}

		public static bool SearchEqualTeams(TreeModel model, int column, string key, TreeIter iter)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.SearchEqualTeams");
#endif
			return false;
		}

		public static void RenderTeamName(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.RenderTeamName");
#endif
			Team team = (Team)model.GetValue (iter, 2);
			(cell as CellRendererText).Text = team.name;
		}

		public static void RenderAverageSkill(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.RenderTeamName");
#endif
			Team team = (Team)model.GetValue (iter, 4);
			(cell as CellRendererText).Text = team.AverageTalent.ToString ();
		}
	}
}
