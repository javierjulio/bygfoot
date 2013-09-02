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
		/**
		 * Creates the model for the treeview in the team selection window.
		 * The model contains a list of all the teams from the leagues in
		 * the country::leagues array; if show_cup_teams is TRUE, the
		 * teams from international cups are shown, too.
		 * @param show_cup_teams Whether or not teams from international
		 * cups are shown.
		 * @param show_user_teams Whether or not user teams are shown.
		 * @return The model containing the team names.
		 **/
		public static TreeModel CreateTeamSelectionList(Country country, bool showCupTeams, bool showUserTeams)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateTeamSelectionList");
#endif
			int count = 1;
			TreeStore ls = new TreeStore(typeof(int), typeof(Gdk.Pixbuf), typeof(Team), typeof(string), typeof(Team));
			for (int i = 0; i < country.leagues.Count; i++) {
				League league = country.leagues [i];
				for (int j = 0; j < league.teams.Count; j++) {
					Team team = league.teams [j];
					if (!team.IsUserTeam())
					{
						Pixbuf symbol = PixbufFromFilename (!string.IsNullOrEmpty (team.symbol) ? team.symbol : league.symbol);
						TreeIter iter = ls.AppendNode();
						ls.SetValues (iter, count++, symbol, team, league.name, team);
					}
				}
			}
			if (showCupTeams) {
			}
			return ls;
		}

		/**
		 * Sets up the treeview for the team selection window.
		 * Columns and cell renderers are added etc.
		 * @param treeview The treeview that gets configured.
		 **/
		public static void SetupTeamSelectionTreeview(TreeView treeview)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateTeamSelectionList");
#endif
			//treeview.SelectionMode = GTK_SELECTION_BROWSE;
			treeview.HeadersVisible = true;
			treeview.RulesHint = true;

			treeview.SearchColumn = 2;
			treeview.SearchEqualFunc = SearchEqualTeams;

			/* Numbering the teams */
			TreeViewColumn column = new TreeViewColumn ();
			treeview.AppendColumn (column);
			CellRenderer renderer = TextCellRenderer ();
			column.PackStart (renderer, true);
			column.AddAttribute (renderer, "text", 0);

			/* Flags */
			column = new TreeViewColumn ();
			treeview.AppendColumn (column);
			renderer = new CellRendererPixbuf ();
			column.PackStart (renderer, true);
			column.AddAttribute (renderer, "pixbuf", 1);

			/* Team column */
			column = new TreeViewColumn ();
			column.Title = Catalog.GetString ("Team");
			treeview.AppendColumn (column);
			renderer = TextCellRenderer ();
			column.PackStart (renderer, true);
			column.SetCellDataFunc (renderer, RenderTeamName);

			/* League column */
			column = new TreeViewColumn ();
			column.Title = Catalog.GetString ("League");
			treeview.AppendColumn (column);
			renderer = TextCellRenderer ();
			column.PackStart (renderer, true);
			column.AddAttribute (renderer, "text", 3);

			/* Average skill */
			column = new TreeViewColumn ();
			column.Title = Catalog.GetString ("Av.Sk.");
			column.SortColumnId = 4;
			treeview.AppendColumn (column);
			renderer = TextCellRenderer ();
			column.PackStart (renderer, true);
			column.SetCellDataFunc (renderer, RenderAverageSkill);
		}

		/** Shows the list of teams in the game.
		 * If show_cup_teams is TRUE, the teams from
		 * international cups are shown, too.
		 * @param treeview The treeview we show the list in.
		 * @param show_cup_teams Whether or not teams from international
		 * cups are shown.
		 * @param show_user_teams Whether or not user teams are shown.
		 **/
		public static void ShowTeamList(TreeView treeview, bool showCupTeams, bool showUserTeams)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowTeamList");
#endif
			TreeModel model = CreateTeamSelectionList (Variables.Country, showCupTeams, showUserTeams);
			TreePath path = new TreePath ("0");

			Clear (treeview);

			SetupTeamSelectionTreeview (treeview);
			treeview.Model = model;

			TreeSelection selection = treeview.Selection;
			selection.SelectPath (path);
		}

		/** Create the list store for a player list. 
		 * @param players The array containing the players.
		 * @param attributes An array containing the attributes we show.
		 * @param max The size of the attribute array.
		 * @param separator Whether we draw a blank line after the 11th player.
		 * @param status Whether player status is shown (takes two columns). */
		public static TreeModel CreatePlayerList(List<Player> players, List<int> attributes, int max, bool showSeparator, bool sortable, bool status)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowTeamList");
#endif
			// TODO
			return null;
		}

		/** Set up the tree view for a player list */
		public static void SetupPlayerList(TreeView treeview, List<int> attributes, int max, bool showSeparator, bool transferList, bool sortable)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.SetupPlayerList");
