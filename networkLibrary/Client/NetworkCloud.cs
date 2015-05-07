using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using networkLibrary;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Media;

namespace Cloud
{
    class NetworkCloud
    {
        transportServer server;
        private int messageNumber = 0;
        private ListView links;
        private ListView nodes;
        private Grid logs;
        private string CloudId { get; set; }
        private string CloudIP { get; set; }
        private string CloudPort { get; set; }
        private List<string> portsIn { get; set; }
        private List<string> portsOut { get; set; }
        private Config conf;
        private SwitchingBox switchBox;
        private Dictionary<TcpClient, string> clientSockets = new Dictionary<TcpClient, string>();
        private List<TcpClient> sockests;
        transportServer.NewClientHandler reqListener;
        transportServer.NewMsgHandler msgListener;

        public NetworkCloud(ListView links, ListView nodes, Grid logs)
        {
            this.links = links;
            this.logs = logs;
            this.nodes = nodes;
            this.switchBox = new SwitchingBox();

        }

        public void startService()
        {
            try
            {
                Console.WriteLine(Convert.ToInt32(this.CloudPort));
                server = new transportServer(Convert.ToInt32(this.CloudPort));
                sockests = new List<TcpClient>();
                reqListener = new transportServer.NewClientHandler(newClientRequest);
                msgListener = new transportServer.NewMsgHandler(newMessageRecived);
                server.OnNewClientRequest += reqListener;
                server.OnNewMessageRecived += msgListener;
                if (server.isStarted())
                {
                    addLog(this.logs, Constants.SERVICE_START_OK, Constants.LOG_INFO);
                }
                else
                {
                    addLog(this.logs, Constants.SERVICE_START_ERROR, Constants.LOG_ERROR);
                }
                

            }
            catch
            {
                addLog(this.logs, Constants.SERVICE_START_ERROR, Constants.LOG_ERROR);
            }
        }
        private void newClientRequest(object a, ClientArgs e)
        {

            addLog(this.logs, Constants.NEW_CLIENT_LOG + " " + e.NodeName, Constants.LOG_INFO);
            sockests.Add(e.ID);
            e.NodeID = "Client:" + sockests.IndexOf(e.ID);
            Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    this.nodes.Items.Add(e);
                    
                }));
            //server.sendMessage(e.ID, "Client"+sockests.IndexOf(e.ID));
        }

        private void newMessageRecived(object a, MessageArgs e)
        {
            addLog(this.logs, Constants.NEW_MSG_RECIVED+ " "+e.Message, Constants.LOG_INFO);
        }

        public void readConfig(string pathToConfig)
        {
            try
            {
                int linkNum = 1;
                conf = new Config(pathToConfig, Constants.Cloud);
                this.CloudId = conf.config[0];
                this.CloudIP = conf.config[1];
                this.CloudPort = conf.config[2];
                foreach (KeyValuePair<string, string> entry in conf.switchTable)
                {
                    this.switchBox.addLink(entry.Key, entry.Value);
                    string[] keyItem = entry.Key.Split('%');
                    string[] valueItem = entry.Value.Split('%');
                    links.Items.Add(new Link(Convert.ToString(linkNum), keyItem[0], keyItem[1],
                                                valueItem[0], valueItem[1]));
                    linkNum++;
                }
                
                addLog(logs, networkLibrary.Constants.CONFIG_OK, networkLibrary.Constants.LOG_INFO);
            }
            catch(Exception e)
            {
                addLog(logs, networkLibrary.Constants.CONFIG_ERROR, networkLibrary.Constants.LOG_ERROR);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void stopServer(){
            server.OnNewClientRequest -= reqListener;
            server.OnNewMessageRecived -= msgListener;
            server.stopServer();
        }

        private void addLog(Grid log, string message, int logType)
        {
            var color = Brushes.Black;

            switch (logType)
            {
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

        public bool isStarted()
        {
            if (server != null)
            {
                return server.isStarted();
            }
            else
            {
                return false;
            }
        }
    }
}
