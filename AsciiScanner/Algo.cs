using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    class Algo
    {
        public static HashSet<string> WordsInCharBuffer(char[] carr, Tri possibleWords)
        {
            HashSet<string> retStore = new HashSet<string>();
            for(long i = 0; i < carr.Length; i++)
            {
                TriNavigator nav = possibleWords.GetNavigator();
                long initalLength = 1;
                string initialStr = "";
                RecurseFromCurrent(carr, i, initalLength, nav, initialStr, retStore);
            }
            return retStore;
        }

        public static void RecurseFromCurrent(char[] carr, long curIndex, long curLength, TriNavigator nav, string curStr, HashSet<string> retStore)
        {
            if((curLength + curIndex) > carr.Length) { return; }
            if (!nav.CanMoveTo(carr[curIndex + curLength - 1]))
            {
                return;
            }
            curStr += carr[curIndex + curLength - 1];
            nav.MoveTo(carr[curIndex + curLength - 1]);
            if (nav.CanFinishPath())
            {
                retStore.Add(curStr);
            }
            if (nav.HasNonTerminatingChildren())
            {
                RecurseFromCurrent(carr, curIndex, ++curLength, nav, curStr, retStore);
            }
        }
    }
}
