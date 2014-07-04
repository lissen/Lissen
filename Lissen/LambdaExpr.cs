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

        public override Sexpr ApplyOn(List args, VariablesEnvironment parentEnv)
        {
            var env = new VariablesEnvironment(parentEnv);

            var itLambdaPar = this.par.GetEnumerator();
            var itApplyArg = args.GetEnumerator();

            while (itLambdaPar.MoveNext())
            {
                itApplyArg.MoveNext();

                var argValue = itApplyArg.Current.Eval(env);
                env.Define(itLambdaPar.Current as Atom, argValue);
            }

            return form.Eval(env);
        }
    }
}
