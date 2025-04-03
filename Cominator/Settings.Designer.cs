namespace Cominator
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExe = new System.Windows.Forms.Label();
            this.txtboxExe = new System.Windows.Forms.TextBox();
            this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtboxArgs = new System.Windows.Forms.TextBox();
            this.lblArgs = new System.Windows.Forms.Label();
            this.lblSample = new System.Windows.Forms.Label();
            this.txtboxSample = new System.Windows.Forms.TextBox();
            this.listBaudRates = new System.Windows.Forms.ListBox();
            this.lblBaudRates = new System.Windows.Forms.Label();
            this.txtboxNewBaudrate = new System.Windows.Forms.TextBox();
            this.btnDeleteBaudRate = new System.Windows.Forms.Button();
            this.btnAddBaudRate = new System.Windows.Forms.Button();
            this.lblNamePop = new System.Windows.Forms.Label();
            this.numericDeviceNameLength = new System.Windows.Forms.NumericUpDown();
            this.chkNotifyOnConnect = new System.Windows.Forms.CheckBox();
            this.chkNotifyOnDisconnect = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listShortcuts = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddShortcut = new System.Windows.Forms.Button();
            this.btnEditShortcut = new System.Windows.Forms.Button();
            this.btnDeleteShortcut = new System.Windows.Forms.Button();
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLaunchOnStartup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericDeviceNameLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(21, 533);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(300, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(393, 533);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(288, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblExe
            // 
            this.lblExe.AutoSize = true;
            this.lblExe.Location = new System.Drawing.Point(17, 16);
            this.lblExe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExe.Name = "lblExe";
            this.lblExe.Size = new System.Drawing.Size(179, 16);
            this.lblExe.TabIndex = 2;
            this.lblExe.Text = "Choose an executable to run:";
            // 
            // txtboxExe
            // 
            this.txtboxExe.Location = new System.Drawing.Point(21, 37);
            this.txtboxExe.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxExe.Name = "txtboxExe";
            this.txtboxExe.Size = new System.Drawing.Size(659, 22);
            this.txtboxExe.TabIndex = 3;
            this.txtboxExe.TextChanged += new System.EventHandler(this.txtboxExe_TextChanged);
            // 
            // dlgBrowse
            // 
            this.dlgBrowse.FileName = "openFileDialog1";
            this.dlgBrowse.Filter = "Executable files (*.exe)|*.exe|Batch files (*.bat)|*.bat|All files (*.*)|*.*";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(21, 69);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 28);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtboxArgs
            // 
            this.txtboxArgs.Location = new System.Drawing.Point(21, 133);
            this.txtboxArgs.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxArgs.Name = "txtboxArgs";
            this.txtboxArgs.Size = new System.Drawing.Size(659, 22);
            this.txtboxArgs.TabIndex = 3;
            this.txtboxArgs.TextChanged += new System.EventHandler(this.txtboxArgs_TextChanged);
            // 
            // lblArgs
            // 
            this.lblArgs.AutoSize = true;
            this.lblArgs.Location = new System.Drawing.Point(17, 113);
            this.lblArgs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArgs.Name = "lblArgs";
            this.lblArgs.Size = new System.Drawing.Size(524, 16);
            this.lblArgs.TabIndex = 2;
            this.lblArgs.Text = "Specify arguments for the executable, using {COM} and {BAUDRATE} as placeholders:" +
    "";
            // 
            // lblSample
            // 
            this.lblSample.AutoSize = true;
            this.lblSample.Location = new System.Drawing.Point(17, 167);
            this.lblSample.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(301, 16);
            this.lblSample.TabIndex = 2;
            this.lblSample.Text = "Arguments with COM6 and 115200 as an example:";
            // 
            // txtboxSample
            // 
            this.txtboxSample.Location = new System.Drawing.Point(21, 187);
            this.txtboxSample.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxSample.Name = "txtboxSample";
            this.txtboxSample.ReadOnly = true;
            this.txtboxSample.Size = new System.Drawing.Size(659, 22);
            this.txtboxSample.TabIndex = 3;
            // 
            // listBaudRates
            // 
            this.listBaudRates.FormattingEnabled = true;
            this.listBaudRates.ItemHeight = 16;
            this.listBaudRates.Location = new System.Drawing.Point(21, 266);
            this.listBaudRates.Margin = new System.Windows.Forms.Padding(4);
            this.listBaudRates.Name = "listBaudRates";
            this.listBaudRates.Size = new System.Drawing.Size(125, 116);
            this.listBaudRates.TabIndex = 5;
            this.listBaudRates.SelectedIndexChanged += new System.EventHandler(this.listBaudRates_SelectedIndexChanged);
            this.listBaudRates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBaudRates_KeyDown);
            // 
            // lblBaudRates
            // 
            this.lblBaudRates.AutoSize = true;
            this.lblBaudRates.Location = new System.Drawing.Point(17, 233);
            this.lblBaudRates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRates.Name = "lblBaudRates";
            this.lblBaudRates.Size = new System.Drawing.Size(122, 16);
            this.lblBaudRates.TabIndex = 2;
            this.lblBaudRates.Text = "Specify baud rates:";
            // 
            // txtboxNewBaudrate
            // 
            this.txtboxNewBaudrate.Location = new System.Drawing.Point(21, 442);
            this.txtboxNewBaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxNewBaudrate.Name = "txtboxNewBaudrate";
            this.txtboxNewBaudrate.Size = new System.Drawing.Size(125, 22);
            this.txtboxNewBaudrate.TabIndex = 6;
            this.txtboxNewBaudrate.TextChanged += new System.EventHandler(this.txtboxNewBaudrate_TextChanged);
            this.txtboxNewBaudrate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtboxNewBaudrate_KeyDown);
            // 
            // btnDeleteBaudRate
            // 
            this.btnDeleteBaudRate.Enabled = false;
            this.btnDeleteBaudRate.Location = new System.Drawing.Point(21, 390);
            this.btnDeleteBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteBaudRate.Name = "btnDeleteBaudRate";
            this.btnDeleteBaudRate.Size = new System.Drawing.Size(125, 28);
            this.btnDeleteBaudRate.TabIndex = 7;
            this.btnDeleteBaudRate.Text = "Delete baud rate";
            this.btnDeleteBaudRate.UseVisualStyleBackColor = true;
            this.btnDeleteBaudRate.Click += new System.EventHandler(this.btnDeleteBaudRate_Click);
            // 
            // btnAddBaudRate
            // 
            this.btnAddBaudRate.Enabled = false;
            this.btnAddBaudRate.Location = new System.Drawing.Point(21, 472);
            this.btnAddBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBaudRate.Name = "btnAddBaudRate";
            this.btnAddBaudRate.Size = new System.Drawing.Size(125, 28);
            this.btnAddBaudRate.TabIndex = 7;
            this.btnAddBaudRate.Text = "Add baud rate";
            this.btnAddBaudRate.UseVisualStyleBackColor = true;
            this.btnAddBaudRate.Click += new System.EventHandler(this.btnAddBaudRate_Click);
            // 
            // lblNamePop
            // 
            this.lblNamePop.AutoSize = true;
            this.lblNamePop.Location = new System.Drawing.Point(189, 233);
            this.lblNamePop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNamePop.Name = "lblNamePop";
            this.lblNamePop.Size = new System.Drawing.Size(118, 16);
            this.lblNamePop.TabIndex = 8;
            this.lblNamePop.Text = "Max Length Name:";
            this.lblNamePop.Click += new System.EventHandler(this.lblNamePop_Click);
            // 
            // numericDeviceNameLength
            // 
            this.numericDeviceNameLength.Location = new System.Drawing.Point(192, 266);
            this.numericDeviceNameLength.Name = "numericDeviceNameLength";
            this.numericDeviceNameLength.Size = new System.Drawing.Size(125, 22);
            this.numericDeviceNameLength.TabIndex = 9;
            // 
            // chkNotifyOnConnect
            // 
            this.chkNotifyOnConnect.AutoSize = true;
            this.chkNotifyOnConnect.Checked = true;
            this.chkNotifyOnConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotifyOnConnect.Location = new System.Drawing.Point(192, 353);
            this.chkNotifyOnConnect.Name = "chkNotifyOnConnect";
            this.chkNotifyOnConnect.Size = new System.Drawing.Size(125, 20);
            this.chkNotifyOnConnect.TabIndex = 10;
            this.chkNotifyOnConnect.Text = "Notify on Plug-in";
            this.chkNotifyOnConnect.UseVisualStyleBackColor = true;
            // 
            // chkNotifyOnDisconnect
            // 
            this.chkNotifyOnDisconnect.AutoSize = true;
            this.chkNotifyOnDisconnect.Checked = true;
            this.chkNotifyOnDisconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotifyOnDisconnect.Location = new System.Drawing.Point(192, 379);
            this.chkNotifyOnDisconnect.Name = "chkNotifyOnDisconnect";
            this.chkNotifyOnDisconnect.Size = new System.Drawing.Size(133, 20);
            this.chkNotifyOnDisconnect.TabIndex = 11;
            this.chkNotifyOnDisconnect.Text = "Notify on Plug-out";
            this.chkNotifyOnDisconnect.UseVisualStyleBackColor = true;
            this.chkNotifyOnDisconnect.CheckedChanged += new System.EventHandler(this.chkNotifyOnDisconnect_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 322);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Activities:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 291);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "_________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 433);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "System:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "_________";
            // 
            // listShortcuts
            // 
            this.listShortcuts.FormattingEnabled = true;
            this.listShortcuts.ItemHeight = 16;
            this.listShortcuts.Location = new System.Drawing.Point(366, 266);
            this.listShortcuts.Margin = new System.Windows.Forms.Padding(4);
            this.listShortcuts.Name = "listShortcuts";
            this.listShortcuts.Size = new System.Drawing.Size(233, 100);
            this.listShortcuts.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Shortcut:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnAddShortcut
            // 
            this.btnAddShortcut.Location = new System.Drawing.Point(610, 265);
            this.btnAddShortcut.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddShortcut.Name = "btnAddShortcut";
            this.btnAddShortcut.Size = new System.Drawing.Size(70, 28);
            this.btnAddShortcut.TabIndex = 20;
            this.btnAddShortcut.Text = "Add...";
            this.btnAddShortcut.UseVisualStyleBackColor = true;
            // 
            // btnEditShortcut
            // 
            this.btnEditShortcut.Enabled = false;
            this.btnEditShortcut.Location = new System.Drawing.Point(610, 302);
            this.btnEditShortcut.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditShortcut.Name = "btnEditShortcut";
            this.btnEditShortcut.Size = new System.Drawing.Size(70, 28);
            this.btnEditShortcut.TabIndex = 21;
            this.btnEditShortcut.Text = "Edit";
            this.btnEditShortcut.UseVisualStyleBackColor = true;
            // 
            // btnDeleteShortcut
            // 
            this.btnDeleteShortcut.Enabled = false;
            this.btnDeleteShortcut.Location = new System.Drawing.Point(610, 339);
            this.btnDeleteShortcut.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteShortcut.Name = "btnDeleteShortcut";
            this.btnDeleteShortcut.Size = new System.Drawing.Size(70, 28);
            this.btnDeleteShortcut.TabIndex = 22;
            this.btnDeleteShortcut.Text = "Delete";
            this.btnDeleteShortcut.UseVisualStyleBackColor = true;
            this.btnDeleteShortcut.Click += new System.EventHandler(this.button1_Click);
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataSource = typeof(Cominator.Settings);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            this.dlgOpenFile.Filter = "Executable files (*.exe)|*.exe|Batch files (*.bat)|*.bat|All files (*.*)|*.*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(474, 374);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(423, 484);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "COM-INATOR Ver 1.0.0.a";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // chkLaunchOnStartup
            // 
            this.chkLaunchOnStartup.AutoSize = true;
            this.chkLaunchOnStartup.Location = new System.Drawing.Point(192, 464);
            this.chkLaunchOnStartup.Name = "chkLaunchOnStartup";
            this.chkLaunchOnStartup.Size = new System.Drawing.Size(142, 20);
            this.chkLaunchOnStartup.TabIndex = 25;
            this.chkLaunchOnStartup.Text = "Launch on Start-Up";
            this.chkLaunchOnStartup.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 576);
            this.Controls.Add(this.chkLaunchOnStartup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDeleteShortcut);
            this.Controls.Add(this.btnEditShortcut);
            this.Controls.Add(this.btnAddShortcut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listShortcuts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkNotifyOnDisconnect);
            this.Controls.Add(this.chkNotifyOnConnect);
            this.Controls.Add(this.numericDeviceNameLength);
            this.Controls.Add(this.lblNamePop);
            this.Controls.Add(this.btnAddBaudRate);
            this.Controls.Add(this.btnDeleteBaudRate);
            this.Controls.Add(this.txtboxNewBaudrate);
            this.Controls.Add(this.listBaudRates);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtboxSample);
            this.Controls.Add(this.txtboxArgs);
            this.Controls.Add(this.txtboxExe);
            this.Controls.Add(this.lblBaudRates);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.lblArgs);
            this.Controls.Add(this.lblExe);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericDeviceNameLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExe;
        private System.Windows.Forms.TextBox txtboxExe;
        private System.Windows.Forms.OpenFileDialog dlgBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtboxArgs;
        private System.Windows.Forms.Label lblArgs;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.TextBox txtboxSample;
        private System.Windows.Forms.ListBox listBaudRates;
        private System.Windows.Forms.Label lblBaudRates;
        private System.Windows.Forms.TextBox txtboxNewBaudrate;
        private System.Windows.Forms.Button btnDeleteBaudRate;
        private System.Windows.Forms.Button btnAddBaudRate;
        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.Label lblNamePop;
        private System.Windows.Forms.NumericUpDown numericDeviceNameLength;
        private System.Windows.Forms.CheckBox chkNotifyOnConnect;
        private System.Windows.Forms.CheckBox chkNotifyOnDisconnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listShortcuts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddShortcut;
        private System.Windows.Forms.Button btnEditShortcut;
        private System.Windows.Forms.Button btnDeleteShortcut;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkLaunchOnStartup;
    }
}