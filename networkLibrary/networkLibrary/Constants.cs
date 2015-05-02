using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkLibrary
{
    public class Constants
    {
        public const string NEW_CLIENT_LOG = "New client conneted";
        public const string CONFIG_OK = "Configuration loaded correctly";
        public const string CONFIG_ERROR = "Configuration loaded incorrectly";
        public const string SERVICE_START_OK = "Service started correctly";
        public const string SERVICE_START_ERROR = "Service started incorrectly";
        public const int LOG_ERROR = 0;
        public const int LOG_INFO = 1;

        //constants used in loading configuration from xml file
        public const string ID = "Id";
        public const string CLOUD_IP = "CloudHost";
        public const string CLOUD_PORT = "CloudPort";
        public const string MANAGER_IP = "ManagerHost";
        public const string MANAGER_PORT = "ManagerPort";
        public const string INPUT_PORT_NODE = "//InputPorts/Port";
        public const string OUTPUT_PORT_NODE = "//OutputPorts/Port";
    }
}
