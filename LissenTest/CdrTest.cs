using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class CdrTest : SexprHelpers
    {
        [Test]
        public void Cdr()
        {
            var env = new VariablesEnvironment();
            var arg = l(new[] { "a", "b", "c"});
            var cdrFunction = new Cdr();
            Check.That(cdrFunction.ApplyOn(arg, env)).Equals(l(new[] {"b", "c"}));
        }
    }
}
