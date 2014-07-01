using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class LambdaTest : SexprHelpers
    {
        [Test]
        public void LambdaCreation()
        {
            var env = new VariablesEnvironment();
            var par = l(new Sexpr[] {  });
            var form = l(new[] { "+", "2", "3" });
            var definition = l(new Sexpr[] { par, form  });
            var lambMaker = new Lambda();

            var lamb = lambMaker.ApplyOn(definition, env);

            Check.That(lamb is Function).IsTrue();
            Check.That((lamb as Function).ApplyOn(l(new[] {"2"}), env)).Equals(a("5"));
        }
    }
}
