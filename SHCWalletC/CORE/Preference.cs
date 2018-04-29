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

        public void StorePreferences    (Boolean    _useRemoteDaemon,
                                         string     _remoteDaemonAddress)
                                    
        {
            useRemoteDaemon     = _useRemoteDaemon;
            remoteDaemonAddress = _remoteDaemonAddress;

            //Now we got the object filled, store its data
            Preference.WritePreferences(this);
        }

        public static void WritePreferences(Preference _PrefToBlob)
        {
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(memorystream, _PrefToBlob);
            byte[] BlobData = memorystream.ToArray();

            FileBinIO.WriteBin(BlobData, "Pref");
        }
        public static Preference ReadBlobToPreferences()
        {
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
