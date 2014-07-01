using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class PairTest
    {
        [Test]
        public void ConsSymbols()
        {
            var p = Pair.Cons(Atom.s("1"), Atom.s("2"));

            Check.That(p.Car.ToString()).Equals("1");
            Check.That(p.Cdr.ToString()).Equals("2");
        }

        [Test]
        public void ConsPairs()
        {
            var p = Pair.Cons(Atom.s("1"), Pair.Cons(Atom.s("2"), null));

            Check.That(((Pair) p.Cdr).Car.ToString()).Equals("2");
            Check.That(((Pair) p.Cdr).Cdr).IsNull();
        }
    }
}
