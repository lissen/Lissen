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

        public VariablesEnvironment()
        {
            addBuildIn("+", new NumericOperator(Atom.s("+")));
            addBuildIn("-", new NumericOperator(Atom.s("-")));
            addBuildIn("define", new Define());
            addBuildIn("lambda", new Lambda());
        }

        private void addBuildIn(string s, Sexpr form)
        {
            variables.Add(Atom.s(s), form);
        }

        public bool IsDefined(Atom variable)
        {
            return variables.ContainsKey(variable);
        }

        public void Define(Atom variable, Sexpr value)
        {
            variables.Add(variable, value);
        }

        public Sexpr Find(Atom atom)
        {
            Sexpr value;
            if (!variables.TryGetValue(atom, out value))
            {
                throw new Exception("Variable undefined: " + atom.ToString());
            }
            return value;
        }
    }
}
