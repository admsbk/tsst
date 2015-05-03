using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace networkLibrary
{
    public class Config
    {
        public List<string> config { get; set; }
        public List<string> portsIn { get; set; }
        public List<string> portsOut { get; set; }

        public Config(string path, string elementType)
        {
            config = new List<string>();
            portsIn = new List<string>();
            portsOut = new List<string>();
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            foreach (XmlNode xnode in xml.SelectNodes(elementType))
            {
                config.Add(xnode.Attributes[Constants.ID].Value);
                config.Add(xnode.Attributes[Constants.CLOUD_IP].Value);
                config.Add(xnode.Attributes[Constants.CLOUD_PORT].Value);
                config.Add(xnode.Attributes[Constants.MANAGER_IP].Value);
                config.Add(xnode.Attributes[Constants.MANAGER_PORT].Value);
                readPorts(xml, Constants.INPUT_PORT_NODE, portsIn);
                readPorts(xml, Constants.OUTPUT_PORT_NODE, portsOut);
            }
        }

        void readPorts(XmlDocument xml, string attribute, List<string> listToWrite)
        {
            foreach (XmlNode xnode in xml.SelectNodes(attribute))
            {
                string input = xnode.Attributes[Constants.ID].Value;
                listToWrite.Add(input);
            }
        }
    }
}
