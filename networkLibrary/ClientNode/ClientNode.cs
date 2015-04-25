using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using networkLibrary;

namespace ClientNode
{
    public class ClientN
    {
        private transportClient client;

        public ClientN()
        {
            client = new transportClient("localhost", "3333");
        }
    }
}
