using System;

namespace bygfoot
{
	public class TransferDialogWindow
	{
		[Glade.Widget]
		static Gtk.Window window_transfer_dialog = null;

		[Glade.Widget]
		static Gtk.Label label_transfer_dialog = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_transfer_dialog", typeof(TransferDialogWindow));
			return window_transfer_dialog;
		}
	}
}

