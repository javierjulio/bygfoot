using System;

namespace bygfoot
{
	public class UserManagementWindow
	{
		[Glade.Widget]
		static Gtk.Window window_user_management = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_user_management_users = null;

		[Glade.Widget]
		static Gtk.TreeView treeview_user_management_teams = null;

		[Glade.Widget]
		static Gtk.Entry entry_user_management = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_user_management", typeof(UserManagementWindow));
			return window_user_management;
		}
	}
}

