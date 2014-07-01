using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class IfTest : SexprHelpers
    {
        [Test]
        public void IfEqual()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "#t", "3", "4" });
            var si = new If();
            Check.That(si.ApplyOn(par, env)).Equals(Atom.s("3"));
        }

        [Test]
        public void IfNotEqual()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "()", "3", "4" });
            var si = new If();
            Check.That(si.ApplyOn(par, env)).Equals(Atom.s("4"));
        }
    }
}
