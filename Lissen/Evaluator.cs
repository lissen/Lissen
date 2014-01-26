using System;

namespace Lissen
{
    public class Evaluator
    {

        public Symbol Eval(Symbol s, VariablesEnvironment env=null)
        {
            if (s is Nil) return s;
            if (s is Atom) return s;

            List list = s as List;

            string op = list.Car().ToString();

            switch (op)
            {
                case "quote":
                    return list.Cadr();
                case "define":
                    Symbol value = Eval(list.Caddr(), env);
                    env.Define(list.Cadr() as Atom, value);
                    return value;
            }

            Symbol eval1 = Eval(list.Cadr());
            Symbol eval2 = Eval(list.Caddr());
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
