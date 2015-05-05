using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkManager
{
    public partial class Form1 : Form
    {
        int por = 16000;
        networkLibrary.transportServer NetworkManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkManager = new networkLibrary.transportServer(por);
                enableButtonsAfterStarted();

            }
            catch
            {
                Console.WriteLine("Unable to start Network Manager");
            }

        }

        private void enableButtonsAfterStarted()
        {

            button1.Enabled = false;

        }
    }
}
