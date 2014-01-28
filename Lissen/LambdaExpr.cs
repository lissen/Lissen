using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class LambdaExpr : Function, Sexpr
    {
        private Sexpr form;

        public LambdaExpr(Sexpr form)
        {
            this.form = form;
        }

        public override Sexpr ApplyOn(List par, VariablesEnvironment env)
        {
            return form.Eval(env);
        }
    }
}
