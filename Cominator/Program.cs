using System;
using System.Windows.Forms;
using System.Linq;
using shared;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Management;

namespace Cominator
{
    static class Program
    {
        static ConfigurationStruct currentConfiguration = Configuration.DefaultConfiguration;
        static bool configurationOutOfSync = false;
        static Action<string, string, ToolTipIcon> displayPopUp = null;
        static NotifyIcon notifyIcon;
        static ManagementEventWatcher deviceWatcher;
        static bool isInitialRun = true;
        static Settings settingsInstance = null;

        public static string FormatDiff(IOrderedEnumerable<SerialPortDescriptor> old_pairs,
                                        IOrderedEnumerable<SerialPortDescriptor> newer_pairs,
                                        out string title)
        {
            StringBuilder sb = new StringBuilder();
            var safeOld = old_pairs ?? new List<SerialPortDescriptor>().OrderBy(t => t.Address);
            var safeNew = newer_pairs ?? new List<SerialPortDescriptor>().OrderBy(t => t.Address);

            var removed = safeOld.Where(op => op.Address != null && !safeNew.Any(np => np.Address == op.Address)).ToList();
            var added = safeNew.Where(np => np.Address != null && !safeOld.Any(op => op.Address == np.Address)).ToList();

            if (added.Count > 0 && removed.Count > 0)
            {
                title = "Ports Plugged in / Plugged out";
            }
            else if (added.Count > 0)
            {
                title = "Port Plugged in";
            }
            else if (removed.Count > 0)
            {
                title = "Port Plugged out";
            }
            else
            {
                title = "Serial ports changed";
            }

            foreach (var s in removed)
            {
                sb.AppendFormat("❌ {0}\n", s.Description ?? "Unknown Device");
            }
            foreach (var s in added)
            {
                sb.AppendFormat("✅ {0}\n", s.Description ?? "Unknown Device");
            }

            return sb.ToString();
        }

        static void InvokeExecutable(string comPort, string baudRate)
        {
            Debug.Assert(int.TryParse(baudRate, out _));
            try
            {
                string arguments = currentConfiguration.Arguments.Replace(
                    Configuration.COM_PORT_PATTERN, comPort).Replace(
                    Configuration.BAUD_RATE_PATTERN, baudRate);
                Process.Start(currentConfiguration.ExecutablePath, arguments);
            }
            catch (Exception e)
            {
                displayPopUp("Cominator execution ERROR:", e.Message, ToolTipIcon.Error);
            }
        }

        static void UpdateContextMenu(ContextMenuStrip strip, IOrderedEnumerable<SerialPortDescriptor> newerPorts)
        {
            strip.Close();
            strip.Items.Clear();

            string baudRateSuffix = "";
            if (currentConfiguration.BaudRates.Count == 1)
            {
                baudRateSuffix = String.Format(" [{0}]", currentConfiguration.BaudRates[0]);
            }

            foreach (SerialPortDescriptor newPort in newerPorts)
            {
                int maxDeviceNameLength = currentConfiguration.MaxDeviceNameLength;
                string description = newPort.Description ?? "Unknown Device";
                string deviceName = description.Length > maxDeviceNameLength
                    ? description.Substring(0, Math.Min(maxDeviceNameLength, description.Length)) + "..."
                    : description;
                string timestamp = newPort.ConnectedTime.HasValue
                    ? newPort.ConnectedTime.Value.ToString("[HH:mm:ss]")
                    : "[--:--:--]";

                ToolStripMenuItem portEntry = new ToolStripMenuItem
                {
                    AutoToolTip = false,
                    Text = $"{timestamp} ({newPort.Address}) {deviceName}{baudRateSuffix}",
                    Image = Properties.Resources.usb,
                    Tag = newPort.Address
                };

                if (newPort.Address == null)
                {
                    portEntry.Enabled = false;
                }
                else
                {
                    if (currentConfiguration.BaudRates.Count == 1)
                    {
                        portEntry.Click += PortEntry_Click;
                    }
                    else
                    {
                        foreach (int baudRate in currentConfiguration.BaudRates)
                        {
                            ToolStripMenuItem baudRateItem = new ToolStripMenuItem
                            {
                                AutoToolTip = false,
                                Text = baudRate.ToString(),
                                Image = Properties.Resources.speedometer,
                                Tag = newPort.Address
                            };
                            baudRateItem.Click += BaudRateItem_Click;
                            portEntry.DropDownItems.Add(baudRateItem);
                        }
                    }
                }

                strip.Items.Add(portEntry);
            }

            strip.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem shortcutMenu = new ToolStripMenuItem
            {
                AutoToolTip = false,
                Text = "Shortcut",
                Image = Properties.Resources.shortcut
            };
            foreach (var shortcut in currentConfiguration.Shortcuts)
            {
                ToolStripMenuItem shortcutItem = new ToolStripMenuItem
                {
                    AutoToolTip = false,
                    Text = shortcut.Name,
                    Tag = shortcut.ExecutablePath,
                    Image = Properties.Resources.go
                };
                shortcutItem.Click += ShortcutItem_Click;
                shortcutMenu.DropDownItems.Add(shortcutItem);
            }
            strip.Items.Add(shortcutMenu);

            ToolStripMenuItem settingsButton = new ToolStripMenuItem
            {
                AutoToolTip = false,
                Text = "Settings",
                Image = Properties.Resources.coding
            };
            settingsButton.Click += SettingsButton_Click;
            strip.Items.Add(settingsButton);

            ToolStripMenuItem restartButton = new ToolStripMenuItem
            {
                AutoToolTip = false,
                Text = "Restart",
                Image = Properties.Resources.refresh
            };
            restartButton.Click += RestartButton_Click;
            strip.Items.Add(restartButton);

            ToolStripMenuItem quitButton = new ToolStripMenuItem
            {
                AutoToolTip = false,
                Text = "Quit",
                Image = Properties.Resources.quit
            };
            quitButton.Click += QuitButton_Click;
            strip.Items.Add(quitButton);
        }

