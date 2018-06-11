using System;

namespace BlockChainCSharpWallet.CORE
{
    class GenerateWallet
    {
        //this class will hold all required code for creating a new wallet from scratch

        public static WalletData NewWallet(String _walletName, String _walletfilePath, string _passCode)
        {
            String      passString = _passCode;
            Keys        KeysClass;
            Boolean     passAcceptable;
            WalletData  WalletDataCreate;

            passAcceptable = PasswordManager.CheckPassRequirements(passString);

            if (passAcceptable)
            {
                KeysClass = KeyManager.GenerateKeySet(_passCode, _walletName);
                WalletDataCreate = new WalletData();
                WalletDataCreate = WalletDataCreate.CreateNewWalletData(KeysClass, _passCode, _walletName);

                return WalletDataCreate;
            }
            else
            {
                return null;
            }
        }
    }
}
