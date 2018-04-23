using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonetaVerdeWalletC
{
    class UserInteractionManager
    {
        //This class contains all code for handling input from the user and sending responses back
        public static String WaitForUserInput()
        {
            String          ret = "";

            //Wait for user input (simple way, we can do something fancy here)
            ret = Console.ReadLine();

            return ret;
        }
        public static void HandleNewUserRequest(String _request)
        {

            //The user has asked a new thing to do, handle it
            switch (_request)
            {
                case ("balance"):
                    {
                        Console.WriteLine(TransactionManager.GetBalance());     //Gets balance and write it for the user
                        break;
                    }
                case ("address"):
                    { 
                        Console.WriteLine(TransactionManager.GetPubAddress());  //Gets public address and write it for the user
                        break;
                    }
                case ("transactions"):
                    {
                        TransactionManager.GetTransactions();                   //Gets transactions
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Undefined request");                 //Undefined request, also show help message
                        Help.ShowHelp();
                        break;
                    }
            }
        }
    }
}
