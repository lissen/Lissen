using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class VariablesEnvironment
    {
        private Dictionary<Atom, Sexpr> variables = new Dictionary<Atom, Sexpr>();

        public bool IsDefined(Atom variable)
        {
            return variables.ContainsKey(variable);
        }

        public void Define(Atom variable, Sexpr value)
        {
            variables.Add(variable, value);
        }

        public Sexpr Find(Atom variable)
        {
            Sexpr value;
            if (!variables.TryGetValue(variable, out value))
            {
                throw new Exception("Variable undefined: " + variable.ToString());
            }
            return value;
        }
    }
}
