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

        public static bool IsAccepted(Atom atom)
        {
            string[] accepted = { "+", "-" };
            return accepted.Contains(atom.ToString());
        }

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
            }

            throw new NotImplementedException();
        }
    }
}
