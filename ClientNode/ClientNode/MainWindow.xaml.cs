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
            client = new Client(this.chat);
            this.statusBar.Text = "Connected";
            this.ConnectButton.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this.chat.TextAlignment = TextAlignment.Right;
            client.sendMessage(this.toSend.Text);
            //this.chat.TextAlignment = TextAlignment.Left;
        }
    }
}
