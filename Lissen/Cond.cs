using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Cond : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            foreach (var a in args)
            {
                var cond = a as List;
                if(cond.Car().Equals(Atom.s("else")))
                    return cond.Cadr().Eval(env);

                var pred = cond.Car().Eval(env);
                if (pred.Equals(new True())) return cond.Cadr().Eval(env);
            }
            return new Nil();
        }
    }
}
