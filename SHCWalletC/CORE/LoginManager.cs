using SHCWalletC.CORE;
using SHCWalletC.GUI;
using System;
using System.IO;

namespace SHCWalletC
{
    class LoginManager
    {
        public  String          WalletName;
        public  String          passString;
        Boolean                 MustCreateWallet;
        Keys                    KeysLocal;
        WalletData              WalletDataLocal;
        GUI.WindowsForms.Login  Caller;

        public WalletData Login()
        { 
            Boolean passAccepted;

            if (WalletName == "")
            {
                Caller.SemaphoricExceptionCallLogin("No wallet name specified");
                return null;
            }

            string WalletFilePath = AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\" + WalletName + ".bin";

            if (!File.Exists(WalletFilePath) && MustCreateWallet)
            {
                if (PasswordManager.CheckPassRequirements(passString))
                {
                    WalletDataLocal = GenerateWallet.NewWallet(WalletName, WalletFilePath, passString);
                }
                else
                {
                    Caller.SemaphoricExceptionCallLogin("Passcode does not comply with requirements !");
                    return null;
                }

                return WalletDataLocal;
            }
            else if (File.Exists(WalletFilePath) && MustCreateWallet)
            {
                Caller.SemaphoricExceptionCallLogin("Wallet already exists!");
                return null;
            }
            else if (!File.Exists(WalletFilePath))
            {
                Caller.SemaphoricExceptionCallLogin("Wallet does not exist");
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
                    Caller.SemaphoricExceptionCallLogin("Wrong passcode entered!");
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

        public object ParmCaller(GUI.WindowsForms.Login _Caller)
        {
            Caller = _Caller;

            return Caller;
        }
    }
}
