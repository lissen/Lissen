using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Lambda : Function
    {
        public override Sexpr ApplyOn(List par, VariablesEnvironment env)
        {
            return new LambdaExpr(par.Car(), par.Cadr());
        }
    }
}
