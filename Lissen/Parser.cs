using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Parser
    {
        public Symbol Parse(string p)
        {
            char c = p[0];
            if (p[0] == '(') return ParseList(p.Substring(1).TrimEnd(new char[] {')', ' '}));
            return Atom.s(p);
        }

        private Symbol ParseList(string p)
        {
            string[] tokens = p.Split(new char[] {' '});
            return ParseTokenList(new Queue<string>(tokens));
        }

        private Symbol ParseTokenList(Queue<string> tokens)
        {
            if (tokens.Count == 0) return null;
            string head = tokens.Dequeue();
            return Pair.Cons(Atom.s(head), ParseTokenList(tokens));
        }
    }
}
