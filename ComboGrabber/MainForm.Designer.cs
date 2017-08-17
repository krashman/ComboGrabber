namespace ComboGrabber
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnGrab = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importProxiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountGrid = new System.Windows.Forms.DataGridView();
            this.ImportProxyDialog = new System.Windows.Forms.OpenFileDialog();
            this.MaxThreads = new System.Windows.Forms.NumericUpDown();
            this.lblThreadsName = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGrabbedName = new System.Windows.Forms.Label();
            this.lblGrabbed = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.CounterTimer = new System.Windows.Forms.Timer(this.components);
            this.ExportGrabbedDialog = new System.Windows.Forms.SaveFileDialog();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(7, 332);
            this.btnGrab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(375, 32);
            this.btnGrab.TabIndex = 0;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.MenuStrip.Size = new System.Drawing.Size(391, 31);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importProxiesToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.configToolStripMenuItem.Text = "Config...";
            // 
            // importProxiesToolStripMenuItem
            // 
            this.importProxiesToolStripMenuItem.Name = "importProxiesToolStripMenuItem";
            this.importProxiesToolStripMenuItem.Size = new System.Drawing.Size(224, 30);
            this.importProxiesToolStripMenuItem.Text = "Import Proxies...";
            this.importProxiesToolStripMenuItem.Click += new System.EventHandler(this.importProxiesToolStripMenuItem_Click);
            // 
            // AccountGrid
            // 
            this.AccountGrid.AllowUserToAddRows = false;
            this.AccountGrid.AllowUserToDeleteRows = false;
            this.AccountGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Password});
            this.AccountGrid.Location = new System.Drawing.Point(8, 59);
            this.AccountGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AccountGrid.Name = "AccountGrid";
            this.AccountGrid.ReadOnly = true;
            this.AccountGrid.RowTemplate.Height = 28;
            this.AccountGrid.Size = new System.Drawing.Size(375, 246);
            this.AccountGrid.TabIndex = 2;
            // 
            // ImportProxyDialog
            // 
            this.ImportProxyDialog.Filter = "Text Files | *.txt";
            this.ImportProxyDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImportProxyDialog_FileOk);
            // 
            // MaxThreads
            // 
            this.MaxThreads.Location = new System.Drawing.Point(162, 34);
            this.MaxThreads.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MaxThreads.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.MaxThreads.Name = "MaxThreads";
            this.MaxThreads.Size = new System.Drawing.Size(120, 20);
            this.MaxThreads.TabIndex = 3;
            this.MaxThreads.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // lblThreadsName
            // 
            this.lblThreadsName.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblThreadsName.AutoSize = true;
            this.lblThreadsName.Location = new System.Drawing.Point(108, 36);
            this.lblThreadsName.Name = "lblThreadsName";
            this.lblThreadsName.Size = new System.Drawing.Size(49, 13);
            this.lblThreadsName.TabIndex = 4;
            this.lblThreadsName.Text = "Threads:";
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // lblGrabbedName
            // 
            this.lblGrabbedName.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblGrabbedName.AutoSize = true;
            this.lblGrabbedName.Location = new System.Drawing.Point(152, 312);
            this.lblGrabbedName.Name = "lblGrabbedName";
            this.lblGrabbedName.Size = new System.Drawing.Size(51, 13);
            this.lblGrabbedName.TabIndex = 5;
            this.lblGrabbedName.Text = "Grabbed:";
            // 
            // lblGrabbed
            // 
            this.lblGrabbed.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblGrabbed.AutoSize = true;
            this.lblGrabbed.Location = new System.Drawing.Point(209, 312);
            this.lblGrabbed.Name = "lblGrabbed";
            this.lblGrabbed.Size = new System.Drawing.Size(13, 13);
            this.lblGrabbed.TabIndex = 6;
            this.lblGrabbed.Text = "0";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(7, 368);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(375, 32);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // CounterTimer
            // 
            this.CounterTimer.Interval = 1000;
            this.CounterTimer.Tick += new System.EventHandler(this.CounterTimer_Tick);
            // 
            // ExportGrabbedDialog
            // 
            this.ExportGrabbedDialog.Filter = "Text Files | *.txt";
            this.ExportGrabbedDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ExportGrabbedDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 410);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblGrabbed);
            this.Controls.Add(this.lblGrabbedName);
            this.Controls.Add(this.lblThreadsName);
            this.Controls.Add(this.MaxThreads);
            this.Controls.Add(this.AccountGrid);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importProxiesToolStripMenuItem;
        private System.Windows.Forms.DataGridView AccountGrid;
        private System.Windows.Forms.OpenFileDialog ImportProxyDialog;
        private System.Windows.Forms.NumericUpDown MaxThreads;
        private System.Windows.Forms.Label lblThreadsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.Label lblGrabbedName;
        private System.Windows.Forms.Label lblGrabbed;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Timer CounterTimer;
        private System.Windows.Forms.SaveFileDialog ExportGrabbedDialog;
    }
}

