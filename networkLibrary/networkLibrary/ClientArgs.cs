using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkLibrary
{
    public class ClientArgs : EventArgs
    {

        public ClientArgs()
        {

        }

        public string srcPort
        {
            get { return srcPort; }
            set { srcPort = value; }
        }

        public string dstPort
        {
            get { return dstPort; }
            set { dstPort = value; }
        }

        public string source
        {
            get { return source; }
            set { source = value; }
        }

        public string message
        {
            get {    return message;      }
            set { message = value; }

        }
        
    }
}
