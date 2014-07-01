using Lissen;
using NFluent;
using NUnit.Framework;
using List = Lissen.List;

namespace LissenTest
{
    public class LambdaExprTest : SexprHelpers
    {
        [Test]
        public void ApplyLambdaWithoutParams()
        {
            var env = new VariablesEnvironment();
            var par = new List();
            var form = l(new[] { "+", "2", "3" });
            var lamb = new LambdaExpr(par, form);
            Check.That(lamb.ApplyOn(new List(), env)).Equals(a("5"));
        }

        [Test]
        public void ApplyLambdaWithParams()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "x" });
            var form = l(new[] { "+", "x", "3" });
            var lamb = new LambdaExpr(par, form);

            Check.That(lamb.ApplyOn(l(new[] {"2"}), env)).Equals(a("5"));
            Check.That(lamb.ApplyOn(l(new[] {"3"}), env)).Equals(a("6"));
        }
    }
}
