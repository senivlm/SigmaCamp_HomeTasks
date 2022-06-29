using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask11.CustomInterfaces;

namespace SigmaCamp_HomeTask11.Services
{
    static internal class FileOperations
    {
        private static bool CheckFileExistence(string fileName, out string path)
        {
            path = "../../../" + fileName;
            if (!File.Exists(path))
            {
                int i = 1;
                Console.WriteLine($"File {fileName} doesn't exist.");
                Console.WriteLine("You have 2 attempts to input correct file name");
                while (i < 3)
                {
                    Console.Write($"Attempt {i}: ");
                    path = "../../../" + Console.ReadLine();
                    if (File.Exists(path))
                    {
                        return true;
                    }
                    Console.WriteLine($"Attempt {i} failed");
                    i++;
                }
                return false;
            }
            return true;
        }
        public static void ReadProductsFromFile<T>(string fileName, Storage<T> storage) where T : IPrinter, IPriceChanger, IStorageItem
        {
            string inputFilePath;
            if (CheckFileExistence(fileName, out inputFilePath))
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    using (StreamWriter sw = new StreamWriter("../../../ErrorReport.txt", true))
                    {
                        int place = 0;
                        while (!sr.EndOfStream && place < storage.GetCapacity())
                        {
                            string line = sr.ReadLine();
                            try
                            {
                                if (storage is Storage<Product>)
                                {
                                    (storage as Storage<Product>).AddItem(StorageService.ParseProduct(line));
                                    place++;
                                }
                            }
                            catch (ArgumentException ex)
                            {
                                sw.WriteLine($"Error:\n\tLine: {line}\n\t" + ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                sw.WriteLine($"Error:\n\tLine: {line}\n\t" + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("All attempts failed");
            }
        }
    }
}
