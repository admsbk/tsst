using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkLibrary
{
    class VirtualContainer3
    {

        public static string pack(string message, string MSOH, string RSOH)
        {
            return MSOH + "$" + RSOH + "$" + message;
        }

        public static string[] unpack(string container)
        {
            return container.Split('$');
        } 
    }
}
