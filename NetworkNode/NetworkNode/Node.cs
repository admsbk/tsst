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
        private ListView links;
        private Config conf;

        private int messageNumber = 0;
        private int rIndex;
        private transportClient cloud;
        private transportClient manager;
        private SwitchingBox switchTable;

        private List<Link> linkList;
        
        string ManagerIP { get; set; }
        string ManagerPort { get; set; }
        string CloudIP { get; set; }
        string CloudPort { get; set; }
        string NodeId { get; set; }
        public List<string> portsIn { get; set; }
        public List<string> portsOut { get; set; }

        public Node(Grid logs, ListView links)
        {
            this.logs = logs;
            this.links = links;
            rIndex = Grid.GetRow(logs);
            switchTable = new SwitchingBox();
            linkList = new List<Link>();
        }

        private void newOrderRecived(object myObject, MessageArgs myArgs)
        {    
            string[] check = myArgs.Message.Split('%');
            if (check[0] == NodeId)
            {
                parseOrder(check[1]+"%"+check[2]+"%"+check[3]);
                addLog(logs, Constants.RECIVED_FROM_MANAGER + " " + myArgs.Message, Constants.LOG_INFO);
            }            
        }

        private void newMessageRecived(object myObject, MessageArgs myArgs)
        {
            //tutaj coś by trzeba wykminić
            //addLog(logs, "Yout are: "+myArgs.Message, Constants.LOG_INFO);
            string forwarded = switchTable.forwardMessage(myArgs.Message);
            if (forwarded != null) 
            { 
                cloud.sendMessage(forwarded);
                addLog(logs, Constants.FORWARD_MESSAGE + " " + forwarded, Constants.LOG_INFO);
            }
            else
            {
                addLog(logs, Constants.INVALID_PORT, Constants.LOG_ERROR);
            }
            
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
            catch(Exception e)
            {
                addLog(logs, networkLibrary.Constants.CONFIG_ERROR, networkLibrary.Constants.LOG_INFO);
                System.Console.WriteLine(e);
            }
        }

        public void startService()
        {
            try
            {
                cloud = new transportClient(CloudIP, CloudPort);
                cloud.OnNewMessageRecived += new transportClient.NewMsgHandler(newMessageRecived);

                manager = new transportClient(ManagerIP, ManagerPort);
                manager.OnNewMessageRecived += new transportClient.NewMsgHandler(newOrderRecived);

                cloud.sendMessage(this.NodeId+"#");

                addLog(logs, Constants.SERVICE_START_OK, Constants.LOG_INFO);
                
            }
            catch
            {
                addLog(logs, Constants.SERVICE_START_ERROR, Constants.LOG_ERROR);
                addLog(logs, Constants.CANNOT_CONNECT_TO_CLOUD, Constants.LOG_ERROR);
                addLog(logs, Constants.CANNOT_CONNECT_TO_MANAGER, Constants.LOG_ERROR);
            }

           /* if (cloud.isConnected() && manager.isConnected())
            {
                addLog(logs, Constants.SERVICE_START_OK, Constants.LOG_INFO);
            }

            if (cloud.isConnected() == false)
            {
                addLog(logs, Constants.CANNOT_CONNECT_TO_CLOUD, Constants.LOG_ERROR);
            }
            if (manager.isConnected() == false)
            {
                addLog(logs, Constants.CANNOT_CONNECT_TO_MANAGER, Constants.LOG_ERROR);
            }*/
        }

        private void parseOrder(string order)
        {
            //WZOR WIADOMOSCI PRZEROBIC NA WPIS DO SWITCHING TABLE

            string[] parsed = order.Split('%');

            switch (parsed[0])
            {
                case Constants.SET_LINK:
                    switchTable.addLink(parsed[1], parsed[2]);
                    Link newLink = new Link(Convert.ToString(linkList.Count() + 1), parsed[1], parsed[2]);
                    linkList.Add(newLink);
                    Application.Current.Dispatcher.Invoke((Action)(() =>
                    {
                        this.links.Items.Add(newLink);

                    }));
                    break;
                case Constants.DELETE_LINK:
                    if (parsed[1] == "*")
                    {
                        for (int i = links.Items.Count - 1; i >= 0; i--)
                        {
                            links.Items.Remove(i);
                            linkList.RemoveAt(i);
                        }
                        
                        switchTable.removeAllLinks();
                    }
                    else
                    {
                        switchTable.removeLink(parsed[1]);
                        for (int i = links.Items.Count - 1; i >= 0; i--)
                        {
                            if (parsed[1] == linkList[i].src)
                            {
                                links.Items.Remove(i);
                                linkList.RemoveAt(i);
                            }
                            
                        }
                    }
                    break;
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
        public void stopService()
        {
           
            cloud.stopService();
            cloud = null;
            manager.stopService();
            manager = null;
        }
    }
}
