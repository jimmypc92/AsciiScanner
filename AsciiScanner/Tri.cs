using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    public class Tri
    {
        public TriNode RootNode;
        public Tri(List<string> words)
        {
            RootNode = new TriNode('\0');
            if(!(words == null))
            {
                words.ForEach(word => RootNode.AddString(word));
            }
        }

        public void AddString(string str)
        {
            RootNode.AddString(str);
        }

        public bool HasString(string str)
        {
            return RootNode.HasString(str);
        }

        public TriNavigator GetNavigator()
        {
            return new TriNavigator(RootNode);
        }
    }
}
