using System;
using System.Collections;
using System.Collections.Generic;

namespace bygfoot
{
	public class OptionStruct
	{
		public string name;
		public string stringValue;
		public int value;
	}

	public class OptionList
	{
		public ArrayList list;
		public Dictionary<string, OptionStruct> datalist;

		public OptionList()
		{
			list = new ArrayList();
			datalist = new Dictionary<string, OptionStruct>();
		}
	}
}

