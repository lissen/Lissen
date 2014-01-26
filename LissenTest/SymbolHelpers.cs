using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lissen;

namespace LissenTest
{
    public class SymbolHelpers
    {
        protected Atom a(string s)
        {
            return Atom.s(s);
        }

        protected List l(string[] stringList)
        {
            List list = new List();
            foreach (string s in stringList)
            {
                list.Add(a(s));
            }
            return list;
        }

        protected List l(Symbol[] symList)
        {
            List list = new List();
            foreach (Symbol s in symList)
            {
                list.Add(s);
            }
            return list;
        }

        protected Symbol quote(Symbol s)
        {
            return l(new Symbol[] { a("quote"), s });
        }
    }
}
