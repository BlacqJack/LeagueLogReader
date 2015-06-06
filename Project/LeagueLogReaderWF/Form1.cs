using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LeagueLogReaderWF
{
	public partial class Form1 : Form
	{
		FolderBrowserDialog folderDialog = new FolderBrowserDialog();
		public static Form1 _Form1;

		public int menu = 1;
		public string installPath = Settings.GetInstallDir();
		private string[] names;

		public Form1()
		{
			InitializeComponent();
			_Form1 = this;

			settingsRootBox.Text = Settings.GetInstallDir();
			settingsBotORBox.Checked = Boolean.Parse(Settings.GetSettings()[1]);

			if (Settings.GetInstallDir() == "" || Settings.GetInstallDir() == "\\")
			{
				MessageBox.Show("Please enter where your LoL is installed", "First time setup");
				ChangeMenu(3);
				settingsRootButton_Click(this, EventArgs.Empty);
				settingsSaveButton_Click(this, EventArgs.Empty);
			}

			FixSize();
			labelVersion.Text = "v" + Settings.version;
		}



		private void buttonStats_Click(object sender, EventArgs e)
		{
			ChangeMenu(1);
			StatsHandler.RefreshGroups();
		}

		private void buttonNewSummoner_Click(object sender, EventArgs e)
		{
			ChangeMenu(2);
		}

		private void buttonSettings_Click(object sender, EventArgs e)
		{
			ChangeMenu(3);
		}

		private void buttonHelp_Click(object sender, EventArgs e)
		{
			ChangeMenu(4);
		}



		//////////////////// SETTINGS TAB ////////////////////

		private async void settingsReset_Click(object sender, EventArgs e) // RESET
		{
			Settings.Reset();

			installPath = Settings.GetInstallDir();
			settingsRootBox.Text = "";
			settingsBotORBox.Checked = Settings.GetIncludeBots();

			settingsHaveResetText.ForeColor = Color.Black;
			await Task.Delay(1000);
			settingsHaveResetText.ForeColor = settingsBox.BackColor;
		}

		private async void settingsSaveButton_Click(object sender, EventArgs e) // SAVE
		{
			installPath = Settings.Save(settingsRootBox.Text, settingsBotORBox.Checked);

			settingsRootBox.Text = Settings.GetInstallDir();

			settingsSaveText.ForeColor = Color.Black;
			await Task.Delay(1000);
			settingsSaveText.ForeColor = settingsBox.BackColor;
		}

		private void settingsRootButton_Click(object sender, EventArgs e) // FOLDER BUTTON
		{
			folderDialog.ShowNewFolderButton = false;
			
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				settingsRootBox.Text = folderDialog.SelectedPath;
			}
			
		}


		//////////////////// BACKGROUND WORKER ////////////////////

		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			names = new string[sumListBox.Items.Count];

			for (int i = 0; i < sumListBox.Items.Count; i++)
			{
				if (sumListBox.InvokeRequired)
				{
					this.Invoke(new MethodInvoker(delegate
					{
						names[i] = this.sumListBox.Items[i].Text;
						sumProgress.Maximum = names.Length * 100;
					}));
				}
				else
				{
					names[i] = this.sumListBox.Items[i].Text;
					sumProgress.Maximum = names.Length * 100;
				}
			}

			Analyzing.ReadLogs(names, sumGroupBox.Text, Settings.GetInstallDir(), 4, bgWorker);

			if (!Analyzing.hadError)
			{
				Analyzing.Count(sumGroupBox.Text, bgWorker); 
			}
			else
			{
				LogBoxText = "The program encountered an error and can't finish the analyze!";
			}
		}

		private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			int temp = e.ProgressPercentage;

			if (temp > names.Length * 100)
			{
				temp = names.Length * 100;
			}

			sumPercentText.Text = (temp / names.Length).ToString() + "%";
			this.sumProgress.Value = temp;
		}

		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			buttonSettings.Enabled = true;
			buttonStats.Enabled = true;
			buttonNewSummoner.Enabled = true;
			buttonHelp.Enabled = true;
			textBox1.Enabled = true;
			sumStart.Enabled = true;
		}



		//////////////////// SUM ////////////////////

		private void sumAddSum_Click(object sender, EventArgs e)
		{
			string newSummoner = textBox1.Text;
			bool doesExist = false;

			foreach (ListViewItem item in sumListBox.Items)
			{
				if (newSummoner == item.Text)
				{
					doesExist = true;
				} 
			}

			if (!doesExist)
			{
				sumListBox.Items.Add(newSummoner);
			}
		}

		private void sumStart_Click_1(object sender, EventArgs e)
		{
			if (!bgWorker.IsBusy)
			{
				if (System.IO.Directory.Exists(@"Group\" + sumGroupBox.Text))
				{
					DialogResult overwrite = MessageBox.Show("This group already exists. Are you sure you want to overwrite the old info?", "Warning", MessageBoxButtons.YesNo);

					if (overwrite == DialogResult.Yes)
					{
						buttonSettings.Enabled = false;
						buttonStats.Enabled = false;
						buttonNewSummoner.Enabled = false;
						buttonHelp.Enabled = false;
						textBox1.Enabled = false;
						sumStart.Enabled = false;

						bgWorker.WorkerReportsProgress = true;
						bgWorker.RunWorkerAsync();
					} 
				}
				else
				{
					buttonSettings.Enabled = false;
					buttonStats.Enabled = false;
					buttonNewSummoner.Enabled = false;
					buttonHelp.Enabled = false;
					textBox1.Enabled = false;
					sumStart.Enabled = false;

					bgWorker.WorkerReportsProgress = true;
					bgWorker.RunWorkerAsync();
				}
			}
		}

		private void sumRemoveSum_Click(object sender, EventArgs e)
		{
			try
			{
				sumListBox.Items.Remove(sumListBox.SelectedItems[0]);
			}
			catch (ArgumentOutOfRangeException)
			{
				Debug.WriteLine("No item selected");
			}
		}



		//////////////////// STATS ////////////////////

		private void statsOpenButton_Click(object sender, EventArgs e)
		{
			if (System.IO.Directory.Exists(@"Groups"))
			{
				System.Diagnostics.Process.Start(@"Groups");
			}
		}

		private void statsRefreshCombo_Click(object sender, EventArgs e)
		{
			StatsHandler.RefreshGroups();
		}

		private void statsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StatsHandler.ShowStats(_Form1.statsComboBox.Items[_Form1.statsComboBox.SelectedIndex].ToString());
		}

		public string[] GroupComboBoxItems
		{
			get
			{
				string[] items = new string[_Form1.statsComboBox.Items.Count];

				for (int i = 0; i < _Form1.statsComboBox.Items.Count; i++)
				{
					items[i] = _Form1.statsComboBox.Items[i].ToString();
				}

				return items;
			}

			set
			{
				foreach (string groupName in value)
				{
					if (!_Form1.statsComboBox.Items.Contains(groupName.Remove(0, 7)))
					{
						_Form1.statsComboBox.Items.Add(groupName.Remove(0, 7));  
					}
				}
			}
		}



		//////////////////// FUNCTIONS ////////////////////

		public void ChangeMenu(int menu)
		{
			Color inactiveColor = SystemColors.Window;
			Color activeColor = SystemColors.ButtonFace;

			if (menu == 1) // Stats
			{
				ShowBox(statsBox);

				buttonStats.Enabled = false;
				buttonStats.BackColor = activeColor;
				buttonNewSummoner.Enabled = true;
				buttonNewSummoner.BackColor = inactiveColor;
				buttonSettings.Enabled = true;
				buttonSettings.BackColor = inactiveColor;
			}

			if (menu == 2) // Summoner
			{
				ShowBox(sumBox);

				buttonStats.Enabled = true;
				buttonStats.BackColor = inactiveColor;
				buttonNewSummoner.Enabled = false;
				buttonNewSummoner.BackColor = activeColor;
				buttonSettings.Enabled = true;
				buttonSettings.BackColor = inactiveColor;
			}

			if (menu == 3) // Settings
			{
				ShowBox(settingsBox);

				buttonStats.Enabled = true;
				buttonStats.BackColor = inactiveColor;
				buttonNewSummoner.Enabled = true;
				buttonNewSummoner.BackColor = inactiveColor;
				buttonSettings.Enabled = false;
				buttonSettings.BackColor = activeColor;
			}
		}

		public void ShowBox(GroupBox box)
		{
			box.BringToFront();
		}

		private void FixSize()
		{
			MaximizeBox = false;

			Size boxSize = sumBox.Size;
			Point pos = sumBox.Location; // 213; 4 laptop //  desktop 160; 3

			statsBox.Size = boxSize;
			settingsBox.Size = boxSize;

			//MaximumSize = new Size(800, 460);
			//Size = new Size(800, 460);

			statsBox.Location = pos;
			settingsBox.Location = pos;
		}

		public string LogBoxText
		{
			get
			{
				return sumLogBox.Text;
			}

			set
			{
				if (sumLogBox.InvokeRequired)
				{
					this.Invoke(new MethodInvoker(delegate
					{
						sumLogBox.AppendText(Environment.NewLine + value);
					}));
				}
				else
				{
					sumLogBox.AppendText(Environment.NewLine + value);
				}
			}
		}
		
	}
}
