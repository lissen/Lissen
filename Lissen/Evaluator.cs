using System;

namespace Lissen
{
    public class Evaluator
    {

        public Symbol Eval(Symbol s)
        {
            if (s == null) return null;
            if (s is Atom) return s;

            Pair p = s as Pair;

            string op = p.Car.ToString();

            Symbol eval1 = Eval(cadr(p));
            Symbol eval2 = Eval(cadr(p.Cdr as Pair));
            var v1 = Convert.ToInt32(eval1.ToString());
            var v2 = Convert.ToInt32(eval2.ToString());

            switch(op) {
                case "+":
                    return Atom.s(Convert.ToString(v1 + v2));                    
                case "-":
                     return Atom.s(Convert.ToString(v1 - v2));
                default:
                     throw new Exception("Unable to evaluate operation: " + op);
            }            
        }

        private Symbol cadr(Pair p)
        {
            return (p.Cdr as Pair).Car;
        }
    }
}
