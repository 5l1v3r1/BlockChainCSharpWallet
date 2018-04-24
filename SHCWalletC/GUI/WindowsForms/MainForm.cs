using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace SHCWalletC.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            String daemonIPPort = "127.0.0.1:51485";   //Expect localhost
            InitializeComponent();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            SettingsManager.setAppSetting("daemonIPPort", daemonIPPort);    //Basic set IPPort
            DaemonBlockHeight.Text = Convert.ToString(RPCConnectionManager.SendRPCJson("getblockcount", ""));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://harrier.tech/");
            Process.Start(sInfo);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LabelDaemonBlockHeight_Click(object sender, EventArgs e)
        {

        }
    }
}
