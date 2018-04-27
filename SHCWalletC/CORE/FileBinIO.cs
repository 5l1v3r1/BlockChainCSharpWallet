using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace SHCWalletC
{
    class FileBinIO
    {
        public static void WriteBin(byte[] _storage, string _BlockHeight)
        {
            //Write to wallet file
            String FileFolder = AppDomain.CurrentDomain.BaseDirectory + @"bin\\WalletData\\";
            String FilePath = FileFolder + _BlockHeight + ".bin";

            if (!Directory.Exists(FileFolder))
            {
                //Create directory if it does not exist
                Directory.CreateDirectory(FileFolder);
            }

            BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Create));

            writer.Write(_storage);  //Write binaries
            writer.Close();
        }
        public static byte[] ReadBin(String _filePath)
        {
            StreamReader sr = new StreamReader(_filePath);
            var bytes = default(byte[]);
            using (var memstream = new MemoryStream())
            {
                sr.BaseStream.CopyTo(memstream);
                bytes = memstream.ToArray();
            }

            return bytes;
        }
    }
}
