using System;
using System.Windows.Forms;
using SHCWalletC.CORE;

namespace SHCWalletC.GUI.WindowsForms
{
    public partial class Login : Form
    {
        Boolean mayLogin;

        public Login()
        {
            InitializeComponent();

            mayLogin = false;
            ButtonLogin.Enabled = mayLogin;
        }

        private void PassCodeTextbox_TextChanged(object sender, EventArgs e)
        {
            mayLogin = PassCodeTextbox.Text != "" && UserNameTextbox.Text != "";

            ButtonLogin.Enabled = mayLogin;
        }

        private void UserNameTextbox_TextChanged(object sender, EventArgs e)
        {
            mayLogin = PassCodeTextbox.Text != "" && UserNameTextbox.Text != "";

            ButtonLogin.Enabled = mayLogin;
        }

        public void SemaphoricExceptionCallLogin(string _errorMessage)
        {
            SystemOutput.Text = _errorMessage;
        }

        private void CreateNewWalletCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ButtonLogin.Text = CreateNewWalletCheckbox.Checked ? "Generate" : "Login";
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginManager LoginMan = new LoginManager();  //Create object
            WalletData WalletData;

            LoginMan.ParmWalletUserName(UserNameTextbox.Text);
            LoginMan.ParmPassCode(PassCodeTextbox.Text);
            LoginMan.ParmCreateNewWallet(CreateNewWalletCheckbox.Checked);
            LoginMan.ParmCaller(this);

            try
            {
                WalletData = LoginMan.Login();
            }
            catch (Exception messageException)
            {
                SystemOutput.Text = messageException.Message;
            }
  
            if (LoginMan.Login() != null)
            {
                this.Close();
            }
        }
    }
}
