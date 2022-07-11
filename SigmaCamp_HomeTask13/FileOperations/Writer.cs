
using SigmaCamp_HomeTask13.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    internal class Writer<T>
    {
        private string _filePath;

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (value == null || value == "") throw new FileNotFoundException();
                _filePath = value;
            }
        }
        public Writer(string filePath)
        {
            FilePath =  filePath;
        }
        public void Write(T value)
        {
            using (StreamWriter sw = new(FilePath, true))
            {
                sw.WriteLine(value);
            }
        }
    }
}
