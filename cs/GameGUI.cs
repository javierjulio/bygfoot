using System;
using System.Collections.Generic;

namespace bygfoot
{
	/** Which parts of the main window get affected
		 * by a live game pause. */
	enum MainWindowInensitiveItems
	{
		INSENSITIVE_ITEM_TOOLBAR = 0,
		INSENSITIVE_ITEM_MENU_FILE,
		INSENSITIVE_ITEM_MENU_OPTIONS,
		INSENSITIVE_ITEM_MENU_FIGURES,
		INSENSITIVE_ITEM_MENU_SCOUT,
		INSENSITIVE_ITEM_MENU_PHYSIO,
		INSENSITIVE_ITEM_MENU_BROWSE_TEAMS,
		INSENSITIVE_ITEM_MENU_YOUTH_ACADEMY,
		INSENSITIVE_ITEM_MENU_TRAINING_CAMP,
		INSENSITIVE_ITEM_MENU_SHOW_JOB_EXCHANGE,
		INSENSITIVE_ITEM_MENU_PUT_ON_TRANSFER_LIST,
		INSENSITIVE_ITEM_MENU_REMOVE_FROM_TRANSFER_LIST,
		INSENSITIVE_ITEM_MENU_FIRE,
		INSENSITIVE_ITEM_MENU_MOVE_TO_YOUTH_ACADEMY,
		INSENSITIVE_ITEM_MENU_USER,
		INSENSITIVE_ITEM_MENU_FINANCES_STADIUM,
		INSENSITIVE_ITEM_MENU_HELP,
		INSENSITIVE_ITEM_MENU_BROWSE_PLAYERS,
		INSENSITIVE_ITEM_MENU_OFFER_CONTRACT,
		INSENSITIVE_ITEM_END
	};

	enum MainWindowShowItems
	{
		SHOW_ITEM_RESET_BUTTON = 0,
		SHOW_ITEM_RESET_MENU,
		SHOW_ITEM_END
	};

	public class GameGUI
	{
		/** Show the live game in the live game window.
		 * @param unit The current unit we show. */
		public static void LiveGameShowUnit(LiveGameUnit unit)
		{
#if DEBUG
			Console.WriteLine("GameGUI.LiveGameShowUnit");
#endif
			/*
    gchar buf[SMALL];
    gfloat sleep_factor = (unit->time == 3) ? 
	const_float("float_game_gui_live_game_speed_penalties_factor") : 1;
    gfloat fraction = (gfloat)live_game_unit_get_minute(unit) / 90;
    GtkProgressBar *progress_bar =
	GTK_PROGRESS_BAR(lookup_widget(window.live, "progressbar_live"));
    GtkHScale *hscale = 
	GTK_HSCALE(lookup_widget(window.live, "hscale_area"));
    GtkWidget *button_pause = lookup_widget(window.live, "button_pause"),
	*button_resume = lookup_widget(window.live, "button_resume"),
	*button_live_close = lookup_widget(window.live, "button_live_close"),
	*eventbox_poss[2] = {lookup_widget(window.live, "eventbox_poss0"),
			     lookup_widget(window.live, "eventbox_poss1")};
    GdkColor color;

    if(unit->event.type == LIVE_GAME_EVENT_START_MATCH)
	treeview_live_game_show_initial_commentary(unit);
    else if(option_int("int_opt_user_live_game_verbosity", 
		       &usr(stat2).options) > unit->event.verbosity)
	treeview_live_game_show_commentary(unit);

    treeview_live_game_show_result(unit);

    gdk_color_parse (const_app("string_live_game_possession_color"), &color);
    gtk_widget_modify_bg(eventbox_poss[unit->possession], GTK_STATE_NORMAL, &color);
    gtk_widget_modify_bg(eventbox_poss[!unit->possession], GTK_STATE_NORMAL, NULL);

    if(option_int("int_opt_user_show_tendency_bar",
		  &usr(stat2).options))
	game_gui_live_game_set_hscale(unit, hscale);
    else
	gtk_widget_hide(GTK_WIDGET(hscale));

    sprintf(buf, "%d.", live_game_unit_get_minute(unit));
    gtk_progress_bar_set_fraction(progress_bar, (fraction > 1) ? 1 : fraction);
    gtk_progress_bar_set_text(progress_bar, buf);
    g_usleep((gint)rint(sleep_factor * 
			(gfloat)(const_int("int_game_gui_live_game_speed_max") +
				 (option_int("int_opt_user_live_game_speed", &usr(stat2).options) * 
				  const_int("int_game_gui_live_game_speed_grad")))));

    while(gtk_events_pending())
	gtk_main_iteration();

    if(unit->event.type == LIVE_GAME_EVENT_START_MATCH)
    {
	gtk_widget_set_sensitive(button_live_close, (stat1 == STATUS_SHOW_LAST_MATCH));
	gtk_widget_set_sensitive(button_pause, TRUE);
	gtk_widget_set_sensitive(button_resume, FALSE);
	gtk_widget_grab_focus(button_pause);
    }
    else if(unit->event.type == LIVE_GAME_EVENT_END_MATCH)
    {
	gtk_widget_set_sensitive(button_live_close, TRUE);
	gtk_widget_set_sensitive(button_pause, FALSE);
	gtk_widget_set_sensitive(button_resume, FALSE);
	gui_set_sensitive_lg_meters(FALSE);
	gtk_widget_grab_focus(button_live_close);

	game_gui_set_main_window_sensitivity(FALSE);
    }
    else if(unit->event.type == LIVE_GAME_EVENT_PENALTIES)
    {
	gtk_widget_set_sensitive(button_pause, (stat1 == STATUS_SHOW_LAST_MATCH));
	gtk_widget_set_sensitive(button_resume, FALSE);
    } */
		}

