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
            if (p[0] == '(') return ParsePair(p.Substring(1));
            return Atom.s(p);
        }

        private Symbol ParsePair(string p)
        {
            string[] tokens = p.Split(')');
            return Pair.Cons(Atom.s(tokens[0]), null);
        }
    }
}
