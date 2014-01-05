using System;

namespace Lissen
{
    public class Nil : Symbol
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
