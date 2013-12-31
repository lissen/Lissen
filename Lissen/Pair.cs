using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Pair : Symbol
    {
        public static Pair Cons(Symbol s1, Symbol s2)
        {
            return new Pair
            {
                Car = s1, Cdr = s2
            };
        }

        public Symbol Car { get; set; }

        public Symbol Cdr { get; set; }
    }
}
