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
    public class transportServer
    {
        protected ASCIIEncoding encoder;
        protected NetworkStream stream;
        private TcpListener serverSocket;
        private Thread serverThread;
        private Dictionary<TcpClient, string> clientSockets = new Dictionary<TcpClient, string>();

        public transportServer(int port)
        {
            this.encoder = new ASCIIEncoding();
            if (serverSocket == null && serverThread == null)
            {      
                    this.serverSocket = new TcpListener(IPAddress.Any, port);
                    this.serverThread = new Thread(new ThreadStart(ListenForClients));
                    this.serverThread.Start();
                    Console.WriteLine("Serwer start OK");
                    //logs.addLog(Constants.CLOUD_STARTED_CORRECTLY, true, Constants.LOG_INFO, true);        
            }
            else
            {
                //logs.addLog(Constants.CLOUD_STARTED_ERROR, true, Constants.LOG_ERROR, true);
                //return false;
                throw new Exception("server has been started");
            }
        }
        private void ListenForClients()
        {
            
            this.serverSocket.Start();
            while (true)
            {
         
                try
                {
                    Console.WriteLine("server thread");
                    TcpClient clientSocket = this.serverSocket.AcceptTcpClient();
                    
                    clientSockets.Add(clientSocket, "Unknown");
                    Thread clientThread = new Thread(new ParameterizedThreadStart(ListenForMessage));
                    clientThread.Start(clientSocket);
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    break;
                }
            }
        }

        protected void ListenForMessage(object client)
        {

            TcpClient clientSocket = (TcpClient)client;
            NetworkStream stream = clientSocket.GetStream();

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

                string signal = encoder.GetString(message, 0, bytesRead);
                if (clientSockets[clientSocket].Equals("unknown"))
                {
                    //updateClientName(clientSocket, signal); //clients as first message send his id
                    ClientArgs args = new ClientArgs();
                    args.message = "nowy klient";
                    args.dstPort = "3333";
                    OnNewClientRequest(this, args);
                    
                }
                else
                {
                    MessageArgs myArgs = new MessageArgs(signal);
                    OnNewMessageRecived(this, myArgs);
                }
            }
            if (serverSocket != null)
            {
                try
                {
                    clientSocket.GetStream().Close();
                    clientSocket.Close();
                    clientSockets.Remove(clientSocket);
                }
                catch
                {
                }
            }


           
        }

        public delegate void NewMsgHandler(object myObject, MessageArgs myArgs);
        public event NewMsgHandler OnNewMessageRecived;

        public delegate void NewClientHandler(object myObject, ClientArgs myArgs);
        public event NewClientHandler OnNewClientRequest;

        private bool getClientName(TcpClient client, string msg)
        {
            if (msg.Contains("//NAME// "))
            {
                string[] tmp = msg.Split(' ');
                clientSockets[client] = tmp[1];
                return true;
            }
            else
            {
                return false;
            }
        }

        public void stopServer()
        {
            //Console.WriteLine(clientSockets.Keys.ToList()[0].Connected);
            foreach (TcpClient clientSocket in clientSockets.Keys.ToList())
            {
                try
                {
                    clientSocket.GetStream().Close();
                    clientSocket.Close();
                    clientSockets.Remove(clientSocket);
                }
                catch
                {
                    Console.WriteLine("Problems with disconnecting clients from cloud");
                }
            }
            if (serverSocket != null)
            {
                try
                {
                    serverSocket.Stop();
                }
                catch
                {
                    Console.WriteLine("Unable to stop cloud");
                }
            }
            serverSocket = null;
            serverThread = null;
        }

        public void sendMessage(string name, string msg)
        {
            if (serverSocket != null)
            {
                stream = null;
                TcpClient client = null;
                List<TcpClient> clientsList = clientSockets.Keys.ToList();
                Console.Write(clientsList.Count);
                for (int i = 0; i < clientsList.Count; i++)
                {
                    if (clientSockets[clientsList[i]].Equals(name))
                    {
                        client = clientsList[i];
                        break;
                    }
                }
                /*
                if (client != null)
                {
                    if (client.Connected)
                    {
                        stream = client.GetStream();
                        byte[] buffer = encoder.GetBytes(msg);
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                    }
                    else
                    {
                        stream.Close();
                        clientSockets.Remove(client);
                    }
                }*/
            }
        }
    }
}
