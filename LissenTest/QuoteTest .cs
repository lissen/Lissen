using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class QuoteTest : SexprHelpers
    {
        [TestMethod]
        public void Quote()
        {
            var env = new VariablesEnvironment();
            var arg = l(new Sexpr[] {l(new[] { "+", "1", "2"})});
            var quoteFunction = new Quote();
            Assert.AreEqual(l(new[] { "+", "1", "2" }), quoteFunction.ApplyOn(arg, env));
        }
    }
}
