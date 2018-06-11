using System;

namespace BlockChainCSharpWallet.CORE
{
    public class SendTransaction
    {
        WalletData  wData;
        String      sendToAddress;
        String      paymentDescription;
        double      amount;

        public WalletData   ParmWalletData(WalletData _Data)
        {
            wData = _Data;

            return wData;
        }
        
        public Boolean  SendCoins()
        {
            //Generate one-off public spend key
            Boolean ret = this.MaySendCoins();

            if (ret)
            {
                //Here goes the transaction
                try
                {

                }
                catch
                {

                }
            }

            return ret;
        }
        private Boolean MaySendCoins()
        {
            Boolean ret = true;

            if (sendToAddress == "" || amount<= 0)
            {
                ret = false;
            }

            return ret;
        }
    }
}
