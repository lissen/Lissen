using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Function : Sexpr
    {
        public virtual Sexpr ApplyOn(List par, VariablesEnvironment env)
        {
            throw new NotImplementedException();
        }

        public Sexpr Eval(VariablesEnvironment env)
        {
            return this;
        }
    }
}
