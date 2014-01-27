using System;

namespace Lissen
{
    public class Evaluator
    {

        public Sexpr Eval(Sexpr s, VariablesEnvironment env)
        {
            if (s is Nil) return s;
            if (s is Atom)
            {
                Atom a = s as Atom;
                if (env.IsDefined(a)) return env.Find(a);
                else return s;
            }

            List list = s as List;

            string op = list.Car().ToString();

            switch (op)
            {
                case "quote":
                    return list.Cadr();
                case "define":
                    Sexpr value = Eval(list.Caddr(), env);
                    env.Define(list.Cadr() as Atom, value);
                    return value;
            }

            Sexpr eval1 = Eval(list.Cadr(), env);
            Sexpr eval2 = Eval(list.Caddr(), env);
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
