﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using BlockChainCSharpWallet.CORE;
using BlockChainCSharpWallet.GUI.WindowsForms;

namespace BlockChainCSharpWallet.GUI
{
    public partial class MainForm : Form
    {
        public WalletData WalletData;

        public MainForm()
        {
            InitializeComponent();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        public WalletData   ParmWalletData(WalletData _data)
        {
            WalletData = _data;

            return WalletData;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://harrier.tech/");
            Process.Start(sInfo);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LabelAddress.Text = WalletData.Keydata.publicAddress;
            QRReceive.Image = QRCodeManager.CreateQR(LabelAddress.Text, 3);    //Create QR based on wallet, later to be handled in the core classes
        }

        private void LabelDaemonBlockHeight_Click(object sender, EventArgs e)
        {

        }

        private void LabelYourWallet_Click(object sender, EventArgs e)
        {

        }

        private void LabelAddress_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(LabelAddress.Text);
            MessageBox.Show("Copied address to clipboard");
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();

            WalletData = null;  //Clear data

            // Show the settings form
            loginForm.Show();

            this.Close();
        }

        private void PreferencesButton_Click(object sender, EventArgs e)
        {
            Pref PrefForm = new Pref();

            // Show the settings form
            PrefForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://harrier.tech/");
            Process.Start(sInfo);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://harrier.tech/");
            Process.Start(sInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RPCConnectionManager.SendRPCJson("GetStatus");
        }
    }
}
