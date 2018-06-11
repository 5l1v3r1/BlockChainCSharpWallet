using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace SHCWalletC.CORE
{
    [Serializable]
    public class WalletData
    {
        //This walletData class will hold all data needed for interacting with the BlockChain, including Keys Object, blockchain data etc. etc.
        public Keys                 Keydata;
        public  byte[]              passCode;
        public  string              walletName;
        public BlockChain           StoredBlockChain;

        public WalletData CreateNewWalletData(Keys   _Keys, string _pass, string _walletName)
        {
            WalletData WalletDataLocal  = new WalletData();
            WalletDataLocal.Keydata     = _Keys;
            WalletDataLocal.passCode    = PasswordManager.GenerateSaltedOutputBytes(_pass);
            WalletDataLocal.walletName  = _walletName;
            //Now we got the object filled, store its data

            WalletData.WriteWalletData(WalletDataLocal, _walletName);

            return WalletDataLocal;
        }

        public static void WriteWalletData(WalletData _WalletDataToBlob, string _walletName)
        {
            //TODO: Move serialization to FileBinIO to avoid duplicating code on multiple objects
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _WalletDataToBlob);
            byte[] BlobData = memorystream.ToArray();

            FileBinIO.WriteBin(BlobData, _walletName);
        }
        public static WalletData ReadBlobToWalletData(string _walletName)
        {
            //Read from bin
            //TODO: Move deserialization to FileBinIO to avoid duplicating code on multiple objects
            byte[] BlobData = FileBinIO.ReadBin(AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\" + _walletName + ".bin");

            MemoryStream memorystreamd = new MemoryStream(BlobData);
            BinaryFormatter bfd = new BinaryFormatter();
            WalletData deserializedBlock = bfd.Deserialize(memorystreamd) as WalletData;

            memorystreamd.Close();

            return deserializedBlock;
        }
    }
}
