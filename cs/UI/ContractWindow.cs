using System;

namespace bygfoot
{
	public class ContractWindow
	{
		[Glade.Widget]
		static Gtk.Window window_contract = null;

		[Glade.Widget]
		static Gtk.Label label_contract = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_contract1 = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_contract2 = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_contract3 = null;

		[Glade.Widget]
		static Gtk.SpinButton spinbutton_contract4 = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_contract1 = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_contract2 = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_contract3 = null;

		[Glade.Widget]
		static Gtk.RadioButton radiobutton_contract4 = null;

		[Glade.Widget]
		static Gtk.Button button_contract_cancel = null;

		public static Gtk.Window Create()
		{
			Support.LoadUI("bygfoot_misc2.glade", "window_contract", typeof(ContractWindow));
			return window_contract;
		}
	}
}

