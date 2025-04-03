using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace shared
{
    public struct ShortcutEntry
    {
        public string Name;
        public string ExecutablePath;
    }

    public struct ConfigurationStruct
    {
        public string ExecutablePath;
        public string Arguments;
        public int MaxDeviceNameLength;
        public List<int> BaudRates;
        public bool NotifyOnConnect;
        public bool NotifyOnDisconnect;
        public bool LaunchOnStartup;
        public List<SerialPortDescriptor> LastKnownPorts;
        public List<ShortcutEntry> Shortcuts;
    }

    public class Configuration
    {
        public const string CONFIGURATION_FILE_NAME = "config.xml";

        public const string COM_PORT_PATTERN = "{COM}";
        public const string BAUD_RATE_PATTERN = "{BAUDRATE}";

        public const string DEFAULT_EXECUTABLE = "putty.exe";
        public const string DEFAULT_ARGUMENTS = "-serial " + COM_PORT_PATTERN + " -sercfg " + BAUD_RATE_PATTERN + ",8,n,1,N";
        public static readonly List<int> DEFAULT_BAUD_RATES = new List<int>() { 9600, 115200 };

        public static readonly ConfigurationStruct DefaultConfiguration = new ConfigurationStruct()
        {
            ExecutablePath = DEFAULT_EXECUTABLE,
            Arguments = DEFAULT_ARGUMENTS,
            MaxDeviceNameLength = 20,
            BaudRates = DEFAULT_BAUD_RATES,
            NotifyOnConnect = true,
            NotifyOnDisconnect = true,
            LaunchOnStartup = false
        };
        public static string GetDefaultPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CONFIGURATION_FILE_NAME);
        }
        public static ConfigurationStruct Deserialize(string configurationPath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ConfigurationStruct));
            using (var reader = new StreamReader(configurationPath))
            {
                return (ConfigurationStruct)ser.Deserialize(reader);
            }
        }
        public static void Serialize(string configurationPath, ConfigurationStruct configuration)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ConfigurationStruct));
            using (var writer = new StreamWriter(configurationPath))
            {
                ser.Serialize(writer, configuration);
            }
        }
    }
}
