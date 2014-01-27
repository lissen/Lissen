using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Pair : Sexpr
    {
        public static Pair Cons(Sexpr s1, Sexpr s2)
        {
            return new Pair { Car = s1, Cdr = s2 };
        }

        public Sexpr Car { get; set; }

        public Sexpr Cdr { get; set; }

        public Sexpr Eval(VariablesEnvironment env)
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
