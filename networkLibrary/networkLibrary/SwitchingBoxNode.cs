using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkLibrary
{
    public class SwitchingBoxNode
    {
        //Wpisy w słowniku: "KTO_PRZYSLAL%NA_KTORY_PORT", "KOMU_WYSLAC%NA_KTORY_PORT"
        private Dictionary<string, string> SwitchingTable;
        public SwitchingBoxNode()
        {
            SwitchingTable = new Dictionary<string, string>();
        }

        //WZÓR WIADOMOSCI: "KTO_PRZYSLAL%Z_KTOREGO_PORTU&cos_tam_dalej" 
        //

        //ZWRACA: "KOMU%NA_KTORY_PORT&cos_tam_dalej"           ale w cos_tam_dalej trzeba dać inne delimetery niż & i %
        public string forwardMessage(string message)
        {
            string[] tempMessage = new string[2];
            tempMessage = message.Split('%');

            if (SwitchingTable.ContainsKey(tempMessage[1]))
            {
                string dstPort = (SwitchingTable[tempMessage[1]]);
                dstPort.Split('.');
                string dstMessage = dstPort[0] + "." + dstPort[1];
                dstMessage += "&" + tempMessage[1];//dodanie payloadu po prostu
                return dstMessage;
            }
            else
            {
                return null;
            }
        }

        //szablon: src - "OD_KOGO%PORT"    dst - "DO_KOGO%PORT"
        public void addLink(string src, string srcSlot, string dst, string dstSlot)
        {
            string tempInPort = src + "." + srcSlot;
            string tempOutPort = dst + "." + dstSlot;

            if (!SwitchingTable.ContainsKey(tempInPort))
            {
                this.SwitchingTable.Add(tempInPort, tempOutPort);
            }
        }

        public void removeLink(string src, string srcSlot)
        {
            string tempInPort = src+"."+srcSlot;
            this.SwitchingTable.Remove(tempInPort);
        }

        public void removeAllLinks()
        {

            this.SwitchingTable.Clear();
        }
    }
}
