using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    class BufferUtils
    {
        public static byte[] RemoveNonAscii(byte[] buffer)
        {
            List<byte> byteList = new List<byte>();
            foreach(byte b in buffer)
            {
                if(b > 'a' && b < 'z' || b > 'A' && b < 'Z')
                {
                    byteList.Add(b);
                }
            }
            return byteList.ToArray();
        }

        public static string BytesToString(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            foreach(byte b in buffer)
            {
                sb.Append((char)b);
            }
            return sb.ToString();
        }

        public static char[] BytesToChars(byte[] buffer)
        {
            char[] cArr = new char[buffer.Length];
            for(int i = 0; i < buffer.Length; i++)
            {
                cArr[i] = (char)buffer[i];
            }
            return cArr;
        }
    }
}
