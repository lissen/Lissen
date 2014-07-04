namespace Lissen
{
    public class Cdr : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            return args.Cdr();
        }
    }
}
