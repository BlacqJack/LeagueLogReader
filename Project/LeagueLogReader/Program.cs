using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Known problems:
// Leblanc doesn't show up in counted champions - FIXED

namespace LeagueInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            NewScreen();
            Console.WriteLine("Changelog:");
            Console.WriteLine("1.0\nInitial release!");
            Console.WriteLine();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            
            if(!Directory.Exists(@"Summoners") || Directory.GetFiles(@"Summoners\").Length == 0)
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
            Console.ReadKey();


            //
            
        }

        static void MainMenu()
        {
            NewScreen();
            int answer = 0;

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Go to the Summoner list");
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

        static void SummonerList()
        {
            NewScreen();
            Console.WriteLine("Which summoner?");

            string[] summonersPaths = Directory.GetFiles(@"Summoners\");
            string[] summoners = new string[summonersPaths.Length];
            var numberOfSumm = 1;
            //var i = 0;

            for(var i = 0; i < summonersPaths.Length; i++)
            {
                summoners[i] = Path.GetFileNameWithoutExtension(summonersPaths[i]).ToString();

                Console.WriteLine(numberOfSumm + ". " + summoners[i]);
                numberOfSumm++;
            }
            
            try
            {
                var answer = int.Parse(Console.ReadLine());

                SummonerInfo(summoners[answer-1]);
            }catch(FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        static void SummonerInfo(string summoner)
        {
            NewScreen();

            Console.WriteLine(summoner);
            Console.WriteLine("------------------------");
            Console.WriteLine("Opening text file...");
            Console.WriteLine("\nPress any key to go back to the main menu!");

            Process.Start("Notepad.exe", @"Summoners\" + summoner + ".txt");

            Console.ReadKey();
            MainMenu();
        }

        // Analyzing //

        static void NewSummoner()
        {
            NewScreen();
            Console.WriteLine("Enter your Summoner Name please!");
            Console.WriteLine("Case-sensitive!");
            string summonerName = Console.ReadLine();

            Console.WriteLine("Please enter where your League of Legends is installed!\nDon't forget the \\ at the end!");
            Console.WriteLine("(The one with the RADS and logs folders in it)");
            Console.WriteLine("(For example: C:\\Riot Games\\League of Legends\\)");
            Console.WriteLine("Case-sensitive!");
            string installDir = Console.ReadLine();

            NewScreen();
            Console.WriteLine("Summoner Name:\n" + summonerName);
            Console.WriteLine("Install Path:\n" + installDir);
            Console.WriteLine();
            StartRead(summonerName, installDir);

            NewScreen();
            Console.WriteLine("Done analyzing. Press any key to start compile the data!");
            Console.ReadKey();
            NewScreen();
            CountChampions(summonerName);

            Console.WriteLine("\nPress any key go to the main menu!");
            Console.ReadKey();
            MainMenu();
        }

        static void StartRead(string summonerName, string gamePath)
        {
            string logPath = gamePath + @"Logs\Game - R3d Logs\";
            string infoPath = @"Summoners\" + summonerName + "Temp.txt";
            string dirPath = @"Summoners";
            bool inGame = false;

            try
            {
                // Creating directory to store info, creating path to .txt
                DirectoryInfo di = Directory.CreateDirectory(dirPath);

                string[] logs = Directory.GetFiles(logPath, "*_r3dlog.txt"); // Get all r3dlogs in logPath's directory.
                Array.Sort(logs); // Sort them because why not!
                if(logs.Length == 1)
                {
                    Console.WriteLine("Found " + logs.Length + " log!");
                }else{
                    Console.WriteLine("Found " + logs.Length + " logs!");
                }

                Console.WriteLine("Press any key to start analyzing logs!");
                Console.ReadKey();

                // Analyze preparations
                File.WriteAllText(infoPath, String.Empty); // Empty old file if there was one
                TextWriter tw = new StreamWriter(infoPath, true);
                int logsAnalyzed = 0; // Last minute int declarations
                int logsWritten = 0;

                foreach (string log in logs) // For each log-file (..._r3dlog.txt)
                {
                    NewScreen();
                    Console.WriteLine("Working. Please wait...");
                    Console.WriteLine("Logs analyzed: " + logsAnalyzed.ToString());
                    Console.WriteLine("Matches found: " + logsWritten);

                    string[] lines = File.ReadAllLines(@log); // Get all the text in the file
                    string champion = " created for "; // Declare what string means that there is a champion loaded in

                    foreach(string line in lines) // For each line in the log-file
                    {
                        if(File.Exists(infoPath)) // Not sure if this is needed but I can't be bothered to check. :)
                        {
                            if (line.Contains(champion) && line.Contains(summonerName)) // If a string has both a champion loading in and it is controlled by the specified Summoner
                            {
                                // Lots of trimming of the raw text
                                string tempLine = line.Remove(0, 62);

                                int index = tempLine.IndexOf("(");

                                tempLine = tempLine.Remove(index, 16 + summonerName.Length);

                                Console.WriteLine("Writing \"" + tempLine + "\" to text file.");
                                tw.WriteLine(tempLine); // Writing the text into the file located at infoPath (\Summoners\summonerName.txt)
                                logsWritten++;
                            }
                        }
                    }
   
                    logsAnalyzed++;
                }

                tw.Close();
            }
            catch(IOException e) // Most likely access denied error
            {
                if(e.Message.Contains("cannot access"))
                {
                    Console.WriteLine("Couldn't access a specific log file! Oh no!\nMake sure to not be in-game when running this program!");
                    inGame = true;
                }
            }
            catch(Exception e) // Any other error?
            {
                Console.WriteLine(e.ToString());
                inGame = true;
            }

            if(!inGame)
            {
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("An error occurred and the program will\nprobably not be able to compile the data.");
            }
            Console.ReadKey();
        }

        static void CountChampions(string summonerName)
        {
            try
            {
                string dataPath = @"Summoners\" + summonerName + "Temp.txt";
                string dirPath = @"Summoners\" + summonerName + ".txt";

                File.WriteAllText(dirPath, String.Empty);
                Dictionary<string, int> dic = new Dictionary<string, int>();

                string[] analyzeResult = File.ReadAllLines(dataPath);
                Array.Sort(analyzeResult);
                TextWriter tw = new StreamWriter(dirPath, true);

                // Fill in the Dictionary
                foreach (string champ in analyzeResult)
                {
                    if (dic.ContainsKey(champ))
                    {
                        dic[champ] += 1;
                    }
                    else
                        if (!dic.ContainsKey(champ))
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

                foreach (string champion in champions)
                {
                    try
                    {
                        Console.WriteLine(champion + ": " + dic[champion]);
                        tw.WriteLine(champion + ": " + dic[champion]);
                    }
                    catch (KeyNotFoundException)
                    {
                        Debug.WriteLine(champion + " not found in Dictionary");
                    }
                }

                // Remove temporary file
                File.Delete(dataPath);

                tw.Close();
            }catch(IOException e)
            {
                if(e.Message.Contains("cannot access"))
                {
                    Console.WriteLine("Couldn't access a specific log file!\nMake sure to not be in-game when running this program!");
                }
            }
        }



        static void NewScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------");
            Console.WriteLine("LLR - League Log Reader");
            Console.WriteLine("Version 1.0");
            Console.WriteLine("Created by bq");
            Console.WriteLine("------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    
    }
}
