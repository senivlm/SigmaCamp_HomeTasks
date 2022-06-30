using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask12_1.CustomInterfaces;

namespace SigmaCamp_HomeTask12_1.Services
{
    static internal class FileOperations
    {
        private static string productsFilePath = string.Empty;
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
                productsFilePath = inputFilePath;
                List<string> linesForUtil;
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    linesForUtil = new List<string>();
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
                                    if(!(storage as Storage<Product>).TryAddItem(StorageService.ParseProduct(line)))
                                    {
                                        linesForUtil.Add(line);
                                    }
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
                if (linesForUtil.Count > 0)
                {
                    RemoveUtilizedLines(linesForUtil);
                }
            }
            else
            {
                throw new FileNotFoundException("All attempts failed");
            }
        }
        static public void AddToUtilized(string line)
        {
            using (StreamWriter writer = new StreamWriter("../../../UtilizedProducts.txt"))
            {
                writer.WriteLine(line);
            }
        }
        private static void RemoveUtilizedLines(List<string> lines)
        {
            string[] currentProducts;
            using (StreamReader reader = new(productsFilePath))
            {
                string allText = reader.ReadToEnd();
                currentProducts = allText.Split("\r");
            }
            using (StreamWriter writer = new StreamWriter(productsFilePath))
            {
                foreach (string product in currentProducts)
                {
                    if (!lines.Contains(product))
                    {
                        writer.WriteLine(product);
                    }
                }
            }
        }
    }
}
