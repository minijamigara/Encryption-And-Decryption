using System;
using System.IO;

namespace Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedPath = "E:\\encryptedData.txt";
            string keyPath = "E:\\key.txt";
            string decryptedPath = "E:\\decryptedData.txt";

            string[] files = new string[10];

            //check if the files exists or not
            if ((File.Exists(encryptedPath)) && (File.Exists(keyPath)))
            {
                long length = new System.IO.FileInfo(encryptedPath).Length;

                //check if the file size is greater than 5mB or not
                if (length <= 5000000)
                {
                    var str = File.ReadAllText(encryptedPath); // Read encrypted file data
                    var key = File.ReadAllText(keyPath); //Read key file data

                    /*
                     * files[0] = key file
                     * files[1] = original file
                     * files[2] = encrypted file
                     */

                    //Remove the last two characters
                    files[0] = key.Remove(key.Length - 2);
                    files[1] = str.Remove(str.Length - 2);
                    files[2] = Decrypt.DecryptString(files[0], files[1]); //key , cipher text

                    if (File.Exists(decryptedPath))
                    {
                        File.Delete(decryptedPath);
                        StreamWriter OurStream;
                        OurStream = File.CreateText(decryptedPath);
                        OurStream.WriteLine(files[2]);
                        OurStream.Close();
                        Console.WriteLine("Key :" + files[0]);
                        Console.WriteLine("Decrypt string :" + files[2]);
                        Console.WriteLine("Created Decrypted File!");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Successfully Decrypted !!!", Console.ForegroundColor);
                    }
                    else
                    {
                        StreamWriter OurStream;
                        OurStream = File.CreateText(decryptedPath);
                        OurStream.WriteLine(files[2]);
                        OurStream.Close();
                        Console.WriteLine("Created Decrypted File!");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Successfully Decrypted !!!", Console.ForegroundColor);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("File size exceed !",Console.ForegroundColor);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cannot find the file", Console.ForegroundColor);
            }
        }
    }
}
