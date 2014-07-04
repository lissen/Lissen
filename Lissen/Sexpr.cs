namespace Lissen
{
    public interface Sexpr
    {
        string ToString();

        Sexpr Eval(VariablesEnvironment env);
    }
}
