using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Evaluator
    {

        public Symbol Eval(Atom a)
        {
            if (a == null) return null;

            return a;
        }

        public Symbol Eval(Pair p)
        {
            if (p == null) return null;

            string op = p.Car.ToString();

            switch(op) {
                case "+":
                    {
                        var v1 = Convert.ToInt32(cadr(p).ToString());
                        var v2 = Convert.ToInt32(cadr(p.Cdr as Pair).ToString());
                        return Atom.s(Convert.ToString(v1 + v2));
                    }
                case "-":
                    {
                        var v1 = Convert.ToInt32(cadr(p).ToString());
                        var v2 = Convert.ToInt32(cadr(p.Cdr as Pair).ToString());
                        return Atom.s(Convert.ToString(v1 - v2));
                    }
            }

            throw new Exception("Unable to evaluate operation: " + op);
        }

        private Symbol cadr(Pair p)
        {
            return (p.Cdr as Pair).Car;
        }
    }
}
