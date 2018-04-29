using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace SHCWalletC.CORE
{
    [Serializable]
    class Preference
    {
        public Boolean      useRemoteDaemon;
        public string       remoteDaemonAddress;
        public string       daemonIPPort = "127.0.0.1:51485";   //Expect localhost

        public void StorePreferences    (Boolean    _useRemoteDaemon,
                                         string     _remoteDaemonAddress,
                                         string     _daemonIPPort)
                                    
        {
            useRemoteDaemon     = _useRemoteDaemon;
            remoteDaemonAddress = _remoteDaemonAddress;
            daemonIPPort        = _daemonIPPort;

            //Now we got the object filled, store its data
            Preference.WritePreferences(this);
        }

        public static void WritePreferences(Preference _PrefToBlob)
        {
            //TODO: Move serialization to FileBinIO to avoid duplicating code on multiple objects
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _PrefToBlob);
            byte[] BlobData = memorystream.ToArray();

            FileBinIO.WriteBin(BlobData, "Pref");
        }
        public static Preference ReadBlobToPreferences()
        {
            //TODO: Move deserialization to FileBinIO to avoid duplicating code on multiple objects
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\Pref.bin"))
            {
                //Return empty object
                return new Preference();
            }

            byte[] BlobData = FileBinIO.ReadBin(AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\Pref.bin");

            MemoryStream memorystreamd = new MemoryStream(BlobData);
            BinaryFormatter bfd = new BinaryFormatter();
            Preference prefData = bfd.Deserialize(memorystreamd) as Preference;

            memorystreamd.Close();

            return prefData;
        }
    }
}
