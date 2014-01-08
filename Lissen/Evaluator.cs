using System;

namespace Lissen
{
    public class Evaluator
    {

        public Symbol Eval(Symbol s)
        {
            if (s is Nil) return s;
            if (s is Atom) return s;

            List list = s as List;

            string op = list.Car().ToString();

            Symbol eval1 = Eval(list.Cdr());
            Symbol eval2 = Eval(list.Cadr());
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
    }
}
