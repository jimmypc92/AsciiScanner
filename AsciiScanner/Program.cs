using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    class Program
    {
        static int Main(string[] args)
        {
            if (!ValidateArgs(args)) { return 1; }
            Program p = new Program();
            p.WordsInFile(args[0], args[1]);
            return 0;
        }

        public static bool ValidateArgs(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Too few arguments.");
                PrintUsage();
                return false;
            }
            if(args.Length > 3)
            {
                Console.WriteLine("Too many arguments.");
                PrintUsage();
                return false;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"File: {args[0]} does not exist!");
                PrintUsage();
                return false;
            }
            if (!File.Exists(args[1]))
            {
                Console.WriteLine($"File: {args[1]} does not exist!");
                PrintUsage();
                return false;
            }
            return true;
        }

        public static void PrintUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("AsciiScanner <target_file> <word_list_file>");
        }

        public void WordsInFile(string path_to_target_file, string path_to_file_containing_all_words)
        {
            byte[] buffer;
            using (FileStream fs = new FileStream(path_to_target_file, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            buffer = BufferUtils.RemoveNonAscii(buffer);

            char[] carr = BufferUtils.BytesToChars(buffer);
            WordFileWrapper wfw = new WordFileWrapper(path_to_file_containing_all_words);
            Tri tri = new Tri(wfw.GetAllWords());
            HashSet<string> allWords = Algo.WordsInCharBuffer(carr, tri);

            Output(allWords);
        }

        public void Output(IEnumerable<string> strList)
        {
            Console.WriteLine();
            foreach(string s in strList)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();
        }
    }
}
