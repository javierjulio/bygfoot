using System;

namespace bygfoot
{
	/** A struct representing a betting possibility: a fixture plus odds. */
	public class BetMatch
	{
		/** The match the bet is about. */
		public int fixId;
		/** The odds for a win, draw or loss of the first team. */
		public float[] odds = new float[3];
	}

	/** A struct representing a bet by a user. */
	public class BetUser
	{
		/** Match the user betted on. */
		public int fixId;
		/** Which outcome he picked. */
		public int outcome;
		/** How much he wagered. */
		public int wager;
	}
}

