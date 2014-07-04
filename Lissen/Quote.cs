namespace Lissen
{
    public class Quote : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            return args.Car();
        }
    }
}
