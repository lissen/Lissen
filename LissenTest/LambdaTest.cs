using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class LambdaTest : SexprHelpers
    {
        [TestMethod]
        public void Apply()
        {
            var env = new VariablesEnvironment();
            List form = l(new[] { "+", "2", "3" });
            Lambda lamb = new Lambda(form);
            Assert.AreEqual(a("5"), lamb.ApplyOn(null, env));
        }
    }
}
