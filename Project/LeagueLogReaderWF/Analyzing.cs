using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

//bw.ReportProgress((int)Math.Ceiling(readLogsProgress));

namespace LeagueLogReaderWF
{
	class Analyzing
	{
		private readonly Form1 form;
		public Analyzing (Form1 form)
		{
			this.form = form;
		}

		static ErrorForm errorForm = new ErrorForm();

		public static int countProress = 0;
		public static bool hadError = false;
		static string errorLogPath = @"Logs\log.txt";
		static Stopwatch sw = new Stopwatch();

		public static void ReadLogs (string[] summonerNames, string groupName, string gamePath, int minimumGames, BackgroundWorker bw)
		{
			Directory.CreateDirectory(@"Groups\" + groupName);

			errorLogPath = Path.Combine(@"Logs\" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "-") + @".txt");
			string logPath = gamePath + @"Logs\Game - R3d Logs\";
			string tempPath = @"Groups\Temp.txt";
			string summonerInfoPath = @"Groups\" + groupName + @"\Summoners.txt";
			string dirPath = @"Groups";

			hadError = false;
			bool inGame = false;
			float readLogsProgress = 0;

			if (!Directory.Exists(logPath) || Directory.GetFiles(logPath) == null)
			{
				//WriteError("Couldnt find any logs in the specified folder!", "FileNotFoundException\n" + logPath);
				return;
			}

			string[] logs = Directory.GetFiles(logPath, "*_r3dlog.txt"); // Get all r3dlogs in logPath's directory.

			if (logs.Length == 1)
			{
				WriteLog("Found " + logs.Length + " log!");
			}
			else if (logs.Length > 1)
			{
				WriteLog("Found " + logs.Length + " logs!");
			}
			else if (logs.Length == 0)
			{
				WriteError("Couldn't find any logs!\nPlease check if the installation path is correct!", "");
			}


			File.WriteAllText(tempPath, String.Empty); // Empty old files / Create temp file.
			File.WriteAllText(errorLogPath, "------ Starting analyze at " + DateTime.Now.TimeOfDay.ToString().Remove(8, 8) + " ------\n\n");

			Dictionary<string, int> summonersPlayed = new Dictionary<string, int>();
			List<string> champions = new List<string>();
			float totalLogs = logs.Length * summonerNames.Length;

			// Creating directory to store info in
			Directory.CreateDirectory(dirPath);

			WriteLog("Working. Please wait...");
			WriteLog("Reading through logs...");
			sw.Start();

			try
			{
				float logsAnalyzed = 0; // Counting logs

				foreach (string log in logs) // For each log-file (x_r3dlog.txt)
				{
					string[] lines = File.ReadAllLines(@log); // Get all the text in the file
					string champion = " created for "; // Declare what string means that there is a champion loaded in
					bool isSummonerPlaying = false;

					// For each line in the log-file
					foreach (string line in lines)
					{
						// If a string has both a champion loading in and it is controlled by the specified Summoner
						if (line.Contains(champion))
						{
							foreach (string summonerName in summonerNames)
							{
								if (line.Contains(summonerName))
								{
									isSummonerPlaying = true;

									// Lots of trimming of the raw text
									string tempLine = line.Remove(0, 62);
									int index = tempLine.IndexOf("(");
									tempLine = tempLine.Remove(index, 16 + summonerName.Length);

									champions.Add(tempLine);  
								}
							}
						}
					}

					// Don't know if this is the best way to do this, but it's the easiest way I can come up with.
					// Since we need to know if the log file contains the summonerName first we read through it again.
					foreach (string line in lines)
					{
						// If a champion is being loaded in and if one of the summoners is in the match
						if (line.Contains(champion) && isSummonerPlaying)
						{
							if (!line.Contains(" Bot") || Settings.GetIncludeBots())
							{
								string tempStr = line;
								tempStr = tempStr.Substring(tempStr.LastIndexOf("created for"));
								string otherSummoner = tempStr.Remove(0, 12);

								if (!summonerNames.Contains(otherSummoner))
								{
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
										WriteError("bullshit", "this-should-not-be-able-to-happen-exception"); // impossibru
									} 
								}
							}
						}
					}

					logsAnalyzed++;
					readLogsProgress += (1f / (totalLogs / 100f)) * summonerNames.Length;

					bw.ReportProgress((int)Math.Ceiling(readLogsProgress));
				}
			}
			catch (FileNotFoundException e)
			{
				WriteError("Couldn't find any log files in the specified folder!", "FileNotFoundException\n" + e.Message);
			}
			catch (IOException e) // Most likely access denied error
			{
				if (e.Message.Contains("cannot access"))
				{
					WriteError("Couldn't access a specific log file! Oh no!\nMake sure to not be in-game when running this program!", e.ToString());
					inGame = true;
				}
				hadError = true;
			}
			catch (Exception e) // Any other error?
			{
				WriteError("Error!", e.ToString());
				inGame = true;
				hadError = true;
			}


			if (!hadError)
			{
				WriteLog("Done analyzing! Starting counting!");
			}
			else
			{
				return;
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
				int summonersCounted = 0;
				tw2.AutoFlush = true;

				foreach (KeyValuePair<string, int> entry in myList)
				{
					if (entry.Value > minimumGames)
					{
						string tempStr = entry.ToString();
						tempStr = tempStr.Substring(1, tempStr.Length - 2);

						tw2.WriteLine(tempStr);
					}

					summonersCounted++;
					int percent = (int)Math.Floor(75f + (((summonersCounted / (float)myList.Count) * 100f) * 0.5f));
					bw.ReportProgress(percent);
				}
			}

			using (var tw = new StreamWriter(tempPath, false, Encoding.ASCII, 0x10000))
			{
				foreach (string str in champions)
				{
					// Writing the text into the file located at infoPath (\Summoners\summonerNameTemp.txt)
					tw.WriteLine(str);
				}
			}

			if (!inGame)
			{

			}
			else
			{
				WriteError("\nAn error occurred and the program\nwill not be able to compile the data.", "Make sure you're not in-game while running the program!");
			}

		}

		public static void Count (string groupName, BackgroundWorker bw)
		{
			try
			{
				string tempPath = @"Groups\Temp.txt";
				string dirPath = @"Groups\" + groupName + @"\Champions.txt";

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
			catch (Exception e)
			{
				if (e.Message.Contains("cannot access"))
				{
					WriteError("Couldn't access a specific log file!", "Make sure to not be in-game when running this program!");
					Debug.WriteLine(e.ToString());
				}
				else
				{
					WriteError("Error!", e.ToString());
					Debug.WriteLine(e.ToString());
				}
				hadError = true;
			}

			sw.Stop();

			WriteLog("Done! You can now view your stats in the tab!");
			try
			{
				WriteLog("Time elapsed: " + sw.Elapsed.ToString().Remove(8, 8));
			}
			catch (ArgumentOutOfRangeException)
			{
				hadError = true;
				return;
			}
		}


		static void WriteLog (string input)
		{
			string temp = Environment.NewLine + DateTime.Now.TimeOfDay.ToString().Remove(8, 8) + " - " + input;

			File.AppendAllText(errorLogPath, temp);
			Form1._Form1.LogBoxText = Form1._Form1.LogBoxText + temp;
		}

		static void WriteError (string message, string error)
		{
			File.AppendAllText(errorLogPath, "\n" + DateTime.Now.TimeOfDay.ToString().Remove(8, 8) + "ERROR! \n" + message + "\n" + error);

			MessageBox.Show(message + Environment.NewLine + error, "Error!");

			hadError = true;
		}
	}
}
