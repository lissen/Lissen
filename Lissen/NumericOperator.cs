using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class NumericOperator : Function
    {
        private string op;

        public NumericOperator(Atom op)
        {
            this.op = op.ToString();
        }

        public override Sexpr ApplyOn(List par, VariablesEnvironment env)
        {
            Sexpr param1 = par.Car();
            Sexpr param2 = par.Cadr();

            var v1 = Convert.ToInt32(param1.Eval(env).ToString());
            var v2 = Convert.ToInt32(param2.Eval(env).ToString());

            switch (this.op)
            {
                case "+":
                    return Atom.s(Convert.ToString(v1 + v2));   
                case "-":
                    return Atom.s(Convert.ToString(v1 - v2));
                case "*":
                    return Atom.s(Convert.ToString(v1 * v2));
                case "/":
                    return Atom.s(Convert.ToString(v1 / v2));
                case "=":
                    if (param1.Eval(env).Equals(param2.Eval(env))) return new True();
                    return new Nil();
            }

            throw new NotImplementedException();
        }
    }
}
