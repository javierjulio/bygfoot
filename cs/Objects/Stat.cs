using System;
using System.Collections.Generic;

namespace bygfoot
{
	/** A statistics element holding some
	 * string and integer values. */
	public class Stat
	{
		public string teamName;
		public int value1, value2, value3;
		public string valueString;
	}

	/** A structure holding some stat arrays about a league. */
	public class LeagueStat
	{
		public string leagueSymbol;
		public string leagueName;
		
		/** Best offensive and defensive teams. */
		public List<Team> teamsOff;
		public List<Team> teamsDef;
		/** Best goal getters and goalies. */
		public List<Player> playerScorers;
		public List<Player> playerGoalies;
	}

	/** A team name and a competition name. */
	public class ChampStat
	{
		public string teamName, clName;
	}

	/** A season statistics structure. */
	public class SeasonStat
	{
		/** Which season */
		public int season_number;
		
		/** League and cup winners. */
		public List<ChampStat> leagueChamps;
		public List<ChampStat> cupChamps;

		/** The league stats at the end of the season. */
		public List<LeagueStat> leagueStats;
	}
}
