using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class NumericOperatorTest : SexprHelpers
    {
        [TestMethod]
        public void WithAtoms()
        {
            var env = new VariablesEnvironment();
            var par = l(new[] { "2", "3" });
            var add = new NumericOperator(Atom.s("+"));
            Assert.AreEqual(Atom.s("5"), add.ApplyOn(par, env));
        }

        [TestMethod]
        public void WithLists()
        {
            var env = new VariablesEnvironment();
            var par = l(new Sexpr[] { a("2"), l(new[] { "-", "8", "3" }) });
            var add = new NumericOperator(Atom.s("+"));
            Assert.AreEqual(Atom.s("7"), add.ApplyOn(par, env));
        }

        [TestMethod]
        public void PredicateEqual()
        {
            var env = new VariablesEnvironment();
            var par1 = l(new[] { "2", "3" });
            var par2 = l(new[] { "3", "3" });
            var equal = new NumericOperator(Atom.s("="));
            Assert.AreEqual(new Nil(), equal.ApplyOn(par1, env));
            Assert.AreEqual(new True(), equal.ApplyOn(par2, env));
        }

        [TestMethod]
        public void PredicateEqualWithVariable()
        {
            var env = new VariablesEnvironment();
            env.Define(a("x"), a("2"));
            var par1 = l(new[] { "x", "3" });
            var par2 = l(new[] { "x", "2" });
            var equal = new NumericOperator(Atom.s("="));
            Assert.AreEqual(new Nil(), equal.ApplyOn(par1, env));
            Assert.AreEqual(new True(), equal.ApplyOn(par2, env));
        }
    }
}
