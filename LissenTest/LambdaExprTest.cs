using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class LambdaExprTest : SexprHelpers
    {
        [TestMethod]
        public void Apply()
        {
            var env = new VariablesEnvironment();
            List form = l(new[] { "+", "2", "3" });
            LambdaExpr lamb = new LambdaExpr(form);
            Assert.AreEqual(a("5"), lamb.ApplyOn(null, env));
        }
    }
}
