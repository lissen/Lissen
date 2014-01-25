using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class VariablesEnvironment
    {
        private Dictionary<Atom, Atom> variables = new Dictionary<Atom, Atom>();

        public bool IsDefined(Atom variable)
        {
            return variables.ContainsKey(variable);
        }

        public void Define(Atom variable, Atom value)
        {
            variables.Add(variable, value);
        }

        public object Get(Atom variable)
        {
            Atom value;
            if (!variables.TryGetValue(variable, out value))
            {
                throw new Exception("Variable undefined: " + variable.ToString());
            }
            return value;
        }
    }
}
