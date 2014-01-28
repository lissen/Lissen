using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class LambdaExprTest : SexprHelpers
    {
        [TestMethod]
        public void ApplyLambdaWithoutParams()
        {
            var env = new VariablesEnvironment();
            List par = new List();
            List form = l(new[] { "+", "2", "3" });
            LambdaExpr lamb = new LambdaExpr(par, form);
            Assert.AreEqual(a("5"), lamb.ApplyOn(new List(), env));
        }

        [TestMethod]
        public void ApplyLambdaWithParams()
        {
            var env = new VariablesEnvironment();
            List par = l(new[] { "x" });
            List form = l(new[] { "+", "x", "3" });
            LambdaExpr lamb = new LambdaExpr(par, form);
            Assert.AreEqual(a("5"), lamb.ApplyOn(l(new[] { "2" }), env));
        }
    }
}
