using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace networkLibrary
{
    public class transportClient 
    {
        private TcpClient client;
        private Thread clientThread;
        protected ASCIIEncoding encoder;
        protected NetworkStream stream;

        public delegate void NewMsgHandler(object myObject, MessageArgs myArgs);
        public event NewMsgHandler OnNewMessageRecived;

        public transportClient(string ip, string port)
        {
            this.encoder = new ASCIIEncoding();

            client = new TcpClient();
            IPAddress ipAddress;
            if (ip.Contains("localhost"))
            {
                ipAddress = IPAddress.Loopback;
            }
            else
            {
                ipAddress = IPAddress.Parse(ip);
            }

            try
            {
                int dstPort = Convert.ToInt32(port);
                client.Connect(new IPEndPoint(ipAddress, dstPort));
            }
            catch { }

            if (client.Connected)
            {
                stream = client.GetStream();
                clientThread = new Thread(new ThreadStart(ListenForMessage));
                clientThread.Start();
                sendMyName();

            }
            else
            {
                client = null;
            }
        }

        protected void ListenForMessage()
        {


            //TcpClient clientSocket = (TcpClient)client;

            byte[] message = new byte[4096];
            int bytesRead;

            while (stream.CanRead)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                // parser.parseMsgFromCloud(encoder.GetString(message, 0, bytesRead), true);
            }

            //Console.WriteLine(signal);
            MessageArgs myArgs = new MessageArgs(System.Text.Encoding.UTF8.GetString(message));
            OnNewMessageRecived(this, myArgs);

        }
     


        
        private void sendMyName()
        {
            {
                byte[] buffer = encoder.GetBytes("//NAME// " + "PROXY");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }
    }
}
