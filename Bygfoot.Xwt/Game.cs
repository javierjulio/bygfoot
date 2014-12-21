using System;
using System.Collections.Generic;

namespace Bygfoot.Xwt
{
	public class Game
	{
		private static Game _instance = null;

		public static Game Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Game();
				}
				return _instance;
			}
		}

		static Game()
		{
		}

		public Game()
		{
		}

		public void Init()
		{
		}

		public Country Country { get; set; }
		public List<User> Users { get; set; }

		public int Season { get; set; }
		public int Week { get; set; }
		public int WeekRound { get; set; }

		public List<string> SupportDirectories { get; set; }
	}
}

