namespace Lissen
{
    public class If : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            var pred = args.Car().Eval(env);
            if (pred.Equals(new True())) return args.Cadr().Eval(env);
            return args.Caddr().Eval(env);
        }
    }
}
