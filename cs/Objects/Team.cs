using System;
using System.Collections.Generic;

namespace bygfoot
{
	/** Possibilities for team comparison. */
	public enum TeamCompare
	{
		TEAM_COMPARE_LEAGUE_RANK = 0,
		TEAM_COMPARE_LEAGUE_LAYER,
		TEAM_COMPARE_UNSORTED,
		TEAM_COMPARE_AV_SKILL,
		TEAM_COMPARE_OFFENSIVE,
		TEAM_COMPARE_DEFENSE,
		TEAM_COMPARE_END
	}

	/** @see team_return_league_cup_value_int() */
	public enum LeagueCupValue
	{
		LEAGUE_CUP_VALUE_NAME = 0,
		LEAGUE_CUP_VALUE_SHORT_NAME,
		LEAGUE_CUP_VALUE_SID,
		LEAGUE_CUP_VALUE_SYMBOL,
		LEAGUE_CUP_VALUE_ID,
		LEAGUE_CUP_VALUE_FIRST_WEEK,
		LEAGUE_CUP_VALUE_LAST_WEEK,
		LEAGUE_CUP_VALUE_WEEK_GAP,
		LEAGUE_CUP_VALUE_YELLOW_RED,
		LEAGUE_CUP_VALUE_AVERAGE_SKILL,
		LEAGUE_CUP_VALUE_AVERAGE_CAPACITY,
		LEAGUE_CUP_VALUE_SKILL_DIFF,
		LEAGUE_CUP_VALUE_END
	}

	/** Some team attributes. */
	public enum TeamAttribute
	{
		TEAM_ATTRIBUTE_STYLE = 0,
		TEAM_ATTRIBUTE_BOOST,
		TEAM_ATTRIBUTE_END
	}

	/** The stadium of a team. */
	public class Stadium
	{
		public string name;
		public int Capacity { get; set; } /**< How many people fit in. Default: -1 (depends on league). */
		public int average_attendance = 0; /**< How many people watched on average. Default: 0. */
		public int possible_attendance = 0; /**< How many people would've watched if every game had been
				sold out. We need this only to compute the average attendance in percentage
				of the capacity. Default: 0. */
		public int games = 0; /**< Number of games. Default: 0. */
		public float safety; /**< Safety percentage between 0 and 100. Default: randomized. */
		public float ticket_price;
	}

	/** Structure representing a team.
	 * @see Player */
	public class Team
	{
		public string name;
		public string symbol;
		/** File the team takes the 
		 * player names from. */
		public string namesFile;
		public string defFile;
		/** The sid of the strategy if it's a CPU team. */
		public string strategySid;
		
		public int clid; /**< Numerical id of the league or cup the team belongs to. */
		public int id; /**< Id of the team. */
		public int structure; /**< Playing structure. @see team_assign_playing_structure() */
		public int Style { get; set; } /**< Playing style. @see team_assign_playing_style() */
		public int boost; /**< Whether player boost or anti-boost is switched on. */
		
		/** Average talent of the players at generation. */
		public float AverageTalent { get; set; }
		
		/** A value that influences scoring chances etc.
		 * If > 1, the team's lucky, if < 1, it's unlucky.
		 * Only used for users' teams. */
		public float Luck { get; set; }
		
		public Stadium Stadium { get; set; }
		/**
		 * Array of players.
		 * */
		public List<Player> Players { get; set; }
	}
}

