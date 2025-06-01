namespace BackupApp
{
    partial class BackupAppForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupAppForm1));
            this.label1 = new System.Windows.Forms.Label();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.folderListBox = new System.Windows.Forms.ListBox();
            this.addFileBtn = new System.Windows.Forms.Button();
            this.removeFileBtn = new System.Windows.Forms.Button();
            this.addFolderBtn = new System.Windows.Forms.Button();
            this.removeFolderBtn = new System.Windows.Forms.Button();
            this.chooseBackupLocationBtn = new System.Windows.Forms.Button();
            this.BackupPathListBox = new System.Windows.Forms.ListBox();
            this.RemoveBackupFolderBtn = new System.Windows.Forms.Button();
            this.TaskSchedStatusBtn = new System.Windows.Forms.Button();
            this.BackupBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskSchedProgressStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenBackupFolderBtn = new System.Windows.Forms.Button();
            this.TaskSchedProgressStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File(s) to Backup";
            // 
            // fileListBox
            // 
            this.fileListBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(19, 49);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(752, 199);
            this.fileListBox.TabIndex = 1;
            // 
            // folderListBox
            // 
            this.folderListBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.folderListBox.FormattingEnabled = true;
            this.folderListBox.Location = new System.Drawing.Point(19, 315);
            this.folderListBox.Name = "folderListBox";
            this.folderListBox.Size = new System.Drawing.Size(752, 199);
            this.folderListBox.TabIndex = 2;
            // 
            // addFileBtn
            // 
            this.addFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFileBtn.Location = new System.Drawing.Point(615, 20);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(75, 23);
            this.addFileBtn.TabIndex = 3;
            this.addFileBtn.Text = "Add File";
            this.addFileBtn.UseVisualStyleBackColor = true;
            this.addFileBtn.Click += new System.EventHandler(this.addFileBtn_Click);
            // 
            // removeFileBtn
            // 
            this.removeFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFileBtn.Location = new System.Drawing.Point(696, 20);
            this.removeFileBtn.Name = "removeFileBtn";
            this.removeFileBtn.Size = new System.Drawing.Size(75, 23);
            this.removeFileBtn.TabIndex = 4;
            this.removeFileBtn.Text = "Remove File";
            this.removeFileBtn.UseVisualStyleBackColor = true;
            this.removeFileBtn.Click += new System.EventHandler(this.removeFileBtn_Click);
            // 
            // addFolderBtn
            // 
            this.addFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFolderBtn.Location = new System.Drawing.Point(598, 286);
            this.addFolderBtn.Name = "addFolderBtn";
            this.addFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.addFolderBtn.TabIndex = 5;
            this.addFolderBtn.Text = "Add Folder";
            this.addFolderBtn.UseVisualStyleBackColor = true;
            this.addFolderBtn.Click += new System.EventHandler(this.addFolderBtn_Click);
            // 
            // removeFolderBtn
            // 
            this.removeFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFolderBtn.Location = new System.Drawing.Point(679, 286);
            this.removeFolderBtn.Name = "removeFolderBtn";
            this.removeFolderBtn.Size = new System.Drawing.Size(92, 23);
            this.removeFolderBtn.TabIndex = 6;
            this.removeFolderBtn.Text = "Remove Folder";
            this.removeFolderBtn.UseVisualStyleBackColor = true;
            this.removeFolderBtn.Click += new System.EventHandler(this.removeFolderBtn_Click);
            // 
            // chooseBackupLocationBtn
            // 
            this.chooseBackupLocationBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseBackupLocationBtn.Location = new System.Drawing.Point(788, 49);
            this.chooseBackupLocationBtn.Name = "chooseBackupLocationBtn";
            this.chooseBackupLocationBtn.Size = new System.Drawing.Size(167, 23);
            this.chooseBackupLocationBtn.TabIndex = 7;
            this.chooseBackupLocationBtn.Text = "Choose Backup Folder";
            this.chooseBackupLocationBtn.UseVisualStyleBackColor = true;
            this.chooseBackupLocationBtn.Click += new System.EventHandler(this.chooseBackupLocationBtn_Click);
            // 
            // BackupPathListBox
            // 
            this.BackupPathListBox.FormattingEnabled = true;
            this.BackupPathListBox.Location = new System.Drawing.Point(790, 78);
            this.BackupPathListBox.Name = "BackupPathListBox";
            this.BackupPathListBox.Size = new System.Drawing.Size(164, 17);
            this.BackupPathListBox.TabIndex = 8;
            // 
            // RemoveBackupFolderBtn
            // 
            this.RemoveBackupFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveBackupFolderBtn.Location = new System.Drawing.Point(788, 101);
            this.RemoveBackupFolderBtn.Name = "RemoveBackupFolderBtn";
            this.RemoveBackupFolderBtn.Size = new System.Drawing.Size(167, 23);
            this.RemoveBackupFolderBtn.TabIndex = 9;
            this.RemoveBackupFolderBtn.Text = "Remove Backup Folder";
            this.RemoveBackupFolderBtn.UseVisualStyleBackColor = true;
            this.RemoveBackupFolderBtn.Click += new System.EventHandler(this.RemoveBackupFolderBtn_Click);
            // 
            // TaskSchedStatusBtn
            // 
            this.TaskSchedStatusBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TaskSchedStatusBtn.Location = new System.Drawing.Point(788, 130);
            this.TaskSchedStatusBtn.Name = "TaskSchedStatusBtn";
            this.TaskSchedStatusBtn.Size = new System.Drawing.Size(167, 23);
            this.TaskSchedStatusBtn.TabIndex = 10;
            this.TaskSchedStatusBtn.Text = "Check ETC TaskSched Status";
            this.TaskSchedStatusBtn.UseVisualStyleBackColor = true;
            this.TaskSchedStatusBtn.Click += new System.EventHandler(this.TaskSchedStatusBtn_Click);
            // 
            // BackupBtn
            // 
            this.BackupBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackupBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupBtn.Location = new System.Drawing.Point(788, 200);
            this.BackupBtn.Name = "BackupBtn";
            this.BackupBtn.Size = new System.Drawing.Size(167, 48);
            this.BackupBtn.TabIndex = 11;
            this.BackupBtn.Text = "Backup";
            this.BackupBtn.UseVisualStyleBackColor = false;
            this.BackupBtn.Click += new System.EventHandler(this.BackupBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Folder(s) to Backup";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(920, 541);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 541);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Developed by Andrew Messer";
            // 
            // TaskSchedProgressStrip
            // 
            this.TaskSchedProgressStrip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TaskSchedProgressStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskSchedProgressStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TaskSchedProgressStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.TaskSchedProgressStrip.Location = new System.Drawing.Point(0, 0);
            this.TaskSchedProgressStrip.Name = "TaskSchedProgressStrip";
            this.TaskSchedProgressStrip.Size = new System.Drawing.Size(971, 22);
            this.TaskSchedProgressStrip.TabIndex = 15;
            this.TaskSchedProgressStrip.Text = "statusStrip1";
            this.TaskSchedProgressStrip.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // OpenBackupFolderBtn
            // 
            this.OpenBackupFolderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenBackupFolderBtn.Location = new System.Drawing.Point(788, 159);
            this.OpenBackupFolderBtn.Name = "OpenBackupFolderBtn";
            this.OpenBackupFolderBtn.Size = new System.Drawing.Size(167, 23);
            this.OpenBackupFolderBtn.TabIndex = 16;
            this.OpenBackupFolderBtn.Text = "Open Backup Folder";
            this.OpenBackupFolderBtn.UseVisualStyleBackColor = true;
            this.OpenBackupFolderBtn.Click += new System.EventHandler(this.OpenBackupFolderBtn_Click);
            // 
            // BackupAppForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 563);
            this.Controls.Add(this.OpenBackupFolderBtn);
            this.Controls.Add(this.TaskSchedProgressStrip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BackupBtn);
            this.Controls.Add(this.TaskSchedStatusBtn);
            this.Controls.Add(this.RemoveBackupFolderBtn);
            this.Controls.Add(this.BackupPathListBox);
            this.Controls.Add(this.chooseBackupLocationBtn);
            this.Controls.Add(this.removeFolderBtn);
            this.Controls.Add(this.addFolderBtn);
            this.Controls.Add(this.removeFileBtn);
            this.Controls.Add(this.addFileBtn);
            this.Controls.Add(this.folderListBox);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupAppForm1";
            this.Text = "Database Backup 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackupAppForm1_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.TaskSchedProgressStrip.ResumeLayout(false);
            this.TaskSchedProgressStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.ListBox folderListBox;
        private System.Windows.Forms.Button addFileBtn;
        private System.Windows.Forms.Button removeFileBtn;
        private System.Windows.Forms.Button addFolderBtn;
        private System.Windows.Forms.Button removeFolderBtn;
        private System.Windows.Forms.Button chooseBackupLocationBtn;
        private System.Windows.Forms.ListBox BackupPathListBox;
        private System.Windows.Forms.Button RemoveBackupFolderBtn;
        private System.Windows.Forms.Button TaskSchedStatusBtn;
        private System.Windows.Forms.Button BackupBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip TaskSchedProgressStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button OpenBackupFolderBtn;
    }
}