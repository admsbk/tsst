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
        public string[] forwardMessage(string message)
        {
<<<<<<< HEAD
            try
=======
            /*
            string[] tempMessage = message.Split('%'); //tempMessage[0] - od kogo, tempMessage[1] - na jaki port przyszło & wiadomość
            string[] tempMessage2 = tempMessage[1].Split('&');
            string tempPort=tempMessage2[0];
            string lastSlot = "";

            if (message.Contains("^"))
            {
                string[] slot = message.Split('^');
                lastSlot = slot[1];
            }


            if (SwitchingTable.ContainsKey(tempPort + "." + lastSlot))
>>>>>>> 10ae7036948c3f9ffb9df1f3a03fce21780a3fac
            {
                string dstPort;
                string toReturn;
                string[] tempMessage = message.Split('%'); //od kogo + pdu
                string[] tempMessage2 = tempMessage[1].Split('&'); // port + dane
                if(tempMessage[0].Contains("C"))
                    dstPort = (SwitchingTable[tempMessage2[0]+"."]);
                else
                    dstPort = SwitchingTable[tempMessage2[0]];
                string[] dstPortTemp = dstPort.Split('.');
                toReturn = dstPortTemp[0] + "^" + dstPortTemp[1] + "&" + tempMessage2[1];//dodanie payloadu po prostu
                return toReturn;
            }
            catch(Exception e)
            {
                return null;
            }*/
            string[] toReturn;
            string[] tempMessage = message.Split('%'); //od kogo + pdu
            string[] tempMessage2 = tempMessage[1].Split('&'); // port + stmka
            string[] stm = tempMessage2[1].Split(':'); //- poszczegolne szczeliny

            //dzielimy tylko takie ktore cos niosa
            if (stm.Length != 1)
            {
                

                string[] stmka = stm[1].Split('/');
                toReturn = new string[stmka.Length];
                int i = 0;
                string dstPort;

                if (tempMessage[0].Contains("Client"))
                {
                    foreach (string slot in stmka)
                    {
                        if (stmka[i] != "")
                        { stmka[i] = VirtualContainer3.pack(slot, "MSOH", "RSOH"); }
                        i++;
                    }

                }

                i = 0;
                foreach (string slot in stmka)
                {
                    if (stmka[i] != "")
                    {

                        if (tempMessage2[0].Contains("CI"))
                        {
                            dstPort = (SwitchingTable[tempMessage2[0] + "."]);
                            string[] dstPortTemp = dstPort.Split('.');
                            string dstMessage = dstPortTemp[0];
                            dstMessage += "&" + dstPortTemp[1] + "^" + stmka[0];//dodanie payloadu po prostu
                            //dstPort&dstSlot^slot 1 z stm
                            toReturn[i] = dstMessage;
                        }
                        else if (tempMessage2[0].Contains("CO"))
                        {
                            dstPort = (SwitchingTable[tempMessage2[0] + "." + i]);
                            string[] dstPortTemp = dstPort.Split('.');
                            string dstMessage = dstPortTemp[0];
                            dstMessage += "&" + "^" + stmka[1];//dodanie payloadu po prostu
                            //dstPort&dstSlot^slot 1 z stm
                            toReturn[i] = dstMessage;
                        }
                        else
                        {
                            dstPort = (SwitchingTable[tempMessage2[0] + "." + i]);
                            string[] dstPortTemp = dstPort.Split('.');
                            string dstMessage = dstPortTemp[0];
                            dstMessage += "&" + dstPortTemp[1] + "^" + stmka[1];//dodanie payloadu po prostu
                            //dstPort&dstSlot^slot 1 z stm
                            toReturn[i] = dstMessage;
                        }


                    }
                    i++;




                }
            }

            else
            {
                string dstPort;
                string[] stmka = stm[0].Split('/');
                toReturn = new string[stmka.Length];
                int i = 0;
                foreach (string slot in stmka)
                {
                    dstPort = (SwitchingTable[tempMessage2[0] + "."]);
                    string[] dstPortTemp = dstPort.Split('.');
                    string dstMessage = dstPortTemp[0];
                    dstMessage += "&" + dstPortTemp[1] + "^" + stmka[0];//dodanie payloadu po prostu
                    //dstPort&dstSlot^slot 1 z stm
                    toReturn[i] = dstMessage;
                    i++;
                }


            }

<<<<<<< HEAD
=======
            return toReturn;

>>>>>>> 10ae7036948c3f9ffb9df1f3a03fce21780a3fac
        }

        //szablon: src - "OD_KOGO%PORT"    dst - "DO_KOGO%PORT"
        public bool addLink(string src, string srcSlot, string dst, string dstSlot)
        {
            string tempInPort = src + "." + srcSlot;
            string tempOutPort = dst + "." + dstSlot;

            if (!SwitchingTable.ContainsKey(tempInPort))
            {
                this.SwitchingTable.Add(tempInPort, tempOutPort);
                return true;
            }
            else
            {
                return false;
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
