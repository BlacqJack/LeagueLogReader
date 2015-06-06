using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace LeagueLogReaderWF
{
	class StatsHandler
	{
		private static string groupDir = @"Groups";
		public static string[] groups;

		private readonly Form1 form;
		public StatsHandler(Form1 form)
		{
			this.form = form;
		}

		public static void RefreshGroups()
		{
			groups = Directory.GetDirectories(groupDir).ToArray<string>();
			Form1._Form1.GroupComboBoxItems = groups;
		}

		public static void ShowStats(string groupName)
		{
			
		}
	}
}
