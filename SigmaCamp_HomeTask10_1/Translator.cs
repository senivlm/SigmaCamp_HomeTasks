using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask10_1
{
    class Translator
    {
        private Dictionary<string, string> _vocabulary;
        private string _pathToDictionary;
        private int countVariedle = 3;

        public Translator() : this( @"../../../Dictionary.txt")
        {

        }

        public Translator(string pathToDictionary)
        {
            _vocabulary = new Dictionary<string, string>();
            _pathToDictionary = pathToDictionary;
        }

        public Translator(Dictionary<string, string> vocabulary, string text, string pathToDictionary)
        {
            _pathToDictionary = pathToDictionary;
            //проблема неглибоких копій
            _vocabulary = vocabulary;
        }
        public void AddDictionary(Dictionary<string, string> dictionary)
        {
             //проблема неглибоких копій
            _vocabulary = dictionary;
        }

        public string TranslateLine(string line)
        {
            string result = string.Empty;
            var words = line.Split(' ');
            foreach (string word in words)
            {
                char temp = ' ';
                string tempWord = "";
                int i = 0;
                if (word != "")
                {
                    if (Char.IsPunctuation(word[word.Length - 1]))
                    {
                        temp = word[word.Length - 1];
                        while (!_vocabulary.ContainsKey(word[0..^1]) && i < countVariedle)
                        {
                            AddTranslation(word[0..^1]);
                            i++;
                        }
                        tempWord = _vocabulary[word[0..^1]] + temp;
                    }
                    else
                    {
                        while (!_vocabulary.ContainsKey(word) && i < countVariedle)
                        {
                            AddTranslation(word);
                            i++;
                        }
                        tempWord = _vocabulary[word];
                    }
                }              
                result += tempWord + " ";
            }

            return result;
        }
        public void AddTranslation(string word)
        {
            string value = Program.InputTranslation(word);
            _vocabulary.Add(word, value);
            TranslatorService.WriteToDictionary(word, value, _pathToDictionary);
        }
    }
}
