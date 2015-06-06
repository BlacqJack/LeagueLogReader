using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace LeagueLogReaderWF
{
	class Settings
	{
		public static string version = "1.2";
		public static string settingsPath = @"settings.ini";

		private static string[] settingsDefault = { @"InstallDir=", "IncludeBots=false" };
		private static string[] settings = { @"InstallDir=", "IncludeBots=false" };

		public static void CheckFiles()
		{
			if (!File.Exists(settingsPath))
			{
				File.AppendAllLines(settingsPath, settings);
			}

			Directory.CreateDirectory(@"Groups");

			if (!File.Exists("Champions.txt"))
			{
				System.Net.WebClient Client = new System.Net.WebClient();
				Client.DownloadFile("https://dl.dropboxusercontent.com/u/29393121/Champions.txt", "Champions.txt"); 
			}
		}

		public static void Reset()
		{
			settings = settingsDefault;
			File.Delete(settingsPath);
			CheckFiles();
		}

		public static string Save(string installPath, bool includeBots)
		{
			settings[0] = "InstallDir=" + installPath;
			settings[1] = "IncludeBots=" + includeBots.ToString();

			if (settings[0].Contains(@"/"))
			{
				settings[0].Replace(@"/", @"\");
			}

			if (!settings[0].EndsWith("\\") && !settings[0].Equals(""))
			{
				settings[0] = settings[0] + "\\"; 
			}

			File.WriteAllLines(settingsPath, settings);
			return GetInstallDir();
		}

		public static string[] GetSettings()
		{
			string[] line = File.ReadAllLines(settingsPath);

			try
			{
				line[0] = line[0].Remove(0, 11);
				line[1] = line[1].Remove(0, 12);

				return line;
			}
			catch (Exception)
			{
				Reset();

				line[0] = line[0].Remove(0, 11);
				line[1] = line[1].Remove(0, 12);

				return line;
			}
		}

		public static string GetInstallDir()
		{
			string temp = GetSettings()[0];

			if (temp.Contains(@"/"))
			{
				temp.Replace(@"/", @"\");
			}

			if (!temp.EndsWith("\\") && !temp.Equals(""))
			{
				temp = temp + "\\";
			}

			//Debug.WriteLine(temp);
			return temp;
		}

		public static bool GetIncludeBots()
		{
			bool temp = Boolean.Parse(GetSettings()[1]);

			return temp;
		}
	}
}
