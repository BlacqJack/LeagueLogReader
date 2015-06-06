using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueLogReaderWF
{
	public partial class ErrorForm : Form
	{
		public ErrorForm(/*string message, string error*/)
		{
			InitializeComponent();
		}

		public void WriteMessage(string message, string error)
		{
			if (!errorMessage.InvokeRequired)
			{
				errorMessage.Text = message + "\n\n" + error;
			}
			else
			{
				this.Invoke(new MethodInvoker(delegate
				{
					errorMessage.Text = message + "\n\n" + error;
				}));
			}
		}


		private void buttonExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
