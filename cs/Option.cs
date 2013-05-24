using System;
using System.Collections;
using System.Collections.Generic;

namespace bygfoot
{
	public class Option
	{
		const float OPTION_FLOAT_DIVISOR = (float)100000.0;

		public static string ConstApp(string name)
		{
			return OptionString(name, Variables.ConstantsApp);
		}

		public static string ConstStr(string name)
		{
			return OptionString(name, Variables.Constants);
		}

		public static int ConstInt(string name)
		{
			return OptionInt(name, Variables.Constants);
		}

		public static string OptStr(string name)
		{
			return OptionString(name, Variables.Options);
		}

		public static int OptInt(string name)
		{
			return OptionInt(name, Variables.Options);
		}

		public static int SettingInt(string name)
		{
			return OptionInt (name, Variables.Settings);
		}

		public static void SettingInt(string name, int value)
		{
			OptionInt (name, Variables.Settings, value);
		}

		private static string OptionString(string name, OptionList optionList)
		{
#if DEBUG
			Console.WriteLine("OptionString");
#endif
			if (optionList.datalist.ContainsKey(name))
				return optionList.datalist[name].stringValue;

			Program.ExitProgram(ExitCodes.EXIT_OPTION_NOT_FOUND, "OptionString: option named {0} not found\nMaybe you should delete the .bygfoot directory from your home dir", name);
			return null;
		}

		private static int OptionInt(string name, OptionList optionList)
		{
#if DEBUG
			Console.WriteLine("OptionInt");
#endif
			if (optionList.datalist.ContainsKey(name))
				return optionList.datalist[name].value;
			
			Program.ExitProgram(ExitCodes.EXIT_OPTION_NOT_FOUND, "OptionInt: option named {0} not found\nMaybe you should delete the .bygfoot directory from your home dir", name);
			return -1;
		}

		public static void OptionInt(string name, OptionList optionList, int value)
		{
#if DEBUG
			Console.WriteLine("OptionInt.Set");
#endif
			Add (optionList, name, value, string.Empty);
		}

		private static float OptionFloat(string name, OptionList optionList)
		{
#if DEBUG
			Console.WriteLine("OptionFloat");
#endif
			if (optionList.datalist.ContainsKey(name))
				return optionList.datalist[name].value / OPTION_FLOAT_DIVISOR;
			
			Program.ExitProgram(ExitCodes.EXIT_OPTION_NOT_FOUND, "OptionFloat: option named {0} not found\nMaybe you should delete the .bygfoot directory from your home dir", name);
			return -1;
		}

		/** Add an option to the optionlist with the given values. */
		public static void Add(OptionList optionList, string name, int value, string strValue)
		{
#if DEBUG
			Console.WriteLine("Option.Add");
#endif
			if (optionList.list == null)
				optionList.list = new ArrayList();
			if (optionList.datalist == null)
				optionList.datalist = new Dictionary<string, OptionStruct>();

			if (optionList.datalist.ContainsKey(name))
			{
				OptionStruct option = optionList.datalist[name];
				if (Variables.debug_level > 0)
					Debug.PrintMessage("Option {0} already in optionlist\n", name);
				option.value = value;
				option.stringValue = strValue;
			}
			else
			{
				OptionStruct newOption = new OptionStruct();
				newOption.name = name;
				newOption.value = value;
				newOption.stringValue = strValue;
				optionList.list.Add(newOption);

				optionList.datalist.Clear();
				foreach (OptionStruct option in optionList.list)
				{
					if (!optionList.datalist.ContainsKey(option.name))
						optionList.datalist.Add(option.name, option);
				}
			}
		}
	}

	public class OptionCompare : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			OptionStruct option1 = (OptionStruct)x;
			OptionStruct option2 = (OptionStruct)y;
			return option1.name.CompareTo(option2.name);
		}
	}
}

