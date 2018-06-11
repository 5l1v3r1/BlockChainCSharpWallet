using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace BlockChainCSharpWallet.CORE
{
    [Serializable]   //These are storable, so we need this serializable
    public class Keys
    {
        public byte[] privateSpendKey;
        public byte[] privateViewKey;
        public byte[] publicSpendKey;
        public byte[] publicViewKey;
        public byte[] networkByte;
        public byte[] hashedKey;
        public string publicAddress;
        public byte[] passCode;
        public string walletName;

        public void StoreKeySet(    byte[] _privateSpendKey,
                                    byte[] _privateViewKey,
                                    byte[] _publicSpendKey,
                                    byte[] _publicViewKey,
                                    byte[] _networkByte,
                                    byte[] _hashedKey,
                                    string _publicAddress,
                                    byte[] _passCode,
                                    string _walletName)
        {
            privateSpendKey = _privateSpendKey;
            privateViewKey = _privateViewKey;
            publicSpendKey = _publicSpendKey;
            publicViewKey = _publicViewKey;
            networkByte = _networkByte;
            hashedKey = _hashedKey;
            publicAddress = _publicAddress;
            passCode = _passCode;
            walletName = _walletName;
        }
    }
}
