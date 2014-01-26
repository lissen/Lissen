using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class Function : Symbol
    {
        public virtual Symbol Eval(VariablesEnvironment env)
        {
            throw new NotImplementedException();
        }
    }
}
