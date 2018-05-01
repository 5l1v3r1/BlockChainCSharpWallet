using System;
using SHCWalletC.CORE;

namespace SHCWalletC
{
    [Serializable]
    public class BlockChain
    {
        Block []    Block;
        public int  blockHeightWallet;
        public int  blockHeightDaemon;

        public void Sync()
        {
            int blockHeightDaemon = BlockChain.GetDaemonBlockHeight();   //Gets current daemonHeight

            do
            {
                blockHeightWallet++;
                this.AddBlock(blockHeightWallet);  //Update block

            } while (blockHeightDaemon > blockHeightWallet);
            //Here we need to program a refresh polling mechanism which will poll for example every minute if the blockheight of the daemon updated and if we need to sync again
        }       
        public static int GetDaemonBlockHeight()
        {
            //Get current blockheight from Daemon
            string BlockCountStr = "190000000";//TODO, real value from Daemon RPCConnectionManager.TestRPCJson("getblockcount", "");

            return Convert.ToInt32(BlockCountStr);  //We expect a 32 bit int to be sufficient, could be altered to INT64 here
        }
        public Block[] AddBlock(int _blockHeightToFetch)
        {
            //Fetch block from Daemon and add it to file
            Block newBlock = new Block();
            //Add a new block to the chain

            Array.Resize(ref Block, Block.Length + 1);
            Block[Block.Length - 1] = newBlock;

            return Block;
        } 
    }
}
