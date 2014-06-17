using System;
using System.IO;
using Gtk;

namespace bygfoot
{
	public class MainWindow
	{
		[Glade.Widget]
		static Gtk.Window main_window = null;

		[Glade.Widget]
		static Gtk.Entry entry_message = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot.glade", "main_window", typeof(MainWindow));
			return main_window;
		}

		/** Set the main window geometry according to the file
		 * settings. */
		public static void LoadGeometry()
		{
			#if DEBUG
			Console.WriteLine("WindowMain.LoadGeometry");
			#endif
			/*
		    gchar filename[SMALL];
		    gchar dir[SMALL];
		    OptionList optionlist;
		    
		    file_get_bygfoot_dir(dir);

		    sprintf(filename, "%s%swindow_settings",
			    dir, G_DIR_SEPARATOR_S);

		    if(g_file_test(filename, G_FILE_TEST_EXISTS))
		    {
				optionlist.list = NULL;
				optionlist.datalist = NULL;
				file_load_opt_file(filename, &optionlist, FALSE);

				gtk_window_resize(GTK_WINDOW(window.main),
						  option_int("int_window_settings_width", &optionlist),
						  option_int("int_window_settings_height", &optionlist));
				gtk_window_move(GTK_WINDOW(window.main),
						option_int("int_window_settings_pos_x", &optionlist),
						option_int("int_window_settings_pos_y", &optionlist));
				gtk_paned_set_position(GTK_PANED(lookup_widget(window.main, "hpaned2")),
						       option_int("int_window_settings_paned_pos", &optionlist));

				free_option_list(&optionlist, FALSE);
			}
			*/
    	}
	}
}

