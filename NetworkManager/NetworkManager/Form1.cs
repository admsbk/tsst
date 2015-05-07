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

        private List<string> previousCommands;
        private int commandListPos;
        private Configuration config;
        

        private Manager NetManager;
        private Logs logs;
        
        public Form1()
        {
            InitializeComponent();
            SendToAll.Enabled = false;
            Start.Enabled = false;

            previousCommands = new List<string>();
            commandListPos = 0;
            logs = new Logs(this.Logs);
            config = new Configuration(this.logs);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if(NetManager.startManager(config.ManagerPort))
                    afterStarted();

        }

        private void afterStarted()
        {

            Start.Enabled = false;
            SendToAll.Enabled = true;
            LoadConfigurationButton.Enabled = false;

        }
        private void afterConfiguration()
        {
            Start.Enabled = true;
            NetManager = new Manager(logs);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NetManager.sendCommandToAll(textBox1.Text))
            {
                previousCommands.Add(textBox1.Text);
                commandListPos = previousCommands.Count;
                textBox1.Text = "";
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NetManager != null)
                NetManager.stopManager();

        }

        private void Logs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadConfigurationButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            config.loadConfiguration(openFileDialog.FileName);
                afterConfiguration();
        }

        private void openFileDialog_FileOk_1(object sender, CancelEventArgs e)
        {
            config.loadConfiguration(openFileDialog.FileName);
            afterConfiguration();
        }

    }
}
