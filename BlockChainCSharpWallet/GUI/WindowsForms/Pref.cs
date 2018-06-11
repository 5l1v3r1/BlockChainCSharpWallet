using System;
using System.Windows.Forms;
using BlockChainCSharpWallet.CORE;

namespace BlockChainCSharpWallet.GUI.WindowsForms
{
    public partial class Pref : Form
    {
        Preference PreferenceObject;

        public Pref()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Pref_Load(object sender, EventArgs e)
        {
            PreferenceObject = Preference.ReadBlobToPreferences();  //Get the preferences

            //Load data to form
            RemoteDaemonAddress.Text    = PreferenceObject.remoteDaemonAddress;
            UseRemoteDaemonCB.Checked   = PreferenceObject.useRemoteDaemon;
            LocalDaemonAddress.Text     = PreferenceObject.daemonIPPort;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //Store data
            PreferenceObject.StorePreferences(UseRemoteDaemonCB.Checked, RemoteDaemonAddress.Text, LocalDaemonAddress.Text);
            this.Close();
        }
    }
}
