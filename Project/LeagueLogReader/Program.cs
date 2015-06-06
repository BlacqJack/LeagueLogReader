using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Known problems:


////////////////////////////////
//////       WARNING      //////
//////  MESSY CODE AHEAD  //////
////////////////////////////////


namespace LeagueInfo
{
	class Program
	{
		static void Main (string[] args)
		{
			NewScreen();
			Console.WriteLine("Changelog:");
			Console.WriteLine("1.0\nInitial release!");
			Console.WriteLine("1.1\nNow counts amount of times you've played with/against other Summoners");
			Console.WriteLine();
			Console.WriteLine("Press any key to start!");
			Console.ReadKey();

			if (!Directory.Exists(@"Summoners") || Directory.GetDirectories(@"Summoners\").Length == 0)
			{
				NewScreen();
				Console.WriteLine("Couldn't find any existing Summoners!\n");
				Console.WriteLine("Press any key to start analyzing the logs!");
				Console.ReadKey();
				NewSummoner();
			}
			else
			{
				MainMenu();
			}

			Console.WriteLine("How did you get here this should be impossible! D:");
			Console.ReadKey();
		}

		static void MainMenu ()
		{
			NewScreen();
			int answer = 0;

			Console.WriteLine("What do you want to do?");
			Console.WriteLine("1. Open the results folder");
			Console.WriteLine("2. Add a new Summoner");

			try
			{
				answer = int.Parse(Console.ReadLine());
			}
			catch (Exception)
			{
				//busy busy busy doin nothin at all
			}

			try
			{
				if (answer == 1)
				{
					SummonerList();
				}
				else if (answer == 2)
				{
					NewSummoner();
				}
				else
				{
					Console.WriteLine("Invalid input!");
					Console.ReadKey();
					MainMenu();
				}
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalid input!");
				Console.ReadKey();
				MainMenu();
			}
		}

		static void SummonerList ()
		{
			NewScreen();

			Console.WriteLine("Opening folder...");
			Console.WriteLine("\nPress any key to go back to the main menu!");

			Process.Start(@"Summoners\");
			//Process.Start("Notepad.exe", @"Summoners\" + summoner + ".txt");

			Console.ReadKey();
			MainMenu();
		}

		// Analyzing //

		static void NewSummoner ()
		{
			NewScreen();
			Console.WriteLine("Enter your Summoner Name please!");
			Console.WriteLine("Case-sensitive!");
			string summonerName = Console.ReadLine();

			NewScreen();
			Console.WriteLine("Summoner Name:\n" + summonerName);
			Console.WriteLine("\nPlease enter where your League of Legends is installed!");
			Console.WriteLine("(The one with the RADS and logs folders in it)");
			Console.WriteLine("(For example: C:\\Riot Games\\League of Legends\\)");
			Console.WriteLine("Case-sensitive!");
			string installDir = Console.ReadLine();
			if (installDir.Equals("dl"))
			{
				installDir = @"C:\Riot Games\League of Legends\";
			}
			if (installDir.Equals("ds"))
			{
				installDir = @"C:\League of Legends\";
			}
			if (!installDir.EndsWith("\\"))
			{
				installDir = installDir + "\\";
			}

			bool canContinue = false;
			int minimumPlayedGames = 15;
			do
			{
				try
				{
					NewScreen();
					Console.WriteLine("Summoner Name:\n" + summonerName);
					Console.WriteLine("\nInstall Path:\n" + installDir);
					Console.WriteLine("\nPlease enter the minimum amount of games played with a Summoner\nfor them to show up in the Summoners Played list.");
					minimumPlayedGames = int.Parse(Console.ReadLine());
					canContinue = true;
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input! Please enter a number above 0!");
					canContinue = false;
					Console.ReadKey();
				}
			} while (!canContinue);

			ReadLogs(summonerName, installDir, minimumPlayedGames);

			NewScreen();
			Count(summonerName);

			Console.WriteLine("Done!");
			Console.WriteLine("\nPress any key go to the main menu!");
			Console.ReadKey();
			MainMenu();
		}

		static void ReadLogs (string summonerName, string gamePath, int minimumGames)
		{
			Directory.CreateDirectory(@"Summoners\" + summonerName);
			string logPath = gamePath + @"Logs\Game - R3d Logs\";
			string tempPath = @"Summoners\Temp.txt";
			string summonerInfoPath = @"Summoners\" + summonerName + @"\Summoners.txt";
			string dirPath = @"Summoners";
			bool inGame = false;
			File.WriteAllText(tempPath, String.Empty); // Empty old file if there was one.
			File.WriteAllText(summonerInfoPath, String.Empty);
			//TextWriter tw = new StreamWriter(tempPath, true);
			Dictionary<string, int> summonersPlayed = new Dictionary<string, int>();

			try
			{
				// Creating directory to store info in
				DirectoryInfo di = Directory.CreateDirectory(dirPath);

				string[] logs = Directory.GetFiles(logPath, "*_r3dlog.txt"); // Get all r3dlogs in logPath's directory.
				Array.Sort(logs); // Sort them because why not!
				if (logs.Length == 1)
				{
					Console.WriteLine("Found " + logs.Length + " log!");
				}
				else
				{
					Console.WriteLine("Found " + logs.Length + " logs!");
				}

				Console.WriteLine("Press any key to start analyzing logs!");
				Console.ReadKey();


				int logsAnalyzed = 0; // Counting logs
				int logsWritten = 0;
				List<string> champions = new List<string>();
				string champion = " created for "; // Declare what string means that there is a champion loaded in
				bool isSummonerPlaying = false;

				NewScreen();
				Console.WriteLine("Working. Please wait...");

				// For each log-file (..._r3dlog.txt)
				foreach (string log in logs)
				{
					string[] lines = File.ReadAllLines(@log); // Get all the text in the file

					// For each line in the log-file
					foreach (string line in lines)
					{
						// If a string has both a champion loading in and it is controlled by the specified Summoner
						if (line.Contains(champion) && line.Contains(summonerName))
						{
							isSummonerPlaying = true;

							// Lots of trimming of the raw text
							string tempLine = line.Remove(0, 62);
							int index = tempLine.IndexOf("(");
							tempLine = tempLine.Remove(index, 16 + summonerName.Length);

							champions.Add(tempLine);

							logsWritten++;
						}
					}

					// Don't know if this is the best way to do this, but it's the easiest way I can come up with right now.
					// Since we need to know if the log file contains the summonerName first we read through it again.
					foreach (string line in lines)
					{
						// If a champion is being loaded in and it's not being played by summonerName, check if summonerName is in the match. If not, do.
						if (line.Contains(champion) && !line.Contains(summonerName) && isSummonerPlaying && !line.Contains(" Bot"))
						{
							// Trimming
							string tempStr = line;
							tempStr = tempStr.Substring(tempStr.LastIndexOf("created for"));
							string otherSummoner = tempStr.Remove(0, 12);

							// Add summoner to list
							if (summonersPlayed.ContainsKey(otherSummoner))
							{
								summonersPlayed[otherSummoner] += 1;
							}
							else if (!summonersPlayed.ContainsKey(otherSummoner))
							{
								summonersPlayed.Add(otherSummoner, 1);
							}
							else
							{
								Console.WriteLine("bullshit");
							}
						}
					}

					logsAnalyzed++;
				}

				using (var tw = new StreamWriter(tempPath, false, Encoding.ASCII, 0x10000))
				{
					foreach (string str in champions)
					{
						// Writing the text into the file located at infoPath (\Summoners\summonerNameTemp.txt)
						tw.WriteLine(str);
					}
				}
			}
			catch (IOException e) // Most likely access denied error
			{
				if (e.Message.Contains("cannot access"))
				{
					Console.WriteLine("Couldn't access a specific log file! Oh no!\nMake sure to not be in-game when running this program!");
					inGame = true;
				}
			}
			catch (Exception e) // Any other error?
			{
				Console.WriteLine(e.ToString());
				inGame = true;
			}


			List<KeyValuePair<string, int>> myList = summonersPlayed.ToList();
			myList.Sort(
				delegate(KeyValuePair<string, int> firstPair,
				KeyValuePair<string, int> nextPair)
				{
					return nextPair.Value.CompareTo(firstPair.Value);
				}
			);

			using (var tw2 = new StreamWriter(summonerInfoPath))
			{
				tw2.AutoFlush = true;

				foreach (KeyValuePair<string, int> entry in myList)
				{
					if (entry.Value > minimumGames)
					{
						string tempStr = entry.ToString();
						tempStr = tempStr.Substring(1, tempStr.Length - 2);

						tw2.WriteLine(tempStr);
					}
				}
			}

			if (!inGame)
			{
				Console.WriteLine("Done! Press any key to continue!");
			}
			else
			{
				Console.WriteLine("\nAn error occurred and the program will\nnot be able to compile the data.");
				Console.WriteLine("Press any key to go back to the main menu!");
				Console.ReadKey();
				MainMenu();
			}
			Console.ReadKey();
		}

		static void Count (string summonerName)
		{
			try
			{
				string tempPath = @"Summoners\Temp.txt";
				string dirPath = @"Summoners\" + summonerName + @"\Champions.txt";

				File.WriteAllText(dirPath, String.Empty);
				Dictionary<string, int> dic = new Dictionary<string, int>();

				string[] analyzeResult = File.ReadAllLines(tempPath);
				Array.Sort(analyzeResult);

				// Fill in the Dictionary
				foreach (string champ in analyzeResult)
				{
					if (dic.ContainsKey(champ))
					{
						dic[champ] += 1;
					}
					else if (!dic.ContainsKey(champ))
					{
						dic.Add(champ, 1);
					}
					else
					{
						Console.WriteLine("bullshit"); // impossibru
					}
				}

				// Time to start using Champions.txt
				string[] champions = File.ReadAllLines(@"Champions.txt");

				using (var tw = new StreamWriter(dirPath))
				{
					tw.AutoFlush = true;

					foreach (string champion in champions)
					{
						try
						{
							//Console.WriteLine(champion + ": " + dic[champion]);
							tw.WriteLine(champion + ": " + dic[champion]);
						}
						catch (KeyNotFoundException)
						{
							Debug.WriteLine(champion + " hasn't been played.");
						}
					}
				}

				// Remove temporary file
				File.Delete(tempPath);

			}
			catch (IOException e)
			{
				if (e.Message.Contains("cannot access"))
				{
					Console.WriteLine("Couldn't access a specific log file!\nMake sure to not be in-game when running this program!");
				}
			}
		}



		static void NewScreen ()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("------------------------");
			Console.WriteLine("LLR - League Log Reader");
			Console.WriteLine("Version 1.1");
			Console.WriteLine("Created by bq");
			Console.WriteLine("------------------------\n");
			Console.ForegroundColor = ConsoleColor.White;
		}

	}
}
