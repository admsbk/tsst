using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using networkLibrary;
using System.Xml;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace NetworkNode
{
    class Node
    {
        private Grid logs;
        private int messageNumber = 0;
        private int rIndex;
        private transportClient cloud;

        string ManagerIP { get; set; }
        string ManagerPort { get; set; }
        string CloudIP { get; set; }
        string CloudPort { get; set; }
        string NodeId { get; set; }



        public Node(Grid logs)
        {
            this.logs = logs;
            rIndex = Grid.GetRow(logs);
           

        }

        private void newMessageRecived(object myObject, MessageArgs myArgs)
        {
            addLog(logs, "Yout are: "+myArgs.Message, Constants.LOG_INFO);
        }

        public void readConfig(string path)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(path);
                foreach (XmlNode xnode in xml.SelectNodes("//Node[@Id]"))
                {
                    Console.WriteLine("Dupa");
                    NodeId = xnode.Attributes[Constants.ID].Value;
                    CloudIP = xnode.Attributes[Constants.CLOUD_IP].Value;
                    CloudPort = xnode.Attributes[Constants.CLOUD_PORT].Value;
                    ManagerIP = xnode.Attributes[Constants.MANAGER_IP].Value;
                    ManagerPort = xnode.Attributes[Constants.MANAGER_PORT].Value;
                }
                addLog(logs, networkLibrary.Constants.CONFIG_OK, networkLibrary.Constants.LOG_INFO);
            }
            catch
            {
                addLog(logs, networkLibrary.Constants.CONFIG_ERROR, networkLibrary.Constants.LOG_INFO);
            }
        }

        public void startService()
        {
            Console.WriteLine(CloudIP);
            try
            {
                cloud = new transportClient(CloudIP, CloudPort);
                cloud.OnNewMessageRecived += new transportClient.NewMsgHandler(newMessageRecived);
                addLog(logs, Constants.SERVICE_START_OK, Constants.LOG_INFO);
            }
            catch
            {
                addLog(logs, Constants.SERVICE_START_ERROR, Constants.LOG_ERROR);
            }
        }

        private void addLog(Grid log, string message, int logType)
        {
            var color = Brushes.Black;

            switch(logType){
                case networkLibrary.Constants.LOG_ERROR:
                    color = Brushes.Red;
                    break;
                case networkLibrary.Constants.LOG_INFO:
                    color = Brushes.Blue;
                    break;
            }
            log.Dispatcher.Invoke(
                 System.Windows.Threading.DispatcherPriority.Normal,
                     new Action(() =>
                     {
                         var t = new TextBlock();
                         t.Text = ("[" + DateTime.Now.ToString("HH:mm:ss") + "]  " +
                             message + Environment.NewLine);
                         t.Foreground = color;
                         RowDefinition gridRow = new RowDefinition();
                         gridRow.Height = new GridLength(15);
                         log.RowDefinitions.Add(gridRow);
                         Grid.SetRow(t, messageNumber);
                         messageNumber++;
                         log.Children.Add(t);

                     })
                 );
        }
    }
}
