namespace LeagueLogReaderWF
{
	partial class ErrorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonExit = new System.Windows.Forms.Button();
			this.errorMessage = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonExit
			// 
			this.buttonExit.AutoSize = true;
			this.buttonExit.Location = new System.Drawing.Point(90, 100);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(110, 30);
			this.buttonExit.TabIndex = 0;
			this.buttonExit.Text = "OK";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// errorMessage
			// 
			this.errorMessage.AutoSize = true;
			this.errorMessage.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorMessage.Location = new System.Drawing.Point(130, 60);
			this.errorMessage.Name = "errorMessage";
			this.errorMessage.Size = new System.Drawing.Size(41, 16);
			this.errorMessage.TabIndex = 1;
			this.errorMessage.Text = "label1";
			this.errorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ErrorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 162);
			this.Controls.Add(this.errorMessage);
			this.Controls.Add(this.buttonExit);
			this.Name = "ErrorForm";
			this.Text = "Error";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Label errorMessage;
	}
}