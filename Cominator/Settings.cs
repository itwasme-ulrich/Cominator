using shared;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cominator
{
    public partial class Settings : Form
    {
        public ConfigurationStruct currentConfiguration;

        public Settings(ConfigurationStruct configuration)
        {
            InitializeComponent();
            currentConfiguration = configuration;

            pictureBox1.Image = Properties.Resources.logo; 
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            numericDeviceNameLength.Value = currentConfiguration.MaxDeviceNameLength;

            txtboxExe.Text = configuration.ExecutablePath;
            txtboxArgs.Text = configuration.Arguments;
            txtboxArgs_TextChanged(this, null);

            foreach (int baudRate in configuration.BaudRates)
            {
                listBaudRates.Items.Add(baudRate);
            }

            chkNotifyOnConnect.Checked = currentConfiguration.NotifyOnConnect;
            chkNotifyOnDisconnect.Checked = currentConfiguration.NotifyOnDisconnect;
            chkLaunchOnStartup.Checked = currentConfiguration.LaunchOnStartup;

            foreach (var shortcut in configuration.Shortcuts)
            {
                listShortcuts.Items.Add($"{shortcut.Name} ({shortcut.ExecutablePath})");
            }

            btnOK.Click += btnOK_Click;
            btnAddShortcut.Click += btnAddShortcut_Click;   
            btnEditShortcut.Click += btnEditShortcut_Click; 
            btnDeleteShortcut.Click += btnDeleteShortcut_Click;
            listShortcuts.SelectedIndexChanged += listShortcuts_SelectedIndexChanged;
        }

        private void numericDeviceNameLength_ValueChanged(object sender, EventArgs e)
        {
            currentConfiguration.MaxDeviceNameLength = (int)numericDeviceNameLength.Value;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgBrowse.InitialDirectory = Path.GetDirectoryName(txtboxExe.Text);

            if (dlgBrowse.ShowDialog() == DialogResult.OK)
            {
                currentConfiguration.ExecutablePath = txtboxExe.Text = dlgBrowse.FileName;
            }
        }

        private void txtboxArgs_TextChanged(object sender, EventArgs e)
        {
            currentConfiguration.Arguments = txtboxArgs.Text;
            txtboxSample.Text = txtboxArgs.Text.Replace(Configuration.COM_PORT_PATTERN, "COM1").Replace(Configuration.BAUD_RATE_PATTERN, "115200");
        }

        private void listBaudRates_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteBaudRate.Enabled = ((listBaudRates.SelectedIndices.Count > 0) && (listBaudRates.Items.Count > 1));
        }

        private void btnAddBaudRate_Click(object sender, EventArgs e)
        {
            int newBaudRate = 0;
            if (int.TryParse(txtboxNewBaudrate.Text, out newBaudRate) &&
                !currentConfiguration.BaudRates.Contains(newBaudRate))
            {
                currentConfiguration.BaudRates.Add(newBaudRate);
                listBaudRates.Items.Add(newBaudRate);
                listBaudRates.ClearSelected();
            }
        }

        private void btnDeleteBaudRate_Click(object sender, EventArgs e)
        {
            currentConfiguration.BaudRates.RemoveAt(listBaudRates.SelectedIndex);
            listBaudRates.Items.RemoveAt(listBaudRates.SelectedIndex);
            listBaudRates.ClearSelected();

            if (listBaudRates.Items.Count == 1)
            {
                btnDeleteBaudRate.Enabled = false;
            }
        }

        private void txtboxNewBaudrate_TextChanged(object sender, EventArgs e)
        {
            btnAddBaudRate.Enabled = int.TryParse(txtboxNewBaudrate.Text, out _);
        }

        private void txtboxNewBaudrate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddBaudRate_Click(this, new EventArgs());
            }
        }

        private void listBaudRates_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back))
            {
                btnDeleteBaudRate_Click(this, new EventArgs());
            }
        }

        private void txtboxExe_TextChanged(object sender, EventArgs e)
        {
            currentConfiguration.ExecutablePath = txtboxExe.Text;
        }

        private void lblNamePop_Click(object sender, EventArgs e)
        {

        }

        private void btnAddShortcut_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                string name = Path.GetFileNameWithoutExtension(dlgOpenFile.FileName);
                var shortcut = new ShortcutEntry { Name = name, ExecutablePath = dlgOpenFile.FileName };
                currentConfiguration.Shortcuts.Add(shortcut);
                listShortcuts.Items.Add($"{shortcut.Name} ({shortcut.ExecutablePath})");
            }
        }


        private void btnDeleteShortcut_Click(object sender, EventArgs e)
        {
            if (listShortcuts.SelectedIndex >= 0)
            {
                currentConfiguration.Shortcuts.RemoveAt(listShortcuts.SelectedIndex);
                listShortcuts.Items.RemoveAt(listShortcuts.SelectedIndex);
            }
        }

        private void btnEditShortcut_Click(object sender, EventArgs e)
        {
            if (listShortcuts.SelectedIndex >= 0)
            {
                var shortcut = currentConfiguration.Shortcuts[listShortcuts.SelectedIndex];
                string newName = PromptForName(shortcut.Name);
                if (!string.IsNullOrEmpty(newName))
                {
                    shortcut.Name = newName;
                    currentConfiguration.Shortcuts[listShortcuts.SelectedIndex] = shortcut;
                    listShortcuts.Items[listShortcuts.SelectedIndex] = $"{shortcut.Name} ({shortcut.ExecutablePath})";
                }
            }
        }

        private string PromptForName(string currentName)
        {
            using (Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = "Edit Shortcut Name",
                StartPosition = FormStartPosition.CenterParent
            })
            {
                Label label = new Label() { Left = 20, Top = 20, Text = "Enter new name:" };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240, Text = currentName };
                Button ok = new Button() { Text = "OK", Left = 160, Top = 80, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancel", Left = 240, Top = 80, DialogResult = DialogResult.Cancel };

                prompt.Controls.Add(label);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(ok);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = ok;
                prompt.CancelButton = cancel;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
        }

        private void listShortcuts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteShortcut.Enabled = btnEditShortcut.Enabled = (listShortcuts.SelectedIndex >= 0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            currentConfiguration.NotifyOnConnect = chkNotifyOnConnect.Checked;
            currentConfiguration.NotifyOnDisconnect = chkNotifyOnDisconnect.Checked;
            currentConfiguration.LaunchOnStartup = chkLaunchOnStartup.Checked;
            UpdateStartupRegistry(currentConfiguration.LaunchOnStartup);
            currentConfiguration.MaxDeviceNameLength = (int)numericDeviceNameLength.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void UpdateStartupRegistry(bool enable)
        {
            string appName = "Cominator";
            string appPath = Application.ExecutablePath;

            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (enable)
                {
                    registryKey.SetValue(appName, appPath);
                }
                else
                {
                    registryKey.DeleteValue(appName, false);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void chkNotifyOnDisconnect_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
