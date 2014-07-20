using System;
using System.IO;
using System.Xml;
using Gtk;

namespace bygfoot
{
	public class StartupWindow
	{
		[Glade.Widget]
		private static Gtk.Window window_startup = null;

		[Glade.Widget]
		private static TreeView treeview_startup = null;

		[Glade.Widget]
		private static ComboBox combo_country = null;

		[Glade.Widget]
		private static ComboBox combobox_start_league = null;

		[Glade.Widget]
		private static Button button_add_player = null;

		[Glade.Widget]
		private static TreeView treeview_users = null;

		[Glade.Widget]
		private static Entry entry_player_name = null;

		[Glade.Widget]
		private static Button team_selection_ok = null;

		[Glade.Widget]
		private static RadioButton radiobutton_team_def_load = null;

		[Glade.Widget]
		private static RadioButton radiobutton_team_def_names = null;

		[Glade.Widget]
		private static CheckButton checkbutton_randomise_teams = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc.glade", "window_startup", typeof(StartupWindow));

			/* Store pointers to all widgets, for use by lookup_widget(). */
			/*
			Support.HookupObject(startup, builder, "combo_country");
			Support.HookupObject(startup, builder, "treeview_startup");
			Support.HookupObject(startup, builder, "combobox_start_league");
			Support.HookupObject(startup, builder, "button_add_player");
			Support.HookupObject(startup, builder, "treeview_users");
			Support.HookupObject(startup, builder, "entry_player_name");
			Support.HookupObject(startup, builder, "team_selection_ok");
			Support.HookupObject(startup, builder, "radiobutton_team_def_load");
			Support.HookupObject(startup, builder, "radiobutton_team_def_names");
			Support.HookupObject(startup, builder, "checkbutton_randomise_teams");
			*/

			return window_startup;
		}

		public static void ShowStartup()
		{
#if DEBUG
			Console.WriteLine("StartupWindow.ShowStartup");
#endif
			Window.Create(AppWindows.WINDOW_STARTUP);
			string lastCountry = FileHelper.LoadTextFromSaves("last_country");
			string[] countryFiles = FileHelper.GetCountryFiles();
			if (countryFiles.Length == 0)
				Program.ExitProgram (ExitCodes.EXIT_NO_COUNTRY_FILES, "Didn't find any country definition files in the support directories.");

			combo_country.Clear ();
			CellRenderer renderer = new CellRendererPixbuf ();
			combo_country.PackStart (renderer, false);
			combo_country.SetAttributes (renderer, "pixbuf", 0);

			renderer = TreeViewHelper.TextCellRenderer ();
			combo_country.PackStart (renderer, true);
			combo_country.SetAttributes (renderer, "text", 1);

			Language.PickCountry (countryFiles);
			TreeModel model = TreeViewHelper.CreateCountryList (countryFiles);
			combo_country.Model = model;
			combo_country.SetCellDataFunc (renderer, IsCapitalSensitive);

			if (!string.IsNullOrEmpty (Variables.Country.SId))
				ShowTeamList (Variables.Country.SId);
			else if (!string.IsNullOrEmpty (lastCountry))
				ShowTeamList (lastCountry);
			else {
				string[] elements = countryFiles[countryFiles.Length - 1].Split(new char[] { Path.DirectorySeparatorChar });
				ShowTeamList (elements[1]);
			}
		}

		public static void ShowTeamList(string countryName)
		{
#if DEBUG
			Console.WriteLine("ShowTeamList");
#endif
			xml_read_country (countryName, null);
			TreeViewHelper.ShowTeamList (treeview_startup, false, false);
			ShowLeaguesCombo ();
			button_add_player.Sensitive = true;
		}

		/** Show the league list in the combo box
		 * in the startup window. */
		public static void ShowLeaguesCombo()
		{
#if DEBUG
			Console.WriteLine("ShowLeaguesCombo");
#endif
			combobox_start_league.Clear ();
			combobox_start_league.RemoveText (1);

			CellRenderer renderer = TreeViewHelper.TextCellRenderer ();
			combobox_start_league.PackStart (renderer, false);
			combobox_start_league.SetAttributes (renderer, "text", 0);

			TreeModel model = TreeViewHelper.CreateLeagueList (Variables.Country);
			combobox_start_league.Model = model;
			combobox_start_league.Active = 0;
		}

		public static void xml_read_country(string countryName, Country countryArg)
		{
#if DEBUG
			Console.WriteLine("xml_read_country");
#endif
			Country country = countryArg == null ? Variables.Country : countryArg;
			if (countryArg == null) {
				Option.SettingInt("int_opt_disable_finances", 0);
				Option.SettingInt("int_opt_disable_transfers", 0);
				Option.SettingInt("int_opt_disable_stadium", 0);
				Option.SettingInt("int_opt_disable_contracts", 0);
				Option.SettingInt("int_opt_disable_boost_on", 0);
				Option.SettingInt("int_opt_disable_ya", 0);
				Option.SettingInt("int_opt_disable_training_camp", 0); //***ML***
			}
			country.Leagues.Clear ();
			country.Load (countryName);
		}

