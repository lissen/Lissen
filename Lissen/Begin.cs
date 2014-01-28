using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Begin : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            Sexpr lastOne = new Nil();
            foreach (Sexpr sexpr in args)
            {
                lastOne = sexpr.Eval(env);
            }
            return lastOne;
        }
    }
}
