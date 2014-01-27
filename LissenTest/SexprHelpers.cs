using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lissen;

namespace LissenTest
{
    public class SexprHelpers
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

        protected List l(Sexpr[] symList)
        {
            List list = new List();
            foreach (Sexpr s in symList)
            {
                list.Add(s);
            }
            return list;
        }

        protected Sexpr quote(Sexpr s)
        {
            return l(new Sexpr[] { a("quote"), s });
        }
    }
}
