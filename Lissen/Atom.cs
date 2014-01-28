using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Atom : Sexpr
    {
        private string AsString;

        public static Atom s(string s)
        {
            Atom a = new Atom();
            a.AsString = s;
            return a;
        }

        public Sexpr Eval(VariablesEnvironment env)
        {
            //if (NumericOperator.IsAccepted(this)) return new NumericOperator(this);
            //if (AsString == "define") return new Define();
            if (env.IsDefined(this)) return env.Find(this);
            return this;
        }

        public override string ToString()
        {
            return this.AsString;
        }

        public override bool Equals(object other)
        {
            Atom otherAtom = other as Atom;
            if (otherAtom == null)
                return false;
            else
                return this.AsString.Equals(otherAtom.AsString);
        }

        public override int GetHashCode()
        {
            return this.AsString.GetHashCode();
        }


    }
}