		/** Set the area scale position and color in the live game window.
		 * @param unit The current unit.
		 * @param hscale The scale widget. */
		public static void LiveGameSetHScale(LiveGameUnit unit, Gtk.HScale hscale)
		{
#if DEBUG
			Console.WriteLine("GameGUI.LiveGameSetHScale");
#endif
		}

		/** Show the player list of the opposing team in the live game
		 * window. */
		public static void LiveGameShowOpponent()
		{
#if DEBUG
			Console.WriteLine("GameGUI.LiveGameShowOpponent");
#endif
		}

		/** Look up the widgets in the main window. */
		public static void GetRadioItems(List<Gtk.Widget> style, List<Gtk.Widget> scout,
										 List<Gtk.Widget> physio, List<Gtk.Widget> boost,
										 List<Gtk.Widget> yc, List<Gtk.Widget> ycPosRef)
		{
#if DEBUG
			Console.WriteLine("GameGUI.GetRadioItems");
#endif
		}

		/** Set information like season, user, week etc. into the appropriate labels. */
		public static void SetMainWindowHeader()
		{
#if DEBUG
			Console.WriteLine("GameGUI.SetMainWindowHeader");
#endif
		}

		/** Set the average skills of the current team
		 * into the appropriate labels. */
		public static void WriteAvSkills(Team team)
		{
#if DEBUG
			Console.WriteLine("GameGUI.WriteAvSkills");
#endif
		}

		/** Set the images for the style and boost meters to the appropriate values
		 * from the team settings. */
		public static void WriteMeterImages(Team team, List<Gtk.Image> style, List<Gtk.Image> boost)
		{
#if DEBUG
			Console.WriteLine("GameGUI.WriteMeterImages");
#endif
		}

		/** Set the images for the style and boost meters in the main
		 * window and the live game window. */
		public static void WriteMeters(Team team)
		{
#if DEBUG
			Console.WriteLine("GameGUI.WriteMeters");
#endif
		}

		/** Activate the appropriate radio items for
		 * playing style etc. according to the user settings. */
		public static void WriteRadioItems()
		{
#if DEBUG
			Console.WriteLine("GameGUI.WriteRadioItems");
#endif
		}

