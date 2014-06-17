/*
   Misc.cs

   Bygfoot Football Manager -- a small and simple GTK2-based
   football management game.

   http://bygfoot.sourceforge.net

   Copyright (C) 2005  Gyözö Both (gyboth@bygfoot.com)

   This program is free software; you can redistribute it and/or
   modify it under the terms of the GNU General Public License
   as published by the Free Software Foundation; either version 2
   of the License, or (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;

namespace bygfoot
{
	public static class Misc
	{
		/**
		 * Print the contents of a GError (if it was set).
		 * If abort_program is TRUE, we free the memory
		 * and exit the game.
		 * @param error The GError we check.
		 * @param abort_program Whether or not we continue or exit the program.
		 **/
		public static void PrintError(GLib.GException exception, bool abortProgram)
		{
			#if DEBUG
			Console.WriteLine("Misc.PrintError");
			#endif

			if (exception == null)
				return;

			Debug.PrintMessage ("error message: {0}\n", exception.Message);

			if (abortProgram)
				Program.ExitProgram (ExitCodes.EXIT_PRINT_ERROR, null);
		}

		/** Swap two integers.
		 * @param first The first integer.
		 * @param second The second integer. */
		public static void SwapInt(ref int first, ref int second)
		{
			#if DEBUG
			Console.WriteLine("Misc.SwapInt");
			#endif

			int swap = first;
			first = second;
			second = swap;
		}

		/** Transform a string containing white spaces into an array of strings without
		 * white spaces.
		 * @param string The string containing white spaces.
		 * @return A GPtrArray containing all the strings without white spaces that were part of the original string.
		 * This array must be freed with free_gchar_array(). */
		public static string[] SeparateStrings(string source)
		{
			#if DEBUG
			Console.WriteLine("Misc.SeparateStrings");
			#endif
			return source.Split (' ');
		}
	}
}

