using System.Linq;
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
            var list = new List();
            list.AddRange(stringList.Select(a));
            return list;
        }

        protected List l(Sexpr[] symList)
        {
            var list = new List();
            list.AddRange(symList);
            return list;
        }
    }
}
