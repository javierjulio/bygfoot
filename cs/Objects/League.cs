using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace bygfoot
{
	public enum PromRelType
	{
		PROM_REL_PROMOTION = 0,
		PROM_REL_RELEGATION,
		PROM_REL_NONE
	}

	/**
	 * An element representing a promotion or relegation rule.
	 * This means, a PromRelElement specifies a range of teams
	 * that get promoted or relegated to a given league.
	 * @see PromRel
	 * */
	public class PromRelElement
	{
		public int[] ranks = new int[] { 0, 0 };
		public int fromTable = 0;
		public string destSid = string.Empty;
		public PromRelType type = PromRelType.PROM_REL_NONE;
	}

	/**
	 * An struct representing promotion/relegation games.
	 * */
	public class PromGames
	{
		/** The id of the league the promotion games winner gets promoted to. Default "" */
		public string destSid = string.Empty;
		/** The id of the league the promotion games losers get moved to. Default "" */
		public string loserSid = string.Empty;
		/** Number of teams that advance from the promotion games. Default: 1. */
		public int numberOfAdvance;
		/** The cup determining how the promotion games are handled. */
		public string cupSid;
	}

	/**
	 * This structure specifies how promotion and relegation is handled in a league.
	 * It contains promotion and relegation rules in an array and possibly also
	 * a rule about promotion games to be played.
	 * @see PromRelElement
	 * */
	public class PromRel
	{
		/** Array with promotion/relegation rules.
		 * @see PromRelElement
		 * */
		public List<PromRelElement> elements;
		/** Array with promotion/relegation games.
		 * @see PromGames
		 * */
		public List<PromGames> promGames;
	}

	/**
	 * A structure describing a different league joined to the current one
	 * in the sense that there are matches played between teams from both leagues
	 * like in the US conference system.
	 * */
	public class JoinedLeague
	{
		/** Sid of the joined league. */
		public string sid;
		/** How many round robins to schedule. */
		public int rr;
	}

	/**
	 * A structure containing a week when a new table
	 * gets created with nullified values for the league;
	 * older tables get stored.
	 * */
	public class NewTable
	{
		public int addWeek;
		public string name;
	}

	/**
	 * A structure describing a custom break in the fixtures
	 * schedule occuring at a particular week.
	 * */
	public class WeekBreak
	{
		/** In which week the break occurs. */
		public int weekNumber;
		/** Length of break in weeks. */
		public int length;
	}

	public class League
	{
		/** Default value "" */
		public string name = string.Empty;
		public string shortName = string.Empty;
		public string sid = string.Empty;
		public string symbol = string.Empty;
		/** The sid of the player names file the 
		 * teams in the league take their names from.
		 * Default: 'general', meaning the 'player_names_general.xml' file. */
		public string names_file = "general";
		/** @see PromRel */
		public PromRel promRel;
		/** Numerical id, as opposed to the string id 'sid'. */
		public int id;
		/** Layer of the league; this specifies which leagues are
		 * parallel. */
		public int layer;
		/** The first week games are played. Default 1. */
		public int firstWeek = 1;
		/** Weeks between two matchdays. Default 1. */
		public int weekGap = 1;
		/** Here we store intervals of fixtures during which
		 * there should be two matches in a week instead of one. */
		public ArrayList[] twoMatchWeeks = new ArrayList[2];
		/** How many round robins are played. Important for
		 * small leagues with 10 teams or so. Default: 2. */
		public int roundRobins = 2;
		/** Number of weeks between the parts of a round robin. */
		public ArrayList rrBreaks;
		/** Number of yellow cards until a player gets banned. 
		 * Default 1000 (which means 'off', basically). */
		public int yellowCard = 1000;
		/** Average talent for the first season. Default: -1. */
		public float averageTalent = -1;
		/** Array of teams in the league.
		 * @see Team */
		public List<Team> teams;
		/** List of leagues joined fixture-wise to this one.
		 * @see JoinedLeague */
		public List<JoinedLeague> joinedLeagues;
		/** League tables. Usually only one, sometimes more than one is created.
		 * @see Table */
		public ArrayList tables;
		/** Array holding NewTable elements specifying when to add
		 * a new table to the tables array. */
		public List<NewTable> newTables;
		/** The fixtures of a season for the league. */
		public ArrayList fixtures;
		/** A gchar pointer array of properties (like "inactive"). */
		public ArrayList properties;
		/** Array of custom breaks in schedule. */
		public List<WeekBreak> weekBreaks;
		/** The current league statistics. */
		public LeagueStat stats;
		/** Pointer array with the sids of competitions that
        the fixtures of which should be avoided when scheduling
        the league fixtures. */
		public ArrayList skipWeeksWith;

		public League ()
		{
		}

		public void Load(string leagueName)
		{
			string filename = Path.GetFileName (leagueName);
			if (!filename.StartsWith ("league_"))
				filename = "league_" + filename;
			if (!filename.EndsWith (".xml"))
				filename += ".xml";

			string path = FileHelper.FindSupportFile (filename, false);
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml (File.ReadAllText (path));
			Load (doc.DocumentElement);
		}

		public void Load(XmlNode xnLeague)
		{
			XmlNode xnName = xnLeague.SelectSingleNode (XmlHelper.TAG_DEF_NAME);
			name = xnName.InnerText;
			XmlNode xnShortName = xnLeague.SelectSingleNode (XmlHelper.TAG_DEF_SHORT_NAME);
			shortName = xnName.InnerText;
			XmlNode xnSid = xnLeague.SelectSingleNode (XmlHelper.TAG_DEF_SID);
			sid = xnSid.InnerText;
			XmlNode xnSymbol = xnLeague.SelectSingleNode (XmlHelper.TAG_DEF_SYMBOL);
			symbol = xnSymbol.InnerText;
		}
	}
}

