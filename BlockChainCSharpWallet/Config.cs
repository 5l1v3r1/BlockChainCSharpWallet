using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHCWalletC
{
    public class Config
    {
        //Set all required variables for the cryptonote coin
        public string LocalHost     = "127.0.0.1:51485";    //Expected daemon port localHost(RPC)
        public string RemoteHost    = "";                   //Expected daemon port remote(RPC)
        public string NetworkPreFix = "0x42ca";             //Set prefix for network byte (public address prefix)
        
        public static Config GetConfiguration()
        {
            return new Config();
        }
    }
}