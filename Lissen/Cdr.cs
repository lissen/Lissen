using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Cdr : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            return args.Cdr();
        }
    }
}
