using System.Linq;
using System.Management;
using System.Collections.Generic;
using System.IO.Ports;
using System;

namespace shared
{
    public class WMIException: System.Exception
    {
        public WMIException()
        { }

        public WMIException(string message)
            : base(message)
        { }

        public WMIException(string message, System.Exception inner)
            : base(message, inner)
        { }

    }

    public struct SerialPortDescriptor
    {
        public SerialPortDescriptor(string address, string description, DateTime? connectedTime = null)
        {
            Address = address;
            Description = description;
            ConnectedTime = connectedTime;
        }

        public string Address;
        public string Description;
        public DateTime? ConnectedTime;
    }


    public class Serial
    {
        public static IOrderedEnumerable<SerialPortDescriptor> GetSortedSerialPortNames()
        {
            List<string> portDescriptions = new List<string>();

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT Caption FROM Win32_PnPEntity where ConfigManagerErrorCode = 0 and PNPClass=\"Ports\"");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    portDescriptions.Add((string)queryObj["Caption"]);
                }
            }
            catch (ManagementException e)
            {
                throw new WMIException("ERROR while querying WMI: " + e.Message);
            }

            IEnumerable<string> comAddresses = SerialPort.GetPortNames();

            List<SerialPortDescriptor> portNamesAndDescriptions = new List<SerialPortDescriptor>();

            foreach (string comAddress in comAddresses)
            {
                bool found = false;

                foreach (string portDescription in portDescriptions)
                {
                    if (portDescription.IndexOf(comAddress, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        found = true;
                        portNamesAndDescriptions.Add(new SerialPortDescriptor(comAddress, portDescription));
                        portDescriptions.Remove(portDescription);
                        break;
                    }
                }

                if (!found)
                {
                    portNamesAndDescriptions.Add(new SerialPortDescriptor(comAddress, comAddress));
                }
            }

            foreach (string portDescription in portDescriptions)
            {
                portNamesAndDescriptions.Add(new SerialPortDescriptor(null, portDescription));
            }

            return portNamesAndDescriptions.OrderBy(t => t.Address);

        }
    }
}
