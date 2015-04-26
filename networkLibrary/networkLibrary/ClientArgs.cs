using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace networkLibrary
{
    public class ClientArgs : EventArgs
    {
        private string SrcPort;
        private string Message;
        private string Source;
        private string DstPort;
        private TcpClient client;

        public ClientArgs()
        {

        }

        public string srcPort
        {
            get { return SrcPort; }
            set { SrcPort = value; }
        }

        public string dstPort
        {
            get { return DstPort; }
            set { DstPort = value; }
        }

        public string source
        {
            get { return Source; }
            set { Source = value; }
        }

        public string message
        {
            get {    return Message;      }
            set { Message = value; }

        }

        public TcpClient Client
        {
            get { return client; }
            set { client = value; }
        }
        
    }
}
