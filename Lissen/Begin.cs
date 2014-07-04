namespace Lissen
{
    public class Begin : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            Sexpr lastOne = new Nil();
            foreach (var sexpr in args)
            {
                lastOne = sexpr.Eval(env);
            }
            return lastOne;
        }
    }
}