		public static void IsCapitalSensitive(CellLayout cellLayout, CellRenderer cell, TreeModel treeModel, TreeIter iter)
		{
			cell.Sensitive = !treeModel.IterHasChild (iter);
		}

		public static void on_team_selection_cancel_clicked(object o, DeleteEventArgs args)
		{
			on_team_selection_cancel_clicked (o, (EventArgs)args);
		}

		public static void on_combo_country_changed(object o, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_combo_country_changed");
#endif
			TreeIter iter;
			combo_country.GetActiveIter (out iter);
			if (!combo_country.Model.IterHasChild (iter)) {
				string country = combo_country.Model.GetValue (iter, 1).ToString ();
				ShowTeamList (country);
			} else {
				button_add_player.Sensitive = false;
			}
		}

		public static void on_treeview_users_button_press_event(object sender, ButtonPressEventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_treeview_users_button_press_event");
#endif
		}

		public static void on_entry_player_name_activate(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_entry_player_name_activate");
#endif
			on_button_add_player_clicked (null, null);
		}

		public static void on_button_add_player_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_add_player_clicked");
#endif
			AddPlayer ();
		}

		public static void on_team_selection_ok_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_team_selection_ok_clicked");
#endif
		}

		public static void on_button_team_selection_back_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_team_selection_back_clicked");
#endif
			Window.Destroy (ref Variables.Window.startup);
			Variables.status [0] = StatusValue.STATUS_SPLASH;
			SplashWindow.ShowSplash ();
		}

		public static void on_team_selection_cancel_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_team_selection_cancel_clicked");
#endif
			Program.ExitProgram (ExitCodes.EXIT_OK, null);
		}

		/** Start a new game after users and teams are selected. */
		private void StartGame()
		{
			#if DEBUG
			Console.WriteLine("StartupWindow.StartGame");
			#endif

			Variables.status [0] = StatusValue.STATUS_MAIN;
			// Option.Add (Variables.Options, "int_opt_load_defs", 1, null);
			// Option.Add (Variables.Options, "int_opt_randomise_teams", 0, null);

			if (checkbutton_randomise_teams.Active)
				Option.SettingInt ("int_opt_randomise_teams", 1);

			if (radiobutton_team_def_load.Active)
				Option.SettingInt ("int_opt_load_defs", 1);
			else if (radiobutton_team_def_names.Active)
				Option.SettingInt ("int_opt_load_defs", 2);
			else
				Option.SettingInt ("int_opt_load_defs", 0);

			// start_new_game();
			Window.Destroy (ref Variables.Window.startup);
			//file_store_text_in_saves("last_country", country.sid);

			if (Option.OptInt ("int_opt_calodds") == 0) // if (!Option.OptInt ("int_opt_calodds"))
			{
				foreach (User user in Variables.Users)
					user.SetupTeamNewGame ();

				Window.Create (AppWindows.WINDOW_MAIN);

				GameGUI.ShowMain();
				/*if (statp != NULL)
				{
					debug_action((gchar*)statp);
					g_free(statp);
					statp = NULL;
				} */
			}
			else {
				//debug_calibrate_betting_odds(opt_int("int_opt_calodds_skilldiffmax"), opt_int("int_opt_calodds_matches"));
				Program.ExitProgram (ExitCodes.EXIT_OK, null);
			}
		}

		/** Add a user to the users array. */
		private static void AddPlayer()
		{
			#if DEBUG
			Console.WriteLine("StartupWindow.AddPlayer");
			#endif
			string playerName = entry_player_name.Text;
			User newUser = new User ();
			Team team = (Team)TreeViewHelper.GetPointer (treeview_startup, 2);
			int startLeague = combobox_start_league.Active;

			if (!string.IsNullOrEmpty (playerName))
				newUser.Name = playerName;
			entry_player_name.Text = string.Empty;

			newUser.Team = team;
			newUser.TeamId = team.id;
			newUser.Scout = (Quality)(startLeague == 0 || team.clid == Variables.Country.Leagues [startLeague - 1].id ? -1 : startLeague - 1);
			Variables.Users.Add (newUser);

			TreeViewHelper.ShowUsers (treeview_users);
			TreeViewHelper.ShowTeamList (treeview_startup, false, false);

			combobox_start_league.Active = 0;

			if (Variables.Users.Count == 1) {
				team_selection_ok.Sensitive = true;
				combo_country.Sensitive = false;
			}
		}

		/** Remove a user from the users list. 
		 * @param event The mouse click event on the treeview. */
		private void RemovePlayer(Gdk.EventButton btnEvent)
		{
			#if DEBUG
			Console.WriteLine("StartupWindow.RemovePlayer");
			#endif

			if(!TreeViewHelper.SelectRow(treeview_users, btnEvent))
				return;

			User.Remove(TreeViewHelper.GetIndex(treeview_users, 0) - 1, false);

			TreeViewHelper.ShowUsers (treeview_users);
			TreeViewHelper.ShowTeamList (treeview_startup, false, false);

			if (Variables.Users.Count == 0) {
				team_selection_ok.Sensitive = false;
				combo_country.Sensitive = true;
			}
		}
	}
}

