using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Quote : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            return args.Car();
        }
    }
}
