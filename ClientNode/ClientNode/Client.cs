using networkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientNode
{
    class Client
    {
        private transportClient client;
        private Grid chat;
        private int messageNumber = 0;
        private int rIndex;
        public Client(Grid chat)
        {
            try
            {
                client = new transportClient("localhost", "3333");
                client.OnNewMessageRecived += new transportClient.NewMsgHandler(newMessageRecived);
                this.chat = chat;
                rIndex = Grid.GetRow(chat);
               
            }

            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void newMessageRecived(object a, MessageArgs e)
        {
            Console.WriteLine(e.Message);
            this.chat.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        var t = new TextBlock();
                        t.Text = ("[" + DateTime.Now.ToString("HH:mm:ss") + "]" + Environment.NewLine +
                            e.Message + Environment.NewLine + Environment.NewLine);
                        t.TextAlignment = System.Windows.TextAlignment.Right;
                        RowDefinition gridRow = new RowDefinition();
                        gridRow.Height = new GridLength(35);
                        chat.RowDefinitions.Add(gridRow);
                        Grid.SetRow(t, messageNumber);
                        messageNumber++;
                        chat.Children.Add(t);

                    })
            );
        }

        public void sendMessage(string msg)
        {
            client.sendMessage(msg);
            this.chat.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        var t = new TextBlock();
                        t.Text = ("[" + DateTime.Now.ToString("HH:mm:ss") + "]" + Environment.NewLine +
                            msg + Environment.NewLine + Environment.NewLine);
                        t.TextAlignment = System.Windows.TextAlignment.Left;
                        RowDefinition gridRow = new RowDefinition();
                        gridRow.Height = new GridLength(35);
                        chat.RowDefinitions.Add(gridRow);
                        Grid.SetRow(t, messageNumber);
                        messageNumber++;
                        chat.Children.Add(t);
                        

                    })
            );
        }

    }
}
