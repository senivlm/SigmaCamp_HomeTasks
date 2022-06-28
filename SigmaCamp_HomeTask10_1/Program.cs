using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask10_1
{
    class Program
    {//тест з креативом!
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary;
            try
            {
                Translator translator = new Translator();
                dictionary = TranslatorService.ReadDictionary("../../../Dictionary.txt");
                translator.AddDictionary(dictionary);
                TranslatorService.TranslateByLine("../../../Text.txt", translator);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static string InputTranslation(string word)
        {
            Console.Write($"Введiть замiну для слова {word}: ");
            string value = Console.ReadLine();
            return value;
        }
    }
}