        private static void ShortcutItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string executablePath = (string)item.Tag;
            try
            {
                Process.Start(executablePath);
            }
            catch (Exception ex)
            {
                displayPopUp("Shortcut Error:", $"Failed to launch {item.Text}: {ex.Message}", ToolTipIcon.Error);
            }
        }

        private static void BaudRateItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem baudRateEntry = (ToolStripMenuItem)sender;
            InvokeExecutable((string)baudRateEntry.Tag, baudRateEntry.Text);
        }

        private static void PortEntry_Click(object sender, EventArgs e)
        {
            Debug.Assert(currentConfiguration.BaudRates.Count == 1);
            ToolStripMenuItem portEntry = (ToolStripMenuItem)sender;
            InvokeExecutable((string)portEntry.Tag, currentConfiguration.BaudRates[0].ToString());
        }

        private static void SettingsButton_Click(object sender, EventArgs e)
        {
            lock (typeof(Program))
            {
                if (settingsInstance != null && !settingsInstance.IsDisposed)
                {
                    settingsInstance.BringToFront();
                    settingsInstance.Focus();
                }
                else
                {
                    settingsInstance = new Settings(currentConfiguration);
                    DialogResult result = settingsInstance.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        currentConfiguration = settingsInstance.currentConfiguration;
                        configurationOutOfSync = true;
                        try
                        {
                            Configuration.Serialize(Configuration.GetDefaultPath(), currentConfiguration);
                            RefreshPorts();
                        }
                        catch (Exception ex)
                        {
                            displayPopUp("Cominator configuration ERROR:", ex.Message, ToolTipIcon.Error);
                        }
                    }
                    settingsInstance = null;
                }
            }
        }

        private static void RestartButton_Click(object sender, EventArgs e)
        {
            try
            {
                string exePath = Application.ExecutablePath;

                Process.Start(exePath);

                QuitButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                displayPopUp("Restart Error:", $"Failed to restart application: {ex.Message}", ToolTipIcon.Error);
            }
        }
        private static void QuitButton_Click(object sender, EventArgs e)
        {
            if (deviceWatcher != null)
            {
                deviceWatcher.Stop();
                deviceWatcher.Dispose();
            }
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            if (settingsInstance != null && !settingsInstance.IsDisposed)
            {
                settingsInstance.Close();
            }
            Application.Exit();
        }

        static void InvokeUpdateContextMenu(IOrderedEnumerable<SerialPortDescriptor> newerPorts)
        {
            try
            {
                if (notifyIcon == null || notifyIcon.ContextMenuStrip == null)
                {
                    Debug.WriteLine("NotifyIcon or ContextMenuStrip is null in InvokeUpdateContextMenu");
                    return;
                }
                if (notifyIcon.ContextMenuStrip.InvokeRequired)
                {
                    notifyIcon.ContextMenuStrip.Invoke((MethodInvoker)delegate
                    {
                        UpdateContextMenu(notifyIcon.ContextMenuStrip, newerPorts);
                    });
                }
                else
                {
                    UpdateContextMenu(notifyIcon.ContextMenuStrip, newerPorts);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in InvokeUpdateContextMenu: {ex.Message}");
            }
        }

        static void LoadConfiguration()
        {
            try
            {
                if (!File.Exists(Configuration.GetDefaultPath()))
                {
                    currentConfiguration = Configuration.DefaultConfiguration;
                    Configuration.Serialize(Configuration.GetDefaultPath(), Configuration.DefaultConfiguration);
                }
                else
                {
                    currentConfiguration = Configuration.Deserialize(Configuration.GetDefaultPath());
                }
            }
            catch (Exception e)
            {
                displayPopUp("Cominator configuration ERROR:", e.Message, ToolTipIcon.Error);
            }

            if ((currentConfiguration.BaudRates.Count == 0) || (currentConfiguration.ExecutablePath.Length == 0))
            {
                displayPopUp("Cominator configuration ERROR:", "The configuration appears invalid, using default configuration instead", ToolTipIcon.Error);
                currentConfiguration = Configuration.DefaultConfiguration;
            }
        }

        static void RefreshPorts()
        {
            try
            {
                var newerPorts = Serial.GetSortedSerialPortNames();
                if (newerPorts == null)
                {
                    displayPopUp("Cominator ERROR:", "Failed to retrieve serial ports.", ToolTipIcon.Error);
                    InvokeUpdateContextMenu(new List<SerialPortDescriptor>().OrderBy(t => t.Address));
                    return;
                }

                var olderPorts = (currentConfiguration.LastKnownPorts ?? new List<SerialPortDescriptor>()).OrderBy(t => t.Address ?? string.Empty);

                var newerPortsList = new List<SerialPortDescriptor>();
                foreach (var port in newerPorts)
                {
                    var existingPort = olderPorts.FirstOrDefault(p => p.Address == port.Address);
                    if (existingPort.Address != null)
                    {
                        newerPortsList.Add(new SerialPortDescriptor(port.Address, port.Description, existingPort.ConnectedTime));
                    }
                    else
                    {
                        newerPortsList.Add(new SerialPortDescriptor(port.Address, port.Description, DateTime.Now));
                    }
                }
                newerPorts = newerPortsList.OrderBy(t => t.Address ?? string.Empty);

                if (!Enumerable.SequenceEqual(olderPorts, newerPorts))
                {
                    InvokeUpdateContextMenu(newerPorts);

                    bool hasNewDevices = newerPorts.Any(np => np.Address != null && !olderPorts.Any(op => op.Address == np.Address));
                    bool hasRemovedDevices = olderPorts.Any(op => op.Address != null && !newerPorts.Any(np => np.Address == op.Address));

                    if (!isInitialRun &&
                        ((currentConfiguration.NotifyOnConnect && hasNewDevices) ||
                         (currentConfiguration.NotifyOnDisconnect && hasRemovedDevices)))
                    {
                        var diff = FormatDiff(olderPorts, newerPorts, out string title);
                        if (!string.IsNullOrEmpty(diff))
                        {
                            displayPopUp(title, diff, ToolTipIcon.Info);
                        }
                    }

                    currentConfiguration.LastKnownPorts = newerPorts.ToList();
                }

                if (configurationOutOfSync)
                {
                    lock (typeof(Program))
                    {
                        configurationOutOfSync = false;
                        InvokeUpdateContextMenu(newerPorts);
                    }
                }
                isInitialRun = false;
            }
            catch (Exception ex)
            {
                displayPopUp("Cominator ERROR:", $"Failed to refresh ports: {ex.Message}", ToolTipIcon.Error);
                InvokeUpdateContextMenu(new List<SerialPortDescriptor>().OrderBy(t => t.Address));
                isInitialRun = false;
            }
        }

        static void StartDeviceWatcher()
        {
            WqlEventQuery query = new WqlEventQuery(
                "SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_SerialPort' OR TargetInstance ISA 'Win32_USBControllerDevice'");
            deviceWatcher = new ManagementEventWatcher(query);
            deviceWatcher.EventArrived += (sender, e) =>
            {
                RefreshPorts();
            };
            deviceWatcher.Start();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var applicationContext = new CustomApplicationContext2();
                notifyIcon = applicationContext.notifyIcon;
                displayPopUp = applicationContext.displayPopUp;

                LoadConfiguration();
                InvokeUpdateContextMenu(new List<SerialPortDescriptor>().OrderBy(t => t.Address));
                RefreshPorts();
                StartDeviceWatcher();

                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup failed: {ex.Message}", "Cominator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CustomApplicationContext2 : ApplicationContext
    {
        public NotifyIcon notifyIcon;
        public Action<string, string, ToolTipIcon> displayPopUp;

        public CustomApplicationContext2()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.pendrive,
                Text = "Cominator",
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };

            notifyIcon.Visible = false;
            notifyIcon.Visible = true;

            displayPopUp = (title, text, iconType) =>
            {
                try
                {
                    if (notifyIcon != null && notifyIcon.Visible)
                    {
                        notifyIcon.ShowBalloonTip(5000, title, text, iconType);
                    }
                    else
                    {
                        Debug.WriteLine("NotifyIcon is not visible or null");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error in displayPopUp: {ex.Message}");
                }
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}