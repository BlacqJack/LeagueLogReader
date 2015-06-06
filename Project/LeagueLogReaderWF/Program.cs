using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LeagueLogReaderWF
{
	static class Program
	{
		// TODO:
		// Lerp Positions

		[STAThread]
		static void Main()
		{
			StartupChecks();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		static void StartupChecks()
		{
			Settings.CheckFiles();
			Directory.CreateDirectory(@"Logs");
		}
	}
}
