using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class CdrTest : SexprHelpers
    {
        [TestMethod]
        public void Cdr()
        {
            var env = new VariablesEnvironment();
            var arg = l(new[] { "a", "b", "c"});
            var cdrFunction = new Cdr();
            Assert.AreEqual(l(new[] { "b", "c" }), cdrFunction.ApplyOn(arg, env));
        }
    }
}
