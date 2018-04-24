using System;

namespace SHCWalletC
{
    class GenerateWallet
    {
        //this class will hold all required code for creating a new wallet from scratch

        public static void NewWallet(String _walletName, String _walletfilePath)
        {
            Console.WriteLine("Generating new wallet");
            ConsoleKeyInfo key;
            String passString = "";
            String StoreString;
			String PublicAddress;
            Boolean passAcceptable = false;

            do
            {
                Console.WriteLine("Please enter a new passcode");
                do
                {
                    key = Console.ReadKey(true);

                    // Ignore any key out of range.
                    if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                    {
                        // Append the character to the password.
                        passString += key.KeyChar;
                        Console.Write("*");
                    }
                    // Exit if Enter key is pressed.
                } while (key.Key != ConsoleKey.Enter);

                passAcceptable = PasswordManager.CheckPassRequirements(passString);
            } while (passAcceptable == false);

			PublicAddress = KeyManager.GenerateKeySet();
            //StoreString = PasswordManager.GenerateSaltedOutput(passString);   // Salt password (OLD)
            WalletFileManager.WriteBin(PublicAddress, _walletfilePath);			// Write public address to Bin

            Console.WriteLine("Wallet generated!");
        }
    }
}
