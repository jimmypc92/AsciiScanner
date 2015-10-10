using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    class UtilityClass
    {
        public void ListAsciiInFile(string filePath, byte[] buffer)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            buffer = BufferUtils.RemoveNonAscii(buffer);
            Console.WriteLine(BufferUtils.BytesToString(buffer));
            Console.ReadLine();
        }

        public void TriTest(string wordFilePath)
        {
            WordFileWrapper wfw = new WordFileWrapper(wordFilePath);
            Tri myTri = new Tri(wfw.GetAllWords());
            TriNavigator nav = myTri.GetNavigator();

            var x = 5;
        }
    }
}
