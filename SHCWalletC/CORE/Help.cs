using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHCWalletC
{
    class Help
    {
        public static void ShowHelp()
        {
            Console.WriteLine("HELP FUNCTIONS");
            Console.WriteLine("--help: Show the help function");
            Console.WriteLine("--version: Show the version of the wallet");
            Console.WriteLine("");
            Console.WriteLine("LOGIN DIRECTLY");
            Console.WriteLine("--walletname:<wallet name>");
            Console.WriteLine("--password:<password>");
            Console.WriteLine("CONNECTING TO REMOTE DAEMON");
            Console.WriteLine("--daemonipport:<IP:PORT> e.g. --daemonipport:86.123.123.12:26081");
            Console.WriteLine("WHEN LOGGED IN, FUNCTIONS");
            Console.WriteLine("balance : shows current balance");
            Console.WriteLine("transactions : shows transactions");
            Console.WriteLine("address : shows public address key");
            Console.WriteLine("REMARKS:");
            Console.WriteLine("Why is there no 'refresh' function? Because we believe the user shouldn't worry about the refresh and the system should handle this");
        }
    }
}
