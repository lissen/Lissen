using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class QuoteTest : SexprHelpers
    {
        [Test]
        public void Quote()
        {
            var env = new VariablesEnvironment();
            var arg = l(new Sexpr[] {l(new[] { "+", "1", "2"})});
            var quoteFunction = new Quote();
            Check.That(quoteFunction.ApplyOn(arg, env)).Equals(l(new[] {"+", "1", "2"}));
        }
    }
}
