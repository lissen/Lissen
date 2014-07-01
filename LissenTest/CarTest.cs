using Lissen;
using NFluent;
using NUnit.Framework;

namespace LissenTest
{
    public class CarTest : SexprHelpers
    {
        [Test]
        public void Car()
        {
            var env = new VariablesEnvironment();
            var arg = l(new[] { "a", "b", "c"});
            var carFunction = new Car();
            Check.That(carFunction.ApplyOn(arg, env)).Equals(a("a"));
        }
    }
}
