using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public interface Sexpr
    {
        string ToString();

        Sexpr Eval(VariablesEnvironment env);
    }
}
