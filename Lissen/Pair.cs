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
            return new Pair { Car = s1, Cdr = s2 };
        }

        public Symbol Car { get; set; }

        public Symbol Cdr { get; set; }

        public Symbol Eval(VariablesEnvironment env)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string s = "(" + Car.ToString();
            if(Cdr != null) s += "." + Cdr.ToString() ;
            return s + ")";
        }

        public override bool Equals(object other)
        {
            Pair otherPair = other as Pair;
            if (otherPair == null) return false;

            if(!this.Car.Equals(otherPair.Car)) return false;
            if (this.Cdr == null) return otherPair.Cdr == null;
            return this.Cdr.Equals(otherPair.Cdr);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