#endif
		}

		/** Fill a treeview with the players from the pointer array. Show
		 * player attributes according to 'attrib'.
		 * @param treeview The treeview we fill.
		 * @param players The pointer array with the players. We free it afterwards.
		 * @param attrib The #PlayerListAttribute that determines which attributes to show.
		 * @param show_separator Whether we draw a blank line after the 11th player.
		 * @param transfer_list Whether we show the second player list used for transfer view. */
		public static void ShowPlayerList(TreeView treeview, List<Player> players, PlayerListAttribute attribute, bool showSeparator, bool transferList)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowPlayerList");
#endif
		}

		/** Show the list of the current user's players in the left view. */
		public static void ShowUserPlayerList()
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowUserPlayerList");
#endif
		}

		/** Show the player list of a foreign team depending on the
		 * scout quality. */
		public static void ShowPlayerListTeam(TreeView treeview, Team team, int scout)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowPlayerListTeam");
#endif
		}

		/** Show the commentary and the minute belonging to the unit. 
		 * @param unit The #LiveGameUnit we show. */
		public static void LiveGameShowCommentary(LiveGameUnit unit)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.LiveGameShowCommentary");
#endif
		}

		/** Create the list store for the live game 
		 * commentary treeview.
		 * @param unit The unit we show.
		 * @return The ls. */
		public static TreeModel LiveGameCreateInitCommentary(LiveGameUnit unit)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.LiveGameCreateInitCommentary");
#endif
			return null;
		}

		/** Set up the commentary treeview for the live game. */
		public static void LiveGameSetupCommentary()
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.LiveGameSetupCommentary");
#endif
		}

		/** Show the first commentary of the live game
		 * @param unit The #LiveGameUnit we show. */
		public static void LiveGameShowInitialCommentary(LiveGameUnit unit)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.LiveGameShowInitialCommentary");
#endif
		}

		/** Fill the ls for the live game result treeview.
		 * @param unit The current live game unit.
		 * @return The ls we created. */
		public static TreeModel LiveGameCreateResult(LiveGameUnit unit)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.LiveGameCreateResult");
#endif
			return null;
		}

		/** Set up the treeview columns for the result. */
		public static void LiveGameSetupResult()
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.LiveGameSetupResult");
#endif
		}

		/** Fill a tree model with the users. */
		public static TreeModel CreateUsers()
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateUsers");
#endif
			TreeStore ls = new TreeStore(typeof(int), typeof(string), typeof(string), typeof(string));
			for (int i = 0; i < Variables.Users.Count; i++) {
				TreeIter iter = ls.AppendNode ();
				ls.SetValues (iter, i + 1, Variables.Users [i].Name, Variables.Users [i].Team.name);

				if (Variables.status [0] == StatusValue.STATUS_TEAM_SELECTION) {
					if (Variables.Users [i].Scout == Quality.QUALITY_NONE) {
						ls.SetValue (iter, 3, Variables.LeagueCupGetName(Variables.Users[i].Team.clid));
					} else {
						int index = (int)Variables.Users [i].Scout;
						ls.SetValue (iter, 3, Variables.Country.leagues[index].name);
					}
				} else {
					ls.SetValue (iter, 3, Variables.LeagueCupGetName(Variables.Users[i].Team.clid));
				}
			}
			return ls;
		}

		/** Set up the users treeview.
		 * @param treeview The treeview we use. */
		public static void SetupUsers(TreeView treeview)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.SetupUsers");
#endif
			string[] titles = new string[] {
				"",
				Catalog.GetString ("Name"),
				Catalog.GetString ("Team"),
				Catalog.GetString ("League")
			};
			//treeview.SelectionMode = GTK_SELECTION_SINGLE;
			treeview.RulesHint = false;
			treeview.HeadersVisible = true;

			for (int i = 0; i < 4; i++) {
				TreeViewColumn column = new TreeViewColumn ();
				column.Title = titles [i];
				treeview.AppendColumn (column);
				CellRenderer renderer = TextCellRenderer ();
				column.PackStart (renderer, i != 3);
				column.AddAttribute (renderer, "text", i);
			}
		}

		/** Show the list of users at startup.
		 * @param treeview The treeview we use. */
		public static void ShowUsers(TreeView treeview)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowUsers");
#endif
			Clear (treeview);
			SetupUsers (treeview);
			treeview.Model = CreateUsers ();
		}

		/** Fill a model with live game stats.
		 * @param live_game The live game.  */
		public static TreeModel CreateGameStats(LiveGame liveGame)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateGameStats");
#endif
			return null;
		}

		/** Configure a treeview to show game stats.
		 * @param treeview The treeview. */
		public static void SetupGameStats(TreeView treeview)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.SetupGameStats");
#endif
		}

		/** Show the stats of the live game in a treeview.
		 * @param live_game The live game. */
		public static void ShowGameStats(TreeView treeview, LiveGame liveGame)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.ShowGameStats");
#endif
		}
	}
}
