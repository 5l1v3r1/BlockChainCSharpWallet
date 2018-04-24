using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHCWalletC
{
    class LoginManager
    {
        //this class will hold all required code for logging in to the wallet
        public static Boolean Login()
        { 
            String WalletName = SettingsManager.getAppSetting("walletID");
            string StoreString = "";
            string passString = SettingsManager.getAppSetting("pass");
            ConsoleKeyInfo key;
            int passRetyCount;
            Boolean passAccepted;

            if (WalletName == "")
            {
                Console.WriteLine("*****Please provide login credentials****");
                Console.WriteLine("Enter your wallet name:");
                WalletName = Console.ReadLine();
            }
            string WalletFilePath = AppDomain.CurrentDomain.BaseDirectory + @"bin\\" + WalletName + ".dat";

            if (!WalletFileManager.DoesWalletExist(WalletFilePath))
            {
                GenerateWallet.NewWallet(WalletName, WalletFilePath);
            }

            //Start the password loop
            passRetyCount = 0;

            do
            {
                if (passString == "")   //Bypass if we have an autoLogin
                {
                    Console.WriteLine("Enter your passCode:");
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
                }

                Console.WriteLine(); //Enter

                //TODO: StoreString has to be fetched from BIN file, for now, generate one with a dummy passcode
                StoreString = WalletFileManager.ReadBin(WalletFilePath);

                //Checking passWord
                passAccepted = PasswordManager.CheckPass(passString, StoreString);

                passString = "";    //Dispose of the pass, we don't want any traces left
                if (!passAccepted)
                {
                    Console.WriteLine("Your password is incorrect!");
                    //Add penalty
                    if (passRetyCount > 0)
                    {
                        Console.WriteLine("Time penalty awarded of {0} seconds", passRetyCount);
                        System.Threading.Thread.Sleep(passRetyCount*1000);
                    }
                    passRetyCount ++;
                }
                else
                {
                    Console.WriteLine("Password check cleared");
                }
            } while (passAccepted == false);
            //End the password loop  

            return true;
        }
    }
}
