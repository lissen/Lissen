using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Define : Function
    {
        public static bool IsAccepted(Atom atom)
        {            
            return atom.ToString().Equals("define");
        }

        public override Sexpr ApplyOn(List par, VariablesEnvironment env)
        {
            var value = par.Cadr().Eval(env);
            env.Define(par.Car() as Atom, value);
            return value;
        }
    }
}
