using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    class WordFileWrapper
    {
        private string _wordFile;
        public WordFileWrapper(string filePath)
        {
            _wordFile = filePath;
        }

        public List<string> GetAllWords()
        {
            List<string> retList = new List<string>();
            using (FileStream fs = new FileStream(_wordFile, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line = sr.ReadLine();
                while(line != null)
                {
                    retList.Add(line);
                    line = sr.ReadLine();
                }
            }
            return retList;
        }
    }
}
