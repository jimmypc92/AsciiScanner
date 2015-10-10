using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    public class TriNavigator
    {
        public TriNode CurrentNode;
        public TriNavigator(TriNode seedNode)
        {
            CurrentNode = seedNode;
        }

        public bool CanMoveTo(char c)
        {
            return CurrentNode.GetChild(c) != null;
        }

        public List<char> PossibleMoves
        {
            get
            {
                return CurrentNode.ChildrenLetters;
            }
        }

        public void MoveTo(char c)
        {
            if (!CanMoveTo(c)) { throw new Exception("Tried to move to an invalid path."); }
            CurrentNode = CurrentNode.GetChild(c);
        }

        public bool CanFinishPath()
        {
            return CanMoveTo('\0');
        }

        public bool HasNonTerminatingChildren()
        {
            int expectedLength = 1;
            if (CanFinishPath()) { expectedLength++; }
            return this.PossibleMoves.Count >= expectedLength;
        }

        public bool TryMoveTo(char c)
        {
            if (CanMoveTo(c))
            {
                MoveTo(c);
                return true;
            }
            return false;
        }
    }
}
