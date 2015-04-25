using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using networkLibrary;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cloud
{
    class NetworkCloud
    {
        transportServer server;
        private ListView links;
        private TextBox logs;
        transportServer.NewClientHandler reqListener;
        transportServer.NewMsgHandler msgListener;

        public NetworkCloud(ListView links, TextBox logs)
        {
            int port = 3333;
            server = new transportServer(port);
            reqListener = new transportServer.NewClientHandler(newClientRequest);
            msgListener = new transportServer.NewMsgHandler(newMessageRecived);
            server.OnNewClientRequest += reqListener;
            server.OnNewMessageRecived += msgListener;
            this.links = links;
            this.logs = logs;
            
        }

        private void newClientRequest(object a, ClientArgs e)
        {
            //logs.Text+=("polaczony nowy client\n");
            logs.Text += "polaczony nowy client" + Environment.NewLine;
           
            //this.logListView.Items.Add(e);
            //Console.WriteLine(e.message);
        }

        private void newMessageRecived(object a, MessageArgs e)
        {
           this.logs.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() => { logs.Text += (e.Message + Environment.NewLine); })
                    );

                //logs.Text += "polaczony nowy client" + Environment.NewLine;
            Console.WriteLine(e.Message);
        }

        public void stopServer(){
            server.OnNewClientRequest -= reqListener;
            server.OnNewMessageRecived -= msgListener;
            server.stopServer();
        }

    }
}
