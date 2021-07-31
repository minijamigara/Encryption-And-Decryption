using System;
using System.IO;

namespace Encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            // sample key to encrypt and decrypt the message = "b14ca5898a4e4133bbce2ea2315a1916";

            string encryptedPath = "E:\\encryptedData.txt";
            string keyPath = "E:\\key.txt";

            // Array to get the key , message and the encrypted message
            string[] files = new string[10]; 

            try
            {
                //change the fore colours of the text
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Key should be only letters , number and 32 characters:", Console.ForegroundColor);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Write the key:", Console.ForegroundColor);
                Console.WriteLine("Write the message:");

                /*
                 * files[0] = key file
                 * files[1] = original file
                 * files[2] = encrypted file
                 */

                for (int i = 0; i <= 1; i++)
                {
                    files[i] = Console.ReadLine();
                    
                }
                files[2] = Encrypt.EncryptString(files[0], files[1]); //key , plain text
                Console.WriteLine("Encrypted text:" + files[2]);

                //check if the file is exists or not
                if (File.Exists(encryptedPath))
                {
                    File.Delete(encryptedPath);
                    StreamWriter OurStream;
                    OurStream = File.CreateText(encryptedPath);
                    OurStream.WriteLine(files[2]);
                    OurStream.Close();
                    Console.WriteLine("Created Encrypted File!");
                }
                else
                {
                    StreamWriter OurStream;
                    OurStream = File.CreateText(encryptedPath);
                    OurStream.WriteLine(files[2]);
                    OurStream.Close();
                    Console.WriteLine("Created Encrypted File!");
                }

                if (File.Exists(keyPath))
                {
                    File.Delete(keyPath);
                    StreamWriter OurStream;
                    OurStream = File.CreateText(keyPath);
                    OurStream.WriteLine(files[0]);
                    OurStream.Close();
                    Console.WriteLine("Created key File!");
                }
                else
                {
                    StreamWriter OurStream;
                    OurStream = File.CreateText(keyPath);
                    OurStream.WriteLine(files[0]);
                    OurStream.Close();
                    Console.WriteLine("Created key File!");
                }
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                if (ex.Message.Equals("The specified key is not correct.\r\n", StringComparison.InvariantCultureIgnoreCase))
                    throw new Exception("Key size is not acceptable");
                else
                    throw ex;
            }


        }
    }
}
