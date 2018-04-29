using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace SHCWalletC
{
   [Serializable]   //These are storable, so we need this serializable
    public class Keys
    {
        byte[] privateSpendKey;
        byte[] privateViewKey;
        byte[] publicSpendKey;
        byte[] publicViewKey;
        byte[] networkByte;
        byte[] hashedKey;
        string publicAddress;
        byte[] passCode;
        string walletName;

        public void StoreKeySet(    byte[]  _privateSpendKey, 
                                    byte[]  _privateViewKey, 
                                    byte[]  _publicSpendKey, 
                                    byte[]  _publicViewKey,
                                    byte[]  _networkByte,
                                    byte[]  _hashedKey, 
                                    string  _publicAddress,
                                    byte[]  _passCode,
                                    string  _walletName)
        {
            privateSpendKey = _privateSpendKey;
            privateViewKey  = _privateViewKey;
            publicSpendKey  = _publicSpendKey;
            publicViewKey   = _publicViewKey;
            networkByte     = _networkByte;
            hashedKey       = _hashedKey;
            publicAddress   = _publicAddress;
            passCode        = _passCode;
            walletName      = _walletName;

            //Now we got the object filled, store its data
            Keys.WriteKeySet(this, walletName);
        }

        public static void WriteKeySet(Keys _KeysToBlob, string _walletName)
        {
            //TODO: Move serialization to FileBinIO to avoid duplicating code on multiple objects
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _KeysToBlob);
            byte[] BlobData = memorystream.ToArray();

            FileBinIO.WriteBin(BlobData, _walletName);
        }
        public static Keys ReadBlobToKeySet(string _walletName)
        {
            //Read from bin
            //TODO: Move deserialization to FileBinIO to avoid duplicating code on multiple objects
            byte[] BlobData = FileBinIO.ReadBin(AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\" + _walletName + ".bin");

            MemoryStream memorystreamd = new MemoryStream(BlobData);
            BinaryFormatter bfd = new BinaryFormatter();
            Keys deserializedBlock = bfd.Deserialize(memorystreamd) as Keys;

            memorystreamd.Close();

            return deserializedBlock;
        }
    }
}
