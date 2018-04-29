using SHCWalletC.CORE;
using System;
using System.IO;

namespace SHCWalletC
{
    class LoginManager
    {
        public  String      WalletName;
        public  String      passString;
        Boolean             MustCreateWallet;
        Keys                KeysLocal;
        WalletData          WalletDataLocal;

        public WalletData Login()
        { 
            Boolean passAccepted;

            if (WalletName == "")
            {
                return null;
            }

            string WalletFilePath = AppDomain.CurrentDomain.BaseDirectory + @"bin\\" + WalletName + ".dat";

            if (!File.Exists(WalletFilePath) && MustCreateWallet)
            {
                WalletDataLocal = GenerateWallet.NewWallet(WalletName, WalletFilePath, passString);

                return WalletDataLocal;
            }
            else if (File.Exists(WalletFilePath) && MustCreateWallet)
            {
                return null;
            }
            else if (!File.Exists(WalletFilePath))
            {
                return null;
            }
            else
            {
                WalletDataLocal = WalletData.ReadBlobToWalletData(WalletName);

                //Checking passWord
                passAccepted = PasswordManager.CheckPass(passString, Convert.ToBase64String(WalletDataLocal.passCode));

                passString = "";    //Dispose of the pass, we don't want any traces left

                if (!passAccepted)
                {
                    System.Threading.Thread.Sleep(1 * 1000);
                    return null;
                }

                return WalletDataLocal;
            }
        }

        //Parameters
        public string ParmWalletUserName(string _WalletName)
        {
            WalletName = _WalletName;

            return WalletName;
        }
        public string ParmPassCode(string _passCode)
        {
            passString = _passCode;

            return passString;
        }
        public Boolean ParmCreateNewWallet(Boolean _MustCreateWallet)
        {
            MustCreateWallet = _MustCreateWallet;

            return MustCreateWallet;
        }
    }
}
