using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class VariablesEnvironment
    {
        private Dictionary<Atom, Symbol> variables = new Dictionary<Atom, Symbol>();

        public bool IsDefined(Atom variable)
        {
            return variables.ContainsKey(variable);
        }

        public void Define(Atom variable, Symbol value)
        {
            variables.Add(variable, value);
        }

        public Symbol Find(Atom variable)
        {
            Symbol value;
            if (!variables.TryGetValue(variable, out value))
            {
                throw new Exception("Variable undefined: " + variable.ToString());
            }
            return value;
        }
    }
}
