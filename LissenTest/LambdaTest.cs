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
            List form = l(new Sexpr[] { l(new[] { "+", "2", "3" }) });
            Lambda lambMaker = new Lambda();

            Sexpr lamb = lambMaker.ApplyOn(form, env);

            Assert.IsTrue(lamb is Function);
            Assert.AreEqual(a("5"), (lamb as Function).ApplyOn(l(new []{ "2" }), env));
        }
    }
}
