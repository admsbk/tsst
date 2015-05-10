using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkNode
{

    class Link
    {
        public string ID { get; set; }
        public string src { get; set; }
        public string dst { get; set; }
        public string srcSlot { get; set; }
        public string dstSlot { get; set; }

        public Link(string id, string src, string dst)
        {
            this.ID = id;
            string[] source = src.Split('.');
            string[] destination = dst.Split('.');
            this.src = source[0];
            this.srcSlot = source[1];
            this.dst = destination[0];
            this.dstSlot = destination[1];
        }
    }
}
