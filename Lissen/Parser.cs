using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Parser
    {
        public Symbol Parse(string rawString)
        {
            string s = rawString.Trim();
            if (s[0] == '(') return ParseNakedList(s.Substring(1, s.Length - 2));
            return Atom.s(s);
        }

        private Symbol ParseNakedList(string nakedList)
        {
            InnerSplitted i = InnerListSplitter.split(nakedList);

            if (i.inner.Length == 0) return ParseSimpleList(i.after);

            Symbol after = i.after.Length > 0 ? ParseNakedList(i.after) : new Nil();
            if (i.inner.Length > 0)
            {
                return Pair.Cons(Parse(i.inner), after);
            }
            return after;
        }

        private Symbol ParseSimpleList(string s)
        {
            string[] tokens = s.Trim().Split(new char[] { ' ' });
            return ParseTokens(new Stack<string>(tokens), new Nil());
        }

        private Symbol ParseTokens(Stack<string> tokens, Symbol parsed)
        {
            if (tokens.Count == 0) return parsed;
            string last = tokens.Pop();
            return ParseTokens(tokens, Pair.Cons(Parse(last), parsed));
        }
    }
}
