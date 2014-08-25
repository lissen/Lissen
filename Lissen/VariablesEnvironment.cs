using System;
using System.Collections.Generic;

namespace Lissen
{
    public class VariablesEnvironment
    {
        private readonly Dictionary<Atom, Sexpr> variables = new Dictionary<Atom, Sexpr>();
        private readonly VariablesEnvironment parentEnv = null;

        public VariablesEnvironment()
        {
            AddBuildIn("+", new NumericOperator(Atom.s("+")));
            AddBuildIn("-", new NumericOperator(Atom.s("-")));
            AddBuildIn("*", new NumericOperator(Atom.s("*")));
            AddBuildIn("/", new NumericOperator(Atom.s("/")));
            AddBuildIn("=", new NumericOperator(Atom.s("=")));
            AddBuildIn("define", new Define());
            AddBuildIn("lambda", new Lambda());
            AddBuildIn("if", new If());
            AddBuildIn("begin", new Begin());
            AddBuildIn("cond", new Cond());
        }

        public VariablesEnvironment(VariablesEnvironment parentEnv)
        {            
            this.parentEnv = parentEnv;
        }

        private void AddBuildIn(string s, Sexpr form)
        {
            variables.Add(Atom.s(s), form);
        }

        public bool IsDefined(Atom variable)
        {
            if (variables.ContainsKey(variable)) return true;
            if (parentEnv != null) return parentEnv.IsDefined(variable);
            return false;
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
                if (parentEnv != null) return parentEnv.Find(atom);
                else throw new Exception("Variable undefined: " + atom.ToString());
            }
            return value;
        }
    }
}
