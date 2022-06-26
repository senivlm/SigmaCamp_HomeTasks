using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask10_1
{
    class TranslatorService
    {
        public static void TranslateByLine(string filePath, Translator translator)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File with path {filePath} hasn't been found");
            string line = string.Empty;
            using (StreamWriter writer = new StreamWriter("../../../TranslatedText.txt"))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        writer.WriteLine(translator.TranslateLine(line));
                    }
                }
            }
        }
        public static Dictionary<string, string> ReadDictionary(string filePath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionary");
            using(StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    try
                    {
                        var str = temp.Split(" - ");
                        if (str.Length != 2) throw new ArgumentException($"Incorrect format of key - value in line {temp}");
                        result.Add(str[0], str[1]);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return result;
        }

        public static void WriteToDictionary(string key, string value, string filePath)
        {
            using(StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write($"\n{key} - {value}");
            }
        }
    }
}
