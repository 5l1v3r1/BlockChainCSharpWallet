using System;
using System.Windows.Forms;

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

        private void CreateNewWalletCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ButtonLogin.Text = CreateNewWalletCheckbox.Checked ? "Generate" : "Login";
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            LoginManager LoginMan = new LoginManager();  //Create object

            LoginMan.ParmWalletUserName(UserNameTextbox.Text);
            LoginMan.ParmPassCode(PassCodeTextbox.Text);
            LoginMan.ParmCreateNewWallet(CreateNewWalletCheckbox.Checked);

            if (LoginMan.Login() != null)
            {
                this.Close();
            }
        }
    }
}
