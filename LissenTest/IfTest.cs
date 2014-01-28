using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class IfTest : SexprHelpers
    {
        [TestMethod]
        public void IfEqual()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "#t", "3", "4" });
            var si = new If();
            Assert.AreEqual(Atom.s("3"), si.ApplyOn(par, env));
        }

        [TestMethod]
        public void IfNotEqual()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "()", "3", "4" });
            var si = new If();
            Assert.AreEqual(Atom.s("4"), si.ApplyOn(par, env));
        }
    }
}
