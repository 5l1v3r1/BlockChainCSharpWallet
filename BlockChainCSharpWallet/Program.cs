using System;
using System.Windows.Forms;
using SHCWalletC.GUI;
using SHCWalletC.GUI.WindowsForms;

namespace SHCWalletC
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
