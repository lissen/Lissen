namespace Lissen
{
    public class Car : Function
    {
        public override Sexpr ApplyOn(List args, VariablesEnvironment env)
        {
            return args.Car();
        }
    }
}
