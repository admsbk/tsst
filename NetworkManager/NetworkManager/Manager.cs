using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using networkLibrary;



namespace NetworkManager
{
    class Manager
    {
        public transportServer server;
        //private ListView nodes;
        private List<TcpClient> clientSockets = new List<TcpClient>();
        private CommandVerifier commandVerifier;
        private Logs logs;

        public Manager (Logs logs)
        {
            this.commandVerifier = new CommandVerifier();
            this.logs = logs;

        }
        public bool startManager(int port)
        {
            try
            {
                server = new transportServer(port);
                logs.addLogFromOutside(Constants.MANAGER_STARTED, true, Constants.INFO);
                return true;
            }
            catch
            {
                return false;
            }
            



        }

        public void stopManager()
        {
            try
            {
                server.serverSocket.Stop();
                server.serverSocket = null;
                server.serverThread = null;
            }
            catch
                {

                }
        }
        public bool sendCommandToAll(string command)
        {
            bool returned = false;
            if (command != null)
            {
               if (this.server != null)
               {
                   bool validCommand = commandVerifier.verifyCommand(command);
                   if (validCommand == false)
                   {
                       logs.addLogFromOutside(networkLibrary.Constants.COMMAND+command, true, 3);
                       logs.addLogFromOutside(commandVerifier.getErrorMessage(), false, 3);

                   }
                   

                   foreach (TcpClient client in clientSockets)
                   {
                       if (client.Connected)
                       {
                           server.stream = client.GetStream();
                           byte[] buffer = server.encoder.GetBytes(command);
                           server.stream.Write(buffer, 0, buffer.Length);
                           server.stream.Flush();
                       }
                   }
                   returned = true;
               }
            }
            return returned;
        }
    }
}
