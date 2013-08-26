using System;
using System.IO;
using System.Collections.Generic;

namespace bygfoot
{
	public class FileHelper
	{
		/**
		 * Adds a definition directory
		 **/
		public static void AddDefinitionsDirectory(string directory)
		{
#if DEBUG
			Console.WriteLine("FileHelper.AddDefinitionsDirectory");
#endif
			string []dirNames = directory.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
			if (dirNames[dirNames.Length -1].ToLower().Equals("definitions"))
			{
				Variables.root_definitions_directories.Add(directory);
			}
			if (Variables.root_definitions_directories.FindAll(delegate(string s) {
					return s.StartsWith(directory);
				}).Count > 0)
			{
				Variables.definitions_directories.Add(directory);
			}
		}

		public static void AddSupportDirectoryRecursive(string directory)
		{
#if DEBUG
			Console.WriteLine("FileHelper.AddSupportDirectoryRecursive");
#endif
			
			if (!Directory.Exists(directory))
				return;
			
			/* Ignore .svn directories */
			if (directory.Contains(".svn"))
				return;
			
			AddDefinitionsDirectory(directory);
			Support.AddPixmapDirectory(directory);
			if (Variables.SupportDirectories == null)
				Variables.SupportDirectories = new List<string>();
			Variables.SupportDirectories.Add(directory);
			foreach (string subdir in Directory.EnumerateDirectories(directory))
			{
				AddSupportDirectoryRecursive(subdir);
			}
		}
		
		public static string FindSupportFile (string filename, bool warning)
		{
#if DEBUG
			Console.WriteLine("FileHelper.FindSupportFile");
#endif
			filename = Path.GetFileName(filename);
			foreach (string directory in Variables.SupportDirectories)
			{
				string filepath = string.Format("{0}{1}{2}", directory, Path.DirectorySeparatorChar, filename);
				if (File.Exists(filepath))
					return filepath;
			}

			if (warning)
				Debug.PrintMessage("FindSupportFile: file '{0}' not found.", filename);
			return null;
		}

		public static void CheckHomeDir()
		{
#if DEBUG
			Console.WriteLine("FileHelper.CheckHomeDir");
#endif
		}

		public static void GetOptFromLine(string line, ref string optName, ref string optValue)
		{
#if DEBUG
			Console.WriteLine("FileHelper.GetOptFromLine");
#endif
			if (line.IndexOf('#') >= 0)
				line = line.Substring(0, line.IndexOf('#'));

		}

		public static bool ParseOptLine(string line, ref string optName, ref string optValue)
		{
			optName = null;
			optValue = null;
			if (line.IndexOf('#') >= 0)
				line = line.Substring(0, line.IndexOf('#'));
			if (string.IsNullOrEmpty(line))
				return false;

			int valueIndex = line.IndexOfAny(new char[] { ' ', '\t' });
			if (valueIndex == -1)
				valueIndex = line.Length;
			optName = line.Substring(0, valueIndex);
			if (valueIndex < line.Length)
				optValue = line.Substring(valueIndex + 1);
			return true;
		}

		/** Return the country definition files found in the support dirs.
		 * The files are appended with the directories*/
		public static string[] GetCountryFiles()
		{
#if DEBUG
			Console.WriteLine("FileHelper.GetCountryFiles");
#endif
			List<string> countryFiles = new List<string>();

			foreach (string dir in Variables.definitions_directories)
			{
				string[] dirContents = Directory.GetFiles(dir, "country_*.xml", SearchOption.AllDirectories);

				foreach (string item in dirContents) {
					string countryFile = item.Substring(dir.Length + (dir.EndsWith(Path.DirectorySeparatorChar.ToString()) ? 0 : 1));
					if (countryFiles.IndexOf(countryFile) == -1)
						countryFiles.Add(countryFile);
				}
			}

			return countryFiles.ToArray();
		}

