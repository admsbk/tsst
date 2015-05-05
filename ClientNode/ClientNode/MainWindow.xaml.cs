using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClientNode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Client client;
        public MainWindow()
        {
            InitializeComponent();
            client = new Client(this.chat, this.txtBlock);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += ((sender, e) =>
            {
                if (scroll.VerticalOffset == scroll.ScrollableHeight)
                {
                    scroll.ScrollToEnd();
                }
            });
            timer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client.startService();
            if (client.isStarted())
            {
                this.ConnectButton.IsEnabled = false;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this.chat.TextAlignment = TextAlignment.Right;
            client.sendMessage(this.toSend.Text);
            //this.chat.TextAlignment = TextAlignment.Left;
        }
        private void Load_Conf_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Text documents (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string pathToFile = dlg.FileName; 
                client.readConfig(pathToFile);
            }
        }
        private void About_Click(object sender, EventArgs e)
        {/*
            AboutAuthors about = new AboutAuthors();
            about.ShowDialog();
            */
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("load conf clicked");

        }
    }
}
