using System;
using System.IO;
using System.Xml;
using Gtk;

namespace bygfoot
{
	public class StartupWindow
	{
		[Glade.Widget]
		static Window window_startup = null;

		[Glade.Widget]
		static TreeView treeview_startup = null;

		[Glade.Widget]
		static ComboBox combo_country = null;

		public static Window Create()
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
			AppWindow.CreateWindow(AppWindowType.WINDOW_STARTUP);
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

			if (!string.IsNullOrEmpty (Variables.Country.sid))
				ShowTeamList (Variables.Country.sid);
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
		}

		public static void on_button_add_player_clicked(object sender, EventArgs e)
		{
#if DEBUG
			Console.WriteLine("on_button_add_player_clicked");
#endif
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
			AppWindow.Destroy (ref Variables.Window.startup);
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
	}
}

