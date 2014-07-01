using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class NumericOperatorTest : SexprHelpers
    {
        [Test]
        public void WithAtoms()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "2", "3" });
            var add = new NumericOperator(Atom.s("+"));
            Check.That(add.ApplyOn(par, env)).Equals(Atom.s("5"));
        }

        [Test]
        public void WithLists()
        {
            var env = new VariablesEnvironment();
            var par = l(new Sexpr[] { a("2"), l(new[] { "-", "8", "3" }) });
            var add = new NumericOperator(Atom.s("+"));
            Check.That(add.ApplyOn(par, env)).Equals(Atom.s("7"));
        }

        [Test]
        public void PredicateEqual()
        {
            var env = new VariablesEnvironment();
            var par1 = l(new[] { "2", "3" });
            var par2 = l(new[] { "3", "3" });
            var equal = new NumericOperator(Atom.s("="));
            Check.That(equal.ApplyOn(par1, env)).Equals(new Nil());
            Check.That(equal.ApplyOn(par2, env)).Equals(new True());
        }

        [Test]
        public void PredicateEqualWithVariable()
        {
            var env = new VariablesEnvironment();
            env.Define(a("x"), a("2"));
            var par1 = l(new[] { "x", "3" });
            var par2 = l(new[] { "x", "2" });
            var equal = new NumericOperator(Atom.s("="));
            Check.That(equal.ApplyOn(par1, env)).Equals(new Nil());
            Check.That(equal.ApplyOn(par2, env)).Equals(new True());
        }
    }
}
