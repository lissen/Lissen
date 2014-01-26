using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public interface Symbol
    {
        string ToString();

        Symbol Eval(VariablesEnvironment env);
    }
}
