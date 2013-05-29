using System;
using System.IO;
using System.Collections.Generic;
using Gtk;
using Gdk;
using Mono.Unix;

namespace bygfoot
{
	public class TreeViewHelper
	{
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

		public static CellRenderer TextCellRenderer()
		{
			CellRendererText renderer = new CellRendererText();

			string fontName = Option.OptStr("string_opt_font_name");
			if (!string.IsNullOrEmpty(fontName))
				renderer.Font = fontName;

			return renderer;
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

		/** Create the model for the startup country files combo.
		 * @param countryList The List of country files found */
		public static TreeModel CreateCountryList(string[] countryList)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateCountryList");
#endif
			TreeStore ls = new TreeStore(typeof(Pixbuf), typeof(string));
			TreeIter iterContinent;
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

			//treeview_helper_clear(treeview);

			SetupTeamSelectionTreeview (treeview);
			treeview.Model = model;

			TreeSelection selection = treeview.Selection;
			selection.SelectPath (path);
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
