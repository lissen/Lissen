using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class LambdaTest : SexprHelpers
    {
        [TestMethod]
        public void LambdaCreation()
        {
            var env = new VariablesEnvironment();
            List par = l(new Sexpr[] {  });
            List form = l(new[] { "+", "2", "3" });
            List definition = l(new Sexpr[] { par, form  });
            Lambda lambMaker = new Lambda();

            Sexpr lamb = lambMaker.ApplyOn(definition, env);

            Assert.IsTrue(lamb is Function);
            Assert.AreEqual(a("5"), (lamb as Function).ApplyOn(l(new []{ "2" }), env));
        }
    }
}
