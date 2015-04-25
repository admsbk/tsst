using networkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientNode
{
    class Client
    {
        private transportClient client;

        public Client()
        {
            try
            {
                client = new transportClient("localhost", "3333");

            }

            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

    }
}
