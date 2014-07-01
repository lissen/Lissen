using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class AtomTest
    {
        [Test]
        public void Constructor()
        {
            var a = Atom.s("abc");
            Check.That(a.ToString()).Equals("abc");            
        }

        [Test]
        public void Eval()
        {
            var env = new VariablesEnvironment();
            var a = Atom.s("abc");
            Check.That(a.Eval(env)).Equals(Atom.s("abc"));
        }

        [Test]
        public void EvalOperator()
        {
            var env = new VariablesEnvironment();
            var a = Atom.s("+");
            Check.That(a.Eval(env) is NumericOperator).IsTrue();
        }
    }
}
