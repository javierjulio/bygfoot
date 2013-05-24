using System;
using System.IO;
using System.Collections.Generic;
using Gtk;

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

		/** Create the model for the startup country files combo.
		 * @param countryList The List of country files found */
		public static TreeModel CreateCountryList(string[] countryList)
		{
#if DEBUG
			Console.WriteLine("TreeViewHelper.CreateCountryList");
#endif
			TreeStore ls = new TreeStore(typeof(Gdk.Pixbuf), typeof(string));
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

				TreeIter iterCountry = ls.AppendNode (iterContinent);
				ls.SetValue(iterCountry, 1, elements[1]);
			}
			return ls;
		}
	}
}

