using System;
using System.Windows.Forms;
using SHCWalletC.CORE;

namespace SHCWalletC.GUI.WindowsForms
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
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            //Store data
            PreferenceObject.StorePreferences(UseRemoteDaemonCB.Checked, RemoteDaemonAddress.Text);
            this.Close();
        }
    }
}
