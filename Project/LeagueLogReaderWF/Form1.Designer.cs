namespace LeagueLogReaderWF
{
    partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.buttonStats = new System.Windows.Forms.Button();
			this.buttonNewSummoner = new System.Windows.Forms.Button();
			this.buttonSettings = new System.Windows.Forms.Button();
			this.labelCred = new System.Windows.Forms.Label();
			this.sumBox = new System.Windows.Forms.GroupBox();
			this.sumPercentText = new System.Windows.Forms.Label();
			this.sumGroupBox = new System.Windows.Forms.TextBox();
			this.sumRemoveSum = new System.Windows.Forms.Button();
			this.sumAddSum = new System.Windows.Forms.Button();
			this.sumListBox = new System.Windows.Forms.ListView();
			this.sumLogBox = new System.Windows.Forms.TextBox();
			this.sumProgress = new System.Windows.Forms.ProgressBar();
			this.sumStart = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.sumSumLabel = new System.Windows.Forms.Label();
			this.statsBox = new System.Windows.Forms.GroupBox();
			this.statsRefreshCombo = new System.Windows.Forms.Button();
			this.statsComboBox = new System.Windows.Forms.ComboBox();
			this.statsOpenButton = new System.Windows.Forms.Button();
			this.settingsBox = new System.Windows.Forms.GroupBox();
			this.settingsBotORBox = new System.Windows.Forms.CheckBox();
			this.settingsBotORText = new System.Windows.Forms.Label();
			this.settingsRootButton = new System.Windows.Forms.Button();
			this.settingsSaveText = new System.Windows.Forms.Label();
			this.settingsSaveButton = new System.Windows.Forms.Button();
			this.settingsRootText = new System.Windows.Forms.Label();
			this.settingsRootBox = new System.Windows.Forms.TextBox();
			this.settingsHaveResetText = new System.Windows.Forms.Label();
			this.settingsReset = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonHelp = new System.Windows.Forms.Button();
			this.labelVersion = new System.Windows.Forms.Label();
			this.bgWorker = new System.ComponentModel.BackgroundWorker();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureSeparator = new System.Windows.Forms.PictureBox();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.sumBox.SuspendLayout();
			this.statsBox.SuspendLayout();
			this.settingsBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureSeparator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonStats
			// 
			this.buttonStats.BackColor = System.Drawing.SystemColors.Window;
			this.buttonStats.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonStats.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStats.Location = new System.Drawing.Point(20, 115);
			this.buttonStats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonStats.Name = "buttonStats";
			this.buttonStats.Size = new System.Drawing.Size(112, 41);
			this.buttonStats.TabIndex = 1;
			this.buttonStats.Text = "Stats";
			this.buttonStats.UseVisualStyleBackColor = false;
			this.buttonStats.Click += new System.EventHandler(this.buttonStats_Click);
			// 
			// buttonNewSummoner
			// 
			this.buttonNewSummoner.BackColor = System.Drawing.SystemColors.Window;
			this.buttonNewSummoner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonNewSummoner.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonNewSummoner.Location = new System.Drawing.Point(20, 166);
			this.buttonNewSummoner.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonNewSummoner.Name = "buttonNewSummoner";
			this.buttonNewSummoner.Size = new System.Drawing.Size(112, 41);
			this.buttonNewSummoner.TabIndex = 2;
			this.buttonNewSummoner.Text = "Add New Summoner";
			this.buttonNewSummoner.UseVisualStyleBackColor = false;
			this.buttonNewSummoner.Click += new System.EventHandler(this.buttonNewSummoner_Click);
			// 
			// buttonSettings
			// 
			this.buttonSettings.BackColor = System.Drawing.SystemColors.Window;
			this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSettings.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSettings.Location = new System.Drawing.Point(20, 215);
			this.buttonSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(112, 41);
			this.buttonSettings.TabIndex = 3;
			this.buttonSettings.Text = "Settings";
			this.buttonSettings.UseVisualStyleBackColor = false;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			// 
			// labelCred
			// 
			this.labelCred.AutoSize = true;
			this.labelCred.Location = new System.Drawing.Point(18, 321);
			this.labelCred.Name = "labelCred";
			this.labelCred.Size = new System.Drawing.Size(73, 13);
			this.labelCred.TabIndex = 5;
			this.labelCred.Text = "Created by bq";
			// 
			// sumBox
			// 
			this.sumBox.Controls.Add(this.sumPercentText);
			this.sumBox.Controls.Add(this.sumGroupBox);
			this.sumBox.Controls.Add(this.sumRemoveSum);
			this.sumBox.Controls.Add(this.sumAddSum);
			this.sumBox.Controls.Add(this.sumListBox);
			this.sumBox.Controls.Add(this.sumLogBox);
			this.sumBox.Controls.Add(this.sumProgress);
			this.sumBox.Controls.Add(this.sumStart);
			this.sumBox.Controls.Add(this.textBox1);
			this.sumBox.Controls.Add(this.sumSumLabel);
			this.sumBox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumBox.Location = new System.Drawing.Point(160, 3);
			this.sumBox.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
			this.sumBox.Name = "sumBox";
			this.sumBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.sumBox.Size = new System.Drawing.Size(410, 330);
			this.sumBox.TabIndex = 6;
			this.sumBox.TabStop = false;
			this.sumBox.Text = "Add New Summoner";
			// 
			// sumPercentText
			// 
			this.sumPercentText.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumPercentText.Location = new System.Drawing.Point(365, 290);
			this.sumPercentText.Name = "sumPercentText";
			this.sumPercentText.Size = new System.Drawing.Size(40, 23);
			this.sumPercentText.TabIndex = 9;
			this.sumPercentText.Text = "100%";
			this.sumPercentText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sumGroupBox
			// 
			this.sumGroupBox.Font = new System.Drawing.Font("Calibri", 12F);
			this.sumGroupBox.Location = new System.Drawing.Point(250, 35);
			this.sumGroupBox.MaxLength = 12;
			this.sumGroupBox.Name = "sumGroupBox";
			this.sumGroupBox.Size = new System.Drawing.Size(110, 27);
			this.sumGroupBox.TabIndex = 8;
			this.sumGroupBox.Text = "Group-name";
			this.sumGroupBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// sumRemoveSum
			// 
			this.sumRemoveSum.BackColor = System.Drawing.SystemColors.Window;
			this.sumRemoveSum.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.sumRemoveSum.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Window;
			this.sumRemoveSum.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
			this.sumRemoveSum.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HighlightText;
			this.sumRemoveSum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sumRemoveSum.Font = new System.Drawing.Font("Roboto", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumRemoveSum.Location = new System.Drawing.Point(223, 102);
			this.sumRemoveSum.Name = "sumRemoveSum";
			this.sumRemoveSum.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.sumRemoveSum.Size = new System.Drawing.Size(20, 20);
			this.sumRemoveSum.TabIndex = 7;
			this.sumRemoveSum.Text = "-";
			this.sumRemoveSum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.sumRemoveSum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.sumRemoveSum.UseVisualStyleBackColor = false;
			this.sumRemoveSum.Click += new System.EventHandler(this.sumRemoveSum_Click);
			// 
			// sumAddSum
			// 
			this.sumAddSum.BackColor = System.Drawing.SystemColors.Window;
			this.sumAddSum.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.sumAddSum.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Window;
			this.sumAddSum.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
			this.sumAddSum.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HighlightText;
			this.sumAddSum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sumAddSum.Font = new System.Drawing.Font("Roboto", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumAddSum.Location = new System.Drawing.Point(197, 102);
			this.sumAddSum.Name = "sumAddSum";
			this.sumAddSum.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.sumAddSum.Size = new System.Drawing.Size(20, 20);
			this.sumAddSum.TabIndex = 6;
			this.sumAddSum.Text = "+";
			this.sumAddSum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.sumAddSum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.sumAddSum.UseVisualStyleBackColor = false;
			this.sumAddSum.Click += new System.EventHandler(this.sumAddSum_Click);
			// 
			// sumListBox
			// 
			this.sumListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumListBox.Location = new System.Drawing.Point(250, 70);
			this.sumListBox.Name = "sumListBox";
			this.sumListBox.Size = new System.Drawing.Size(110, 90);
			this.sumListBox.TabIndex = 5;
			this.sumListBox.UseCompatibleStateImageBehavior = false;
			this.sumListBox.View = System.Windows.Forms.View.List;
			// 
			// sumLogBox
			// 
			this.sumLogBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sumLogBox.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumLogBox.Location = new System.Drawing.Point(30, 210);
			this.sumLogBox.MaxLength = 999999999;
			this.sumLogBox.Multiline = true;
			this.sumLogBox.Name = "sumLogBox";
			this.sumLogBox.ReadOnly = true;
			this.sumLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.sumLogBox.Size = new System.Drawing.Size(350, 70);
			this.sumLogBox.TabIndex = 4;
			// 
			// sumProgress
			// 
			this.sumProgress.BackColor = System.Drawing.Color.White;
			this.sumProgress.Location = new System.Drawing.Point(30, 290);
			this.sumProgress.Maximum = 500;
			this.sumProgress.Name = "sumProgress";
			this.sumProgress.Size = new System.Drawing.Size(330, 23);
			this.sumProgress.Step = 1;
			this.sumProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.sumProgress.TabIndex = 2;
			// 
			// sumStart
			// 
			this.sumStart.BackColor = System.Drawing.SystemColors.Window;
			this.sumStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.sumStart.Location = new System.Drawing.Point(250, 170);
			this.sumStart.Name = "sumStart";
			this.sumStart.Size = new System.Drawing.Size(110, 30);
			this.sumStart.TabIndex = 3;
			this.sumStart.Text = "Start";
			this.sumStart.UseVisualStyleBackColor = false;
			this.sumStart.Click += new System.EventHandler(this.sumStart_Click_1);
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(30, 100);
			this.textBox1.MaxLength = 16;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(160, 27);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "BlackJack";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// sumSumLabel
			// 
			this.sumSumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sumSumLabel.Location = new System.Drawing.Point(30, 70);
			this.sumSumLabel.Name = "sumSumLabel";
			this.sumSumLabel.Size = new System.Drawing.Size(166, 31);
			this.sumSumLabel.TabIndex = 0;
			this.sumSumLabel.Text = "New Summoner";
			this.sumSumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statsBox
			// 
			this.statsBox.Controls.Add(this.label1);
			this.statsBox.Controls.Add(this.statsRefreshCombo);
			this.statsBox.Controls.Add(this.statsComboBox);
			this.statsBox.Controls.Add(this.statsOpenButton);
			this.statsBox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statsBox.Location = new System.Drawing.Point(160, 3);
			this.statsBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.statsBox.Name = "statsBox";
			this.statsBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.statsBox.Size = new System.Drawing.Size(410, 330);
			this.statsBox.TabIndex = 7;
			this.statsBox.TabStop = false;
			this.statsBox.Text = "Stats";
			// 
			// statsRefreshCombo
			// 
			this.statsRefreshCombo.BackColor = System.Drawing.SystemColors.Window;
			this.statsRefreshCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.statsRefreshCombo.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statsRefreshCombo.Location = new System.Drawing.Point(224, 33);
			this.statsRefreshCombo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.statsRefreshCombo.Name = "statsRefreshCombo";
			this.statsRefreshCombo.Size = new System.Drawing.Size(73, 28);
			this.statsRefreshCombo.TabIndex = 2;
			this.statsRefreshCombo.Text = "Refresh";
			this.statsRefreshCombo.UseVisualStyleBackColor = false;
			this.statsRefreshCombo.Click += new System.EventHandler(this.statsRefreshCombo_Click);
			// 
			// statsComboBox
			// 
			this.statsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.statsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.statsComboBox.FormattingEnabled = true;
			this.statsComboBox.ItemHeight = 21;
			this.statsComboBox.Location = new System.Drawing.Point(30, 33);
			this.statsComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.statsComboBox.MaxDropDownItems = 30;
			this.statsComboBox.MaxLength = 12;
			this.statsComboBox.Name = "statsComboBox";
			this.statsComboBox.Size = new System.Drawing.Size(188, 29);
			this.statsComboBox.TabIndex = 1;
			this.statsComboBox.SelectedIndexChanged += new System.EventHandler(this.statsComboBox_SelectedIndexChanged);
			// 
			// statsOpenButton
			// 
			this.statsOpenButton.BackColor = System.Drawing.SystemColors.Window;
			this.statsOpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.statsOpenButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statsOpenButton.Location = new System.Drawing.Point(30, 275);
			this.statsOpenButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.statsOpenButton.Name = "statsOpenButton";
			this.statsOpenButton.Size = new System.Drawing.Size(100, 33);
			this.statsOpenButton.TabIndex = 0;
			this.statsOpenButton.Text = "Open Folder";
			this.statsOpenButton.UseVisualStyleBackColor = false;
			this.statsOpenButton.Click += new System.EventHandler(this.statsOpenButton_Click);
			// 
			// settingsBox
			// 
			this.settingsBox.Controls.Add(this.settingsBotORBox);
			this.settingsBox.Controls.Add(this.settingsBotORText);
			this.settingsBox.Controls.Add(this.settingsRootButton);
			this.settingsBox.Controls.Add(this.settingsSaveText);
			this.settingsBox.Controls.Add(this.settingsSaveButton);
			this.settingsBox.Controls.Add(this.settingsRootText);
			this.settingsBox.Controls.Add(this.settingsRootBox);
			this.settingsBox.Controls.Add(this.settingsHaveResetText);
			this.settingsBox.Controls.Add(this.settingsReset);
			this.settingsBox.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsBox.Location = new System.Drawing.Point(166, 0);
			this.settingsBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.settingsBox.Name = "settingsBox";
			this.settingsBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.settingsBox.Size = new System.Drawing.Size(410, 330);
			this.settingsBox.TabIndex = 7;
			this.settingsBox.TabStop = false;
			this.settingsBox.Text = "Settings";
			// 
			// settingsBotORBox
			// 
			this.settingsBotORBox.AutoSize = true;
			this.settingsBotORBox.Location = new System.Drawing.Point(170, 86);
			this.settingsBotORBox.Name = "settingsBotORBox";
			this.settingsBotORBox.Size = new System.Drawing.Size(15, 14);
			this.settingsBotORBox.TabIndex = 8;
			this.settingsBotORBox.UseVisualStyleBackColor = true;
			// 
			// settingsBotORText
			// 
			this.settingsBotORText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.settingsBotORText.AutoSize = true;
			this.settingsBotORText.Location = new System.Drawing.Point(20, 80);
			this.settingsBotORText.Name = "settingsBotORText";
			this.settingsBotORText.Size = new System.Drawing.Size(147, 21);
			this.settingsBotORText.TabIndex = 7;
			this.settingsBotORText.Text = "Include bot games:";
			this.settingsBotORText.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// settingsRootButton
			// 
			this.settingsRootButton.Font = new System.Drawing.Font("Roboto", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsRootButton.Location = new System.Drawing.Point(366, 48);
			this.settingsRootButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.settingsRootButton.Name = "settingsRootButton";
			this.settingsRootButton.Size = new System.Drawing.Size(25, 24);
			this.settingsRootButton.TabIndex = 6;
			this.settingsRootButton.Text = "...";
			this.settingsRootButton.UseVisualStyleBackColor = true;
			this.settingsRootButton.Click += new System.EventHandler(this.settingsRootButton_Click);
			// 
			// settingsSaveText
			// 
			this.settingsSaveText.AutoSize = true;
			this.settingsSaveText.BackColor = System.Drawing.Color.Transparent;
			this.settingsSaveText.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsSaveText.ForeColor = System.Drawing.SystemColors.Control;
			this.settingsSaveText.Location = new System.Drawing.Point(270, 290);
			this.settingsSaveText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.settingsSaveText.Name = "settingsSaveText";
			this.settingsSaveText.Size = new System.Drawing.Size(41, 15);
			this.settingsSaveText.TabIndex = 5;
			this.settingsSaveText.Text = "Saved!";
			// 
			// settingsSaveButton
			// 
			this.settingsSaveButton.BackColor = System.Drawing.SystemColors.Window;
			this.settingsSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.settingsSaveButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsSaveButton.Location = new System.Drawing.Point(320, 280);
			this.settingsSaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.settingsSaveButton.Name = "settingsSaveButton";
			this.settingsSaveButton.Size = new System.Drawing.Size(78, 33);
			this.settingsSaveButton.TabIndex = 4;
			this.settingsSaveButton.Text = "Save";
			this.settingsSaveButton.UseVisualStyleBackColor = false;
			this.settingsSaveButton.Click += new System.EventHandler(this.settingsSaveButton_Click);
			// 
			// settingsRootText
			// 
			this.settingsRootText.AutoSize = true;
			this.settingsRootText.Location = new System.Drawing.Point(88, 50);
			this.settingsRootText.Name = "settingsRootText";
			this.settingsRootText.Size = new System.Drawing.Size(79, 21);
			this.settingsRootText.TabIndex = 3;
			this.settingsRootText.Text = "LoL Path:";
			// 
			// settingsRootBox
			// 
			this.settingsRootBox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsRootBox.Location = new System.Drawing.Point(170, 48);
			this.settingsRootBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.settingsRootBox.Name = "settingsRootBox";
			this.settingsRootBox.Size = new System.Drawing.Size(190, 25);
			this.settingsRootBox.TabIndex = 2;
			// 
			// settingsHaveResetText
			// 
			this.settingsHaveResetText.AutoSize = true;
			this.settingsHaveResetText.BackColor = System.Drawing.Color.Transparent;
			this.settingsHaveResetText.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsHaveResetText.ForeColor = System.Drawing.SystemColors.Control;
			this.settingsHaveResetText.Location = new System.Drawing.Point(90, 290);
			this.settingsHaveResetText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.settingsHaveResetText.Name = "settingsHaveResetText";
			this.settingsHaveResetText.Size = new System.Drawing.Size(135, 15);
			this.settingsHaveResetText.TabIndex = 1;
			this.settingsHaveResetText.Text = "Settings have been reset!";
			// 
			// settingsReset
			// 
			this.settingsReset.BackColor = System.Drawing.SystemColors.Window;
			this.settingsReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.settingsReset.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.settingsReset.Location = new System.Drawing.Point(12, 280);
			this.settingsReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.settingsReset.Name = "settingsReset";
			this.settingsReset.Size = new System.Drawing.Size(68, 33);
			this.settingsReset.TabIndex = 0;
			this.settingsReset.Text = "Reset";
			this.settingsReset.UseVisualStyleBackColor = false;
			this.settingsReset.Click += new System.EventHandler(this.settingsReset_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonHelp);
			this.groupBox1.Controls.Add(this.labelVersion);
			this.groupBox1.Controls.Add(this.picLogo);
			this.groupBox1.Controls.Add(this.buttonStats);
			this.groupBox1.Controls.Add(this.buttonNewSummoner);
			this.groupBox1.Controls.Add(this.labelCred);
			this.groupBox1.Controls.Add(this.buttonSettings);
			this.groupBox1.Location = new System.Drawing.Point(-5, -10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(150, 360);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// buttonHelp
			// 
			this.buttonHelp.BackColor = System.Drawing.SystemColors.Window;
			this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonHelp.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonHelp.Location = new System.Drawing.Point(20, 266);
			this.buttonHelp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.Size = new System.Drawing.Size(112, 41);
			this.buttonHelp.TabIndex = 7;
			this.buttonHelp.Text = "Help / About";
			this.buttonHelp.UseVisualStyleBackColor = false;
			this.buttonHelp.Visible = false;
			this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(110, 321);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(35, 13);
			this.labelVersion.TabIndex = 6;
			this.labelVersion.Text = "label1";
			// 
			// bgWorker
			// 
			this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
			this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
			this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(143, 153);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "Coming soon?";
			// 
			// pictureSeparator
			// 
			this.pictureSeparator.ErrorImage = global::LeagueLogReaderWF.Properties.Resources.separator2;
			this.pictureSeparator.Image = global::LeagueLogReaderWF.Properties.Resources.separator2;
			this.pictureSeparator.ImageLocation = "";
			this.pictureSeparator.Location = new System.Drawing.Point(143, 0);
			this.pictureSeparator.Margin = new System.Windows.Forms.Padding(0);
			this.pictureSeparator.Name = "pictureSeparator";
			this.pictureSeparator.Size = new System.Drawing.Size(2, 366);
			this.pictureSeparator.TabIndex = 4;
			this.pictureSeparator.TabStop = false;
			// 
			// picLogo
			// 
			this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
			this.picLogo.Location = new System.Drawing.Point(20, 21);
			this.picLogo.Margin = new System.Windows.Forms.Padding(2);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(112, 85);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 0;
			this.picLogo.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 338);
			this.Controls.Add(this.statsBox);
			this.Controls.Add(this.sumBox);
			this.Controls.Add(this.settingsBox);
			this.Controls.Add(this.pictureSeparator);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(602, 376);
			this.MinimumSize = new System.Drawing.Size(602, 376);
			this.Name = "Form1";
			this.Text = "LeagueLogReader";
			this.sumBox.ResumeLayout(false);
			this.sumBox.PerformLayout();
			this.statsBox.ResumeLayout(false);
			this.statsBox.PerformLayout();
			this.settingsBox.ResumeLayout(false);
			this.settingsBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureSeparator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button buttonStats;
        private System.Windows.Forms.Button buttonNewSummoner;
        private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.PictureBox pictureSeparator;
		private System.Windows.Forms.Label labelCred;
        private System.Windows.Forms.GroupBox sumBox;
        private System.Windows.Forms.GroupBox statsBox;
		private System.Windows.Forms.GroupBox settingsBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelVersion;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label sumSumLabel;
		public System.Windows.Forms.ProgressBar sumProgress;
		private System.Windows.Forms.Button sumStart;
		private System.ComponentModel.BackgroundWorker bgWorker;
		private System.Windows.Forms.Button settingsReset;
		private System.Windows.Forms.Label settingsHaveResetText;
		private System.Windows.Forms.TextBox settingsRootBox;
		private System.Windows.Forms.Label settingsRootText;
		private System.Windows.Forms.Label settingsSaveText;
		private System.Windows.Forms.Button settingsSaveButton;
		private System.Windows.Forms.Button settingsRootButton;
		private System.Windows.Forms.CheckBox settingsBotORBox;
		private System.Windows.Forms.Label settingsBotORText;
		public System.Windows.Forms.TextBox sumLogBox;
		private System.Windows.Forms.ListView sumListBox;
		private System.Windows.Forms.Button sumRemoveSum;
		private System.Windows.Forms.Button sumAddSum;
		private System.Windows.Forms.TextBox sumGroupBox;
		private System.Windows.Forms.Button statsOpenButton;
		private System.Windows.Forms.Label sumPercentText;
		private System.Windows.Forms.Button buttonHelp;
		private System.Windows.Forms.ComboBox statsComboBox;
		private System.Windows.Forms.Button statsRefreshCombo;
		private System.Windows.Forms.Label label1;
    }
}

