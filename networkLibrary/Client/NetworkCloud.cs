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

namespace Cloud
{
    class NetworkCloud
    {
        transportServer server;
        private ListView links;
        private TextBox logs;
        private Dictionary<TcpClient, string> clientSockets = new Dictionary<TcpClient, string>();
        private List<TcpClient> sockests;
        transportServer.NewClientHandler reqListener;
        transportServer.NewMsgHandler msgListener;

        public NetworkCloud(ListView links, TextBox logs)
        {
            int port = 3333;

            try
            {
                server = new transportServer(port);

            }
            catch
            {

            }
            sockests = new List<TcpClient>();
            reqListener = new transportServer.NewClientHandler(newClientRequest);
            msgListener = new transportServer.NewMsgHandler(newMessageRecived);
            server.OnNewClientRequest += reqListener;
            server.OnNewMessageRecived += msgListener;
            this.links = links;
            this.logs = logs;
            
        }

        private void newClientRequest(object a, ClientArgs e)
        {

            addLog(e.message);
            sockests.Add(e.Client);
            server.sendMessage(e.Client, "Client"+sockests.IndexOf(e.Client));
        }

        private void newMessageRecived(object a, MessageArgs e)
        {
            addLog(e.Message);
        }

        public void stopServer(){
            server.OnNewClientRequest -= reqListener;
            server.OnNewMessageRecived -= msgListener;
            server.stopServer();
        }

        private void addLog(string message)
        {
            this.logs.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() => { logs.Text += (message + Environment.NewLine); })
                    );
        }

    }
}
