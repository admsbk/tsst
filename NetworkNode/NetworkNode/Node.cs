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
        private Config conf;
        private int messageNumber = 0;
        private int rIndex;
        private transportClient cloud;

        
        string ManagerIP { get; set; }
        string ManagerPort { get; set; }
        string CloudIP { get; set; }
        string CloudPort { get; set; }
        string NodeId { get; set; }
        public List<string> portsIn { get; set; }
        public List<string> portsOut { get; set; }

        public Node(Grid logs)
        {
            this.logs = logs;
            rIndex = Grid.GetRow(logs);
        }
        private void newMessageRecived(object myObject, MessageArgs myArgs)
        {
            //tutaj coś by trzeba wykminić
            addLog(logs, "Yout are: "+myArgs.Message, Constants.LOG_INFO);
        }

        public void readConfig(string pathToConfig)
        {
            try
            {
                conf = new Config(pathToConfig, Constants.node);
                this.NodeId = conf.config[0];
                this.CloudIP = conf.config[1];
                this.CloudPort = conf.config[2];
                this.ManagerIP = conf.config[3];
                this.ManagerPort = conf.config[4];
                this.portsIn = conf.portsIn;
                this.portsOut = conf.portsOut;
                addLog(logs, networkLibrary.Constants.CONFIG_OK, networkLibrary.Constants.LOG_INFO);
            }
            catch
            {
                addLog(logs, networkLibrary.Constants.CONFIG_ERROR, networkLibrary.Constants.LOG_INFO);
            }
        }

        public void startService()
        {
            try
            {
                cloud = new transportClient(CloudIP, CloudPort);
                cloud.OnNewMessageRecived += new transportClient.NewMsgHandler(newMessageRecived);
                if (cloud.isConnected())
                {
                    addLog(logs, Constants.SERVICE_START_OK, Constants.LOG_INFO);
                }
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
