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
        private Symbol param1;
        private Symbol param2;

        public NumericOperator(Atom op, List par)
        {
            this.op = op.ToString();
            this.param1 = par.Car();
            this.param2 = par.Cadr();
        }

        public override Symbol Eval(VariablesEnvironment env)
        {
            var v1 = Convert.ToInt32(this.param1.Eval(env).ToString());
            var v2 = Convert.ToInt32(this.param2.Eval(env).ToString());

            switch (this.op)
            {
                case "+":
                    return Atom.s(Convert.ToString(v1 + v2));   
                case "-":
                    return Atom.s(Convert.ToString(v1 - v2));   
            }

            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("({0} {1} {2})", op, param1.ToString(), param2.ToString());
        }
    }
}
