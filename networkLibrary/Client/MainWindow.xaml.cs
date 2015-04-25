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

namespace Cloud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NetworkCloud cloud;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try{
                cloud = new NetworkCloud(this.links, this.logList);
            }
            catch{
                Console.WriteLine("unable to start cloud");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                
                cloud.stopServer();
            }
            catch
            {
                Console.WriteLine("Unable to stop server");
            }
        }
        private void Load_Conf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("load conf clicked");

        }
        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("load conf clicked");

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("load conf clicked");

        }
    }
}
