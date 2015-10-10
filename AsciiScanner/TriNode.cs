using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiScanner
{
    public class TriNode
    {
        public char NodeChar;
        private HashSet<TriNode> _nodeSet;
        private List<char> _childrenLetterList;
        public TriNode(char nodeChar)
        {
            this.NodeChar = nodeChar;
            _nodeSet = new HashSet<TriNode>();
        }

        public override bool Equals(object obj)
        {
            TriNode node = obj as TriNode;
            if (node == null) return false;
            return this.NodeChar == node.NodeChar;
        }

        public override int GetHashCode()
        {
            return NodeChar.GetHashCode();
        }

        public bool HasString(string str)
        {
            if(str == null) { return true; }
            if(str.Length == 0)
            {
                return _nodeSet.Any(node => node.NodeChar == '\0');
            }
            foreach(TriNode node in _nodeSet)
            {
                if (node.NodeChar.Equals(str.ToArray()[0]))
                {
                    return node.HasString(str.Substring(1));
                }
            }
            return false;
        }

        public void AddString(string str)
        {
            if(str == null)
            {
                return;
            }
            if(str.Length == 0) { AddChild('\0'); return; }
            char c = str.ToArray()[0];
            TriNode possibleNode = GetChild(c);
            if(possibleNode == null)
            {
                possibleNode = new TriNode(c);
                _nodeSet.Add(possibleNode);
            }
            _nodeSet.Add(possibleNode);
            possibleNode.AddString(str.Substring(1));
        }

        public TriNode GetChild(char c)
        {
            foreach (TriNode node in _nodeSet)
            {
                if (node.NodeChar == c)
                {
                    return node;
                }
            }
            return null;
        }

        public List<char> ChildrenLetters
        {
            get
            {
                if(_childrenLetterList == null)
                {
                    _childrenLetterList = new List<char>();
                }
                _childrenLetterList.Clear();
                _nodeSet.ToList().ForEach(node => _childrenLetterList.Add(node.NodeChar));
                return _childrenLetterList;
            }
        }

        public string ChildLettersAsString
        {
            get
            {
                string s = "";
                foreach(TriNode n in _nodeSet)
                {
                    s += n.NodeChar;
                }
                return s;
            }
        }

        public void AddChild(char c)
        {
            if(GetChild(c) == null) { _nodeSet.Add(new TriNode(c)); }
        }
    }
}
