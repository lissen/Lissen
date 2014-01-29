using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Define : Function
    {
        public override Sexpr ApplyOn(List par, VariablesEnvironment env)
        {
            var car = par.Car();
            
            if (car is Atom)
            {
                var value = par.Cadr().Eval(env);
                env.Define(par.Car() as Atom, value);
                return value;
            }

            if (car is List)
            {
                var functionDef = car as List;
                var functionName = functionDef.Car() as Atom;
                var functionArgs = functionDef.Cdr();
                var functionForm = par.Cadr();
                var lambda = new LambdaExpr(functionArgs, functionForm);
                env.Define(functionName, lambda);
                return lambda;
            }

            throw new Exception("unknow form definition");
        }
    }
}
