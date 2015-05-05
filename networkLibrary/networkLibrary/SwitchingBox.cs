using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkLibrary
{
    public class SwitchingBox
    {
        //Wpisy w słowniku: "KTO_PRZYSLAL%NA_KTORY_PORT", "KOMU_WYSLAC%NA_KTORY_PORT"
        private Dictionary<string, string> SwitchingTable;
        public SwitchingBox()
        {
            SwitchingTable = new Dictionary<string, string>();
        }

        //WZÓR WIADOMOSCI: "KTO_PRZYSLAL%Z_KTOREGO_PORTU&cos_tam_dalej"
        //ZWRACA: "KOMU%NA_KTORY_PORT&cos_tam_dalej"           ale w cos_tam_dalej trzeba dać inne delimetery niż & i %
        public string forwardMessage(string message)
        {
            string[] tempMessage = new string[2];
            tempMessage = message.Split('&');

            if (SwitchingTable.ContainsKey(tempMessage[0]))
            {
                string dstMessage = SwitchingTable[tempMessage[0]];
                dstMessage += tempMessage[1];
                return dstMessage;
            }
            else
            {
                return null;
            }
        }

        public void addLink(string src, string dst)
        {
            if (!SwitchingTable.ContainsKey(src))
            {
                this.SwitchingTable.Add(src, dst);
            }
        }

        public void removeLink(string src)
        {
            this.SwitchingTable.Remove(src);
        }

        public void removeAllLinks()
        {
            foreach (KeyValuePair<string, string> entry in this.SwitchingTable)
            {
                this.SwitchingTable.Remove(entry.Key);
            }
        }
    }
}
