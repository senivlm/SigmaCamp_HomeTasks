using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask6
{
    internal class Sentence
    {
        string[] _words;
        public Sentence(string[] words)
        {
            if (words != null)
            {
                _words = words;
            }
            else
            {
                throw new ArgumentNullException("No words to create sentence");
            }
        }
        public string GetLongestWords()
        {
            string maxWord = _words[0];
            string maxWords = _words[0];
            for (int i = 1; i < _words.Length; i++)
            {
                if (_words[i].Length > maxWord.Length)
                {
                    maxWord = maxWords = _words[i];
                }
                else if (_words[i].Length == maxWord.Length)
                {
                    maxWords+= ", "+ _words[i];
                }
            }
            return maxWords;
        }
        public string GetShortestWords()
        {
            string minWord = _words[0];
            string minWords = _words[0];
            for (int i = 1; i < _words.Length; i++)
            {
                if (_words[i].Length < minWord.Length)
                {
                    minWord = minWords = _words[i];
                }
                else if (_words[i].Length == minWord.Length)
                {
                    minWords += ", " + _words[i];
                }
            }
            return minWords;
        }
        public override string ToString()
        {
            string sentence = string.Empty;
            for (int i = 0; i < _words.Length; i++)
            {
                sentence += $" {_words[i]}";
            }
            return sentence;
        }
    }
}
