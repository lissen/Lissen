using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class List : List<Sexpr>, Sexpr
    {
        public Sexpr Car()
        {
            return this[0];
        }

        public List Cdr()
        {
            this.RemoveAt(0);
            return this;
        }

        public Sexpr Cadr()
        {
            return this[1];
        }

        public Sexpr Caddr()
        {
            return this[2];
        }

        public Sexpr Eval(VariablesEnvironment env)
        {
            NumericOperator op = new NumericOperator(this.Car() as Atom, this.Cdr());
            return op.Eval(env);
        }

        public override string ToString()
        {
            return "(" + String.Join(" ", this) + ")";
        }

        public override bool Equals(object other)
        {
            List otherList = other as List;
            if (otherList == null) return false;
            if (this.Count != otherList.Count) return false;

            Enumerator itThis = this.GetEnumerator();
            Enumerator itOther = otherList.GetEnumerator();

            while (itThis.MoveNext())
            {
                itOther.MoveNext();

                if (!itThis.Current.Equals(itOther.Current)) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


    }
}
