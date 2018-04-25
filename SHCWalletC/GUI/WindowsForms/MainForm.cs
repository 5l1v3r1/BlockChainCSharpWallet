using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using QRCoder;
using SHCWalletC.CORE;

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

            QRReceive.Image = CORE.QRCodeManager.CreateQR(LabelAddress.Text, 3);    //Create QR based on wallet, later to be handled in the core classes
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

        private void LabelYourWallet_Click(object sender, EventArgs e)
        {

        }
    }
}
