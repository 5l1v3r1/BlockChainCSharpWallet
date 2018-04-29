using System;

namespace SHCWalletC
{
    class GenerateWallet
    {
        //this class will hold all required code for creating a new wallet from scratch

        public static Boolean NewWallet(String _walletName, String _walletfilePath, string _passCode)
        {
            String passString = _passCode;
			String PublicAddress;
            Boolean passAcceptable = false;

            passAcceptable = PasswordManager.CheckPassRequirements(passString);

            if (passAcceptable)
            {
                PublicAddress = KeyManager.GenerateKeySet(_passCode, _walletName);
            }

            return passAcceptable;
        }
    }
}
