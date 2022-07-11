using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    internal class Reader
    {
        private string _filePath;

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (value == null || value == "" || File.Exists(value)) throw new FileNotFoundException();
                _filePath = value;
            }
        }
        public Reader(string filePath)
        {
            this._filePath = filePath;
        }
        public List<string> ReadAllLines()
        {
            List<string> result = new();
            using(StreamReader sr = new(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
            }
            return result;
        }
    }
}
