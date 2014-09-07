using System;
using System.Collections.Generic;

namespace Bygfoot.Xwt
{
	public class OptionsList
	{
		private Dictionary<string, Option> _optionsList;

		public OptionsList()
		{
			_optionsList = new Dictionary<string, Option>();
		}

		public void Add(string name, string value)
		{
			Add(new Option(name, value));
		}

		public void Add(Option option)
		{
			if (!_optionsList.ContainsKey(option.Name))
				_optionsList.Add(option.Name, option);
		}

		public void Remove(string name)
		{
			if (_optionsList.ContainsKey(name))
				_optionsList.Remove(name);
		}

		public void Remove(Option option)
		{
			Remove(option.Name);
		}

		public Option this[string name]
		{
			get
			{
				if (_optionsList.ContainsKey(name))
					return _optionsList[name];
				return null;
			}
		}

		public dynamic this[string name, Type type]
		{
			get
			{
				if (_optionsList.ContainsKey(name))
					return _optionsList[name].GetValue(type);
				return null;
			}
		}
	}
}

