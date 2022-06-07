using System;
using System.IO;

namespace SigmaCamp_HomeTask6
{
    internal class TextFromFile
    {
        Sentence[] _sentences;
        public TextFromFile(string path)
        {
            string allText;
            using (StreamReader sr = new StreamReader(path))
            {
                allText = sr.ReadToEnd();
                string[] allSentences = allText.Split('.', StringSplitOptions.RemoveEmptyEntries);
                _sentences = new Sentence[allSentences.Length];
                for (int i = 0; i < _sentences.Length; i++)
                {
                    allSentences[i] = allSentences[i].Replace("\r", string.Empty);
                    allSentences[i] = allSentences[i].Replace("\n", string.Empty);
                    string[] words = allSentences[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    _sentences[i] = new Sentence(words);
                }
            }
        }
        public void WriteFormattedText()
        {
            string outputPath = "../../../TextTask6.2_output.txt";
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                foreach (Sentence sentence in _sentences)
                {
                    sw.WriteLine(sentence + ".");
                }
            }
        }
        public string GetMaxAndMinWords()
        {
            string MinAndMaxWordsBySentence = string.Empty;
            for (int i = 0; i < _sentences.Length; i++)
            {
                MinAndMaxWordsBySentence += $"Sentence {i+1}:\n\tLongest words: {_sentences[i].GetLongestWords()}\n\tShortest words: {_sentences[i].GetShortestWords()}\n\n";
            }
            return MinAndMaxWordsBySentence;
        }
    }
}
