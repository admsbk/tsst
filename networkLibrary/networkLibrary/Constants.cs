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
        public const string NEW_MSG_RECIVED = "New message recived";
        public const string CONFIG_OK = "Configuration loaded correctly";
        public const string CONFIG_ERROR = "Configuration loaded incorrectly";
        public const string SERVICE_START_OK = "Service started correctly";
        public const string SERVICE_START_ERROR = "Service started incorrectly";
        public const string CANNOT_CONNECT_TO_CLOUD = "Cannot connect to cloud";
        public const string CANNOT_CONNECT_TO_MANAGER = "Cannot connect to Network Manager";


        public const int LOG_ERROR = 0;
        public const int LOG_INFO = 1;

        public const int LEFT = 0;
        public const int RIGHT = 1;

        //constants used in loading configuration from xml file
        public const string ID = "Id";
        public const string CLOUD_IP = "CloudHost";
        public const string CLOUD_PORT = "CloudPort";
        public const string MANAGER_IP = "ManagerHost";
        public const string MANAGER_PORT = "ManagerPort";
        public const string SRC_ID = "SrcId";
        public const string DST_ID = "DstId";
        public const string SRC_PORT_ID = "SrcPortId";
        public const string DST_PORT_ID = "DstPortId";
        public const string INPUT_PORT = "//InputPorts/Port";
        public const string OUTPUT_PORT = "//OutputPorts/Port";


        //elementType - to read config from xml
        public const string node = "//Node[@Id]";
        public const string Cloud = "//Cloud[@Id]";
        public const string Link = "//Link[@Id]";
        public const string Client = "//Client[@Id]";

        //handle messages
        public const string RECIVED_FROM_MANAGER = "Recived from Network Manager:";
        public const string FORWARD_MESSAGE = "Forwarding following message:";
        public const string INVALID_PORT = "No such port in Forward Table";

        //msgs from Network Manager
        public const string SET_LINK = "SET";
        public const string DELETE_LINK = "DELETE";
        public const string SHOW_LINK = "SHOW";
        //proponuje wiadomosci typu :
        //KOMU$SET%JAKI_PORT&NA_KTORY_PORT
        //KOMU$DELETE%JAKI_PORT i DELETE%* - usunie wszystko
        //KOMU$SHOW%JAKI_PORT i SHOW%* - pokaze wszystko
    }
}
