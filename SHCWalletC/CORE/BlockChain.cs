using System;
using SHCWalletC.CORE;

namespace SHCWalletC
{
    [Serializable]
    public class BlockChain
    {
        Block   Block;
        public int blockHeightWallet;
        public int blockHeightDaemon;

        public void Sync()
        {
            int blockHeightDaemon = BlockChain.GetDaemonBlockHeight();   //Gets current daemonHeight
            //int blockHeightWallet = Convert.ToInt32(SettingsManager.getAppSetting("blockHeightWallet"));

            //The sole purpose of this method is to check the current maxBlockHeight on the daemon and keep building the blocks for the wallet untill this level
            do
            {
                blockHeightWallet++;
                this.GetBlock(blockHeightWallet);  //Update block

            } while (blockHeightDaemon > blockHeightWallet);
            //Here we need to program a refresh polling mechanism which will poll for example every minute if the blockheight of the daemon updated and if we need to sync again
        }       
        public static int GetDaemonBlockHeight()
        {
            //Get current blockheight from Daemon
            string BlockCountStr = "190000000";//TODO, real value from Daemon RPCConnectionManager.TestRPCJson("getblockcount", "");

            return Convert.ToInt32(BlockCountStr);  //We expect a 32 bit int to be sufficient, could be altered to INT64 here
        }
        public Block GetBlock(int _blockHeightToFetch)
        {
            //Fetch block from Daemon and add it to file
            Block = new Block();

            return Block;
        } 
    }
}
