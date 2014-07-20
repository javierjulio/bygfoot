using System;

namespace bygfoot
{
	public class OptionsWindow
	{
		[Glade.Widget]
		static Gtk.Window window_options = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton1 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton10 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton11 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton12 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton13 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton14 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton15 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton16 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton17 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton18 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton19 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton2 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton20 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton21 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton22 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton23 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton24 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton25 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton26 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton27 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton28 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton29 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton3 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton30 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton31 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton32 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton33 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton34 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton35 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton36 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton4 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton5 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton6 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton7 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton8 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton9 = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_autosave = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_auto_sub = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_bet_show_all_leagues = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_bet_show_cups = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_bet_show_only_recent = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_conf_quit = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_conf_unfit = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_conf_youth = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_maximize = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_news_cup = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_news_league = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_news_recent = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_news_user = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_pause_break = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_pause_injury = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_pause_red = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_pref_mess = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_save_overwrite = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_show_all_leagues = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_show_job = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_show_live = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_show_overall = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_show_progress_pics = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_show_tendency = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_skip = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_store_restore_default_team = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_swap_adapts = null;

		[Glade.Widget]
		static Gtk.ComboBox combobox_hotel = null;

		[Glade.Widget]
		static Gtk.ComboBox combobox_languages = null;

		[Glade.Widget]
		static Gtk.Entry entry_constants_file = null;

		[Glade.Widget]
		static Gtk.ComboBox entry_font_name = null;

		[Glade.Widget]
		static Gtk.Label label_training = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_news_popup_always = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_news_popup_no = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_news_popup_user = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_autosave = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_autosave_files = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_bet_wager = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_contract = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_live_speed = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_live_verbosity = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_precision = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_recreation = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_refresh = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_save_global = null;

		[Glade.Widget]
		static Gtk.CheckButton checkbutton_save_user = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_options.glade", "window_options", typeof(OptionsWindow));
			return window_options;
		}
	}
}