		/** Load a file containing name - value pairs into
		 * the specified array. */
		public static void LoadOptFile(string filename, ref OptionList optionList, bool sort)
		{
#if DEBUG
			Console.WriteLine("FileHelper.LoadOptFile");
#endif
			optionList = new OptionList();
			string path = FindSupportFile(filename, false);
			string[] lines = File.ReadAllLines(path);
			foreach (string line in lines)
			{
				string optName = null, optValue = null;
				if (ParseOptLine(line, ref optName, ref optValue))
				{
					OptionStruct option = new OptionStruct();
					option.name = optName;
					if (optName.StartsWith("string_"))
					{
						option.stringValue = optValue;
						option.value = -1;
					}
					else
					{
						option.stringValue = null;
						option.value = Int32.Parse(optValue);
					}
					optionList.list.Add(option);

					if ((optName.EndsWith("_unix") && Variables.os_is_unix) ||
					    (optName.EndsWith("_win32") && !Variables.os_is_unix))
					{
						option.name = optName.Remove(optName.IndexOf(Variables.os_is_unix ? "_unix" : "_win32"));
						optionList.list.Add(option);
					}
				}
			}

			if (sort)
			{
				OptionCompare comparer = new OptionCompare();
				optionList.list.Sort(comparer);
			}
			
			foreach (OptionStruct option in optionList.list)
			{
				if (!optionList.datalist.ContainsKey(option.name))
					optionList.datalist.Add(option.name, option);
			}
		}

		public static string GetHomeDir()
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		}

		public static string GetCurrentDir()
		{
			return Directory.GetCurrentDirectory();
		}

		/** Find out where the Bygfoot directory we can write to resides
		 * and write the location into the string. */
		public static string GetBygfootDir()
		{
#if DEBUG
			Console.WriteLine("FileHelper.GetBygfootDir");
#endif
			string homePath = GetHomeDir();
			string currentPath = string.Format ("{0}{1}", GetCurrentDir (), Path.DirectorySeparatorChar);
			if (Variables.os_is_unix) {
				string appPath = string.Format ("{0}{1}{2}", homePath, Path.DirectorySeparatorChar, Bygfoot.HOMEDIRNAME);
				return File.Exists (appPath) ? appPath : currentPath;
			} else {
				return currentPath;
			}
		}

		/** Load the appropriate hints file. */
		public static void LoadHintsFile()
		{
#if DEBUG
			Console.WriteLine("FileHelper.LoadHintsFile");
#endif
			string langCode = Language.GetCode();
			string hintsFile = string.Format("bygfoot_hints_{0}", langCode);
			string hintsPath = FindSupportFile(hintsFile, false);
			if (string.IsNullOrEmpty(hintsPath))
				hintsFile = "bygfoot_hints_en";

			LoadOptFile(hintsFile, ref Variables.hints, false);
		}

		/** Load the options at the beginning of a new game from
		 * the configuration files. */
		public static void LoadConfFiles()
		{
#if DEBUG
			Console.WriteLine("FileHelper.LoadConfFiles");
#endif
			string confFile = FindSupportFile("bygfoot.conf", true);
			LoadOptFile(confFile, ref Variables.Options, false);

			LoadOptFile(Option.OptStr("string_opt_constants_file"), ref Variables.Constants, true);
			LoadOptFile(Option.OptStr("string_opt_appearance_file"), ref Variables.ConstantsApp, true);
			LoadOptFile("bygfoot_tokens", ref Variables.Tokens, false);
			LoadHintsFile();

			for (int i = 0; i < Variables.Tokens.list.Count; i++)
			{
				OptionStruct option = ((OptionStruct)(Variables.Tokens.list[i]));
				option.value = i;
			}
		}

		public static string LoadTextFromSaves(string filename)
		{
#if DEBUG
			Console.WriteLine("FileHelper.LoadTextFromSaves");
#endif
			string filepath = null;
			if (Variables.os_is_unix) {
				string home = GetHomeDir();
				filepath = string.Format ("{0}{1}{2}{1}saves{1}{3}", home, Path.DirectorySeparatorChar, Bygfoot.HOMEDIRNAME, filename);
			} else {
				string pwd = GetCurrentDir();
				filepath = string.Format("{0}{1}saves{1}{2}", pwd, Path.DirectorySeparatorChar, filename);
			}

			if (!File.Exists(filepath))
				return null;
			return File.ReadAllText(filepath);
		}
	}
}
