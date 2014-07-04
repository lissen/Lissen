namespace Lissen
{
    public class Atom : Sexpr
    {
        protected string AsString;

        public static Atom s(string s)
        {
            var a = new Atom();
            a.AsString = s;
            return a;
        }

        public Sexpr Eval(VariablesEnvironment env)
        {
            return env.IsDefined(this) ? env.Find(this) : this;
        }

        public override string ToString()
        {
            return this.AsString;
        }

        public override bool Equals(object other)
        {
            var otherAtom = other as Atom;
            if (otherAtom == null)
                return false;
            else
                return this.AsString.Equals(otherAtom.AsString);
        }

        public override int GetHashCode()
        {
            return this.AsString.GetHashCode();
        }
    }
}
