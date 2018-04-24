using System;
using System.IO;

namespace SHCWalletC
{
    class WalletFileManager
    {
        //this class will hold all required code for interaction with the folder files

        public static Boolean DoesWalletExist(string _fileName)
        {
            //Checks whether the wallet already exists
            Boolean ret = true;

            ret = File.Exists(_fileName);

            return ret;
        }

        public static void WriteBin(String _storage, String _filePath)
        {
            //Write to wallet file
            byte[] arr = System.Text.Encoding.ASCII.GetBytes(_storage); //Convert to byte code
            String FileFolder = AppDomain.CurrentDomain.BaseDirectory + @"bin\\";

            if (!Directory.Exists(FileFolder))
            {
                //Create directory if it does not exist
                Directory.CreateDirectory(FileFolder);
            }

            BinaryWriter writer = new BinaryWriter(File.Open(_filePath, FileMode.Create));

            writer.Write(arr);  //Write binaries
            writer.Close();
        }
        public static string ReadBin(String _filePath)
        {
            StreamReader sr = new StreamReader(_filePath);
            String Pass = "";

            while (sr.Peek() > -1)
            {
                Pass = sr.ReadLine();
            }

            return Pass;
        }
    }
}
