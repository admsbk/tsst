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

        public Link(string id, string src, string dst)
        {
            this.ID = id;
            this.src = src;
            this.dst = dst;
        }
    }
}
