using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

namespace bygfoot
{
	public class Country
	{
		public const string TAG_COUNTRY = "country";
		public const string TAG_RATING = "rating";
		public const string TAG_SUPERNATURAL = "supernational";
		public const string TAG_LEAGUES = "leagues";
		public const string TAG_LEAGUE = "league";
		public const string TAG_CUPS = "cups";
		public const string TAG_CUP = "cup";

		public string name;
		public string symbol;
		public string sid;
		public int rating;

		public List<League> leagues;
		public List<Cup> cups;
		
		public List<Cup> allcups;

		public void Load(string countryName)
		{
			string filename = Path.GetFileName (countryName);
			if (!filename.StartsWith ("country_"))
				filename = "country_" + filename;
			if (!filename.EndsWith (".xml"))
				filename += ".xml";
			
			string path = FileHelper.FindSupportFile (filename, false);
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml (File.ReadAllText (path));
			Load (doc.DocumentElement);
		}

		public void Load(XmlNode xnCountry)
		{
			XmlNode xnName = xnCountry.SelectSingleNode (XmlHelper.TAG_DEF_NAME);
			name = xnName.InnerText;
			XmlNode xnSymbol = xnCountry.SelectSingleNode (XmlHelper.TAG_DEF_SYMBOL);
			symbol = xnSymbol.InnerText;
			XmlNode xnSid = xnCountry.SelectSingleNode (XmlHelper.TAG_DEF_SID);
			sid = xnSymbol.InnerText;
			XmlNode xnRating = xnCountry.SelectSingleNode (TAG_RATING);
			rating = Convert.ToInt32 (xnRating.InnerText);
			XmlNode xnLeagues = xnCountry.SelectSingleNode (TAG_LEAGUES);
			foreach (XmlNode xnLeague in xnLeagues.ChildNodes) {
				League league = new League ();
				league.Load (xnLeague.InnerText);
			}

			XmlNode xnCups = xnCountry.SelectSingleNode (TAG_CUPS);
			foreach (XmlNode xnCup in xnCups.ChildNodes) {
				Cup cup = new Cup();
				cup.Load (xnCup.InnerText);
			}
		}
	}
}
