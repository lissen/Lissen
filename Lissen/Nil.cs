namespace Lissen
{
    public class Nil : Atom
    {
        public override string ToString()
        {
            return "()";
        }

        public override bool Equals(object other)
        {
            return other is Nil;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