		/** Set playing style etc. variables according to
		 * the items.
		 * @param widget The widget that received a click. */
		public static void ReadRadioItems()
		{
#if DEBUG
			Console.WriteLine("GameGUI.ReadRadioItems");
#endif
		}

		/** Show the main menu. */
		public static void ShowMain()
		{
#if DEBUG
			Console.WriteLine("GameGUI.ShowMain");
#endif
		}

		/** Print a message in the message area. */
		public static void PrintMessage(string format, params object[] args)
		{
#if DEBUG
			Console.WriteLine("GameGUI.PrintMessage");
#endif
			string msg = string.Format(format, args);

			// TODO
			//gtk_entry_set_text(GTK_ENTRY(lookup_widget(window.main, "entry_message")), text);

			if (Variables.timeout_id != -1) {
				// TODO: Confirm
				GLib.Source.Remove ((uint)Variables.timeout_id);
			}

			uint interval = (uint)Option.ConstInt ("int_game_gui_message_duration") * 1000;
			Variables.timeout_id = (int)GLib.Timeout.Add (interval, new GLib.TimeoutHandler(ClearEntryMessage));
		}

		/** Source function for the delay printing function. */
		public static bool PrintMessageSource(object data)
		{
#if DEBUG
			Console.WriteLine("GameGUI.PrintMessageSource");
#endif
			PrintMessage(data.ToString(), null);
			return false;
		}

		/** Print a message after some seconds of delay. */
		public static void PrintMessageWithDelay(string format, params object[] args)
		{
#if DEBUG
			Console.WriteLine("GameGUI.PrintMessageWithDelay");
#endif
		}

		/** Function that gets called from time to time. */
		public static bool ClearEntryMessage()
		{
#if DEBUG
			Console.WriteLine("GameGUI.ClearEntryMessage");
#endif
			// TODO
			//if(window.main != NULL)
			//	gtk_entry_set_text(GTK_ENTRY(lookup_widget(window.main, "entry_message")), "");

			return false;
		}

		/** Set appropriate parts of the main window insensitive when
		 * the live game is paused or resumed.
		 * @param value Whether we set sensitive or insensitive. */
		public static void SetMainWindowSensitivity()
		{
#if DEBUG
			Console.WriteLine("GameGUI.SetMainWindowSensitivity");
#endif
		}

		/** Show a window with a warning.
		 * @param text The text to show in the window. */
		public static void ShowWarning(string format, params object[] args)
		{
#if DEBUG
			Console.WriteLine("GameGUI.ShowWarning");
#endif
			string msg = string.Format(format, args);
			if (Option.OptInt("int_opt_prefer_messages") != 0 && Variables.Window.main != null)
				PrintMessage(msg, null);
			else
			{
				Window.Create(AppWindows.WINDOW_WARNING);
				WarningWindow.SetText(msg);
			}
		}

		/** Show the job offer window.
		 * @param team The team offering the job or NULL if we're looking
		 * at a job offer from the job exchange.
		 * @param job The job pointer or NULL (depends on whether we're looking
		 * at a job offer from the job exchange).
		 * @param type The offer type (eg. whether the user's been fired). */
		public static void ShowJobOffer(Team team, Job job, int type)
		{
#if DEBUG
			Console.WriteLine("GameGUI.ShowJobOffer");
#endif
		}

		/** Write the checkbuttons in the menus. */
		public static void WriteCheckItems()
		{
#if DEBUG
			Console.WriteLine("GameGUI.WriteCheckItems");
#endif
		}

		/** Change the options according to the check menu widgets. */
		public static void ReadCheckItems()
		{
#if DEBUG
			Console.WriteLine("GameGUI.ReadCheckItems");
#endif
		}

		/** Set the appropriate text into the labels in the help window. 
		 * @param help_list The stuff loaded from the bygfoot_help file. */
		public static void SetHelpLabels()
		{
#if DEBUG
			Console.WriteLine("GameGUI.SetHelpLabels");
#endif
		}

		/** Set the money of the current team into the label. */
		public static void WriteMoney()
		{
#if DEBUG
			Console.WriteLine("GameGUI.WriteMoney");
#endif
		}
	}
}
