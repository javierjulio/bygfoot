using System;

namespace Bygfoot.Xwt
{
	public class Option
	{
		const float OPTION_FLOAT_DIVISOR = (float)100000.0;

		public string Name { get; set; }
		public string Value { get; set; }

		public Option(string name, string value)
		{
			Name = name;
			Value = value;
		}

		public ReturnType GetValue<ReturnType>()
		{
			return GetValue(typeof(ReturnType));
		}

		public dynamic GetValue(Type type)
		{
			var returnValue = Convert.ChangeType(Value, type);
			if (type == typeof(float))
				returnValue = (float)returnValue / OPTION_FLOAT_DIVISOR;
			return returnValue;
		}
	}
}

