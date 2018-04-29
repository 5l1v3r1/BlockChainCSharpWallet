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
        string passCode;

        public void StoreKeySet(    byte[]  _privateSpendKey, 
                                    byte[]  _privateViewKey, 
                                    byte[]  _publicSpendKey, 
                                    byte[]  _publicViewKey,
                                    byte[]  _networkByte,
                                    byte[]  _hashedKey, 
                                    string  _publicAddress,
                                    string  _passCode)
        {
            privateSpendKey = _privateSpendKey;
            privateViewKey  = _privateViewKey;
            publicSpendKey  = _publicSpendKey;
            publicViewKey   = _publicViewKey;
            networkByte     = _networkByte;
            hashedKey       = _hashedKey;
            publicAddress   = _publicAddress;
            passCode        = _passCode;

            //Now we got the object filled, store its data
            Keys.WriteKeySet(this, publicAddress);
        }

        public static void WriteKeySet(Keys _KeysToBlob, string _publicAddress)
        {
            //TODO: Move serialization to FileBinIO to avoid duplicating code on multiple objects
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _KeysToBlob);
            byte[] BlobData = memorystream.ToArray();

            FileBinIO.WriteBin(BlobData, _publicAddress);
        }
        public static Keys ReadBlobToKeySet(string _publicAddress)
        {
            //Read from bin
            //TODO: Move deserialization to FileBinIO to avoid duplicating code on multiple objects
            byte[] BlobData = FileBinIO.ReadBin(AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\" + _publicAddress + ".bin");

            MemoryStream memorystreamd = new MemoryStream(BlobData);
            BinaryFormatter bfd = new BinaryFormatter();
            Keys deserializedBlock = bfd.Deserialize(memorystreamd) as Keys;

            memorystreamd.Close();

            return deserializedBlock;
        }
    }
}
