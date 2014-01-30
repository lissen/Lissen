using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class CondTest : SexprHelpers
    {
        [TestMethod]
        public void CondTrue()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "#t", "a"});
            var par = l(new Sexpr[] { cond1 });
            var condFunction = new Cond();
            Assert.AreEqual(Atom.s("a"), condFunction.ApplyOn(par, env));
        }

        [TestMethod]
        public void CondLastIsTrue()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "()", "a" });
            var cond2 = l(new[] { "#t", "b" });
            var par = l(new Sexpr[] { cond1, cond2 });
            var condFunction = new Cond();
            Assert.AreEqual(a("b"), condFunction.ApplyOn(par, env));
        }

        [TestMethod]
        public void CondAllFalse()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "()", "a" });
            var cond2 = l(new[] { "()", "b" });
            var par = l(new Sexpr[] { cond1, cond2 });
            var condFunction = new Cond();
            Assert.AreEqual(new Nil(), condFunction.ApplyOn(par, env));
        }

        [TestMethod]
        public void CondWithElse()
        {
            var env = new VariablesEnvironment();
            var cond1 = l(new[] { "()", "a" });
            var cond2 = l(new[] { "()", "b" });
            var cond3 = l(new[] { "else", "c" });
            var par = l(new Sexpr[] { cond1, cond2, cond3 });
            var condFunction = new Cond();
            Assert.AreEqual(a("c"), condFunction.ApplyOn(par, env));
        }
    }
}
