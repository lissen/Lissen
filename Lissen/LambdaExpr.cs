﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lissen
{
    public class LambdaExpr : Function, Sexpr
    {
        private List par;
        private Sexpr form;

        public LambdaExpr(Sexpr par, Sexpr form)
        {
            this.par = par as List;
            this.form = form;
        }

        public override Sexpr ApplyOn(List par, VariablesEnvironment parentEnv)
        {
            var env = new VariablesEnvironment(parentEnv);

            var itLambdaPar = this.par.GetEnumerator();
            var itApplyPar = par.GetEnumerator();

            while (itLambdaPar.MoveNext())
            {
                itApplyPar.MoveNext();

                env.Define(itLambdaPar.Current as Atom, itApplyPar.Current);
            }

            return form.Eval(env);
        }
    }
}