using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class NumericOperatorTest : SymbolHelpers
    {
        [TestMethod]
        public void String()
        {
            var add = new NumericOperator(Atom.s("+"), l(new[] { "2", "3" }));
            Assert.AreEqual("(+ 2 3)", add.ToString());
        }

        [TestMethod]
        public void WithAtoms()
        {
            var env = new VariablesEnvironment();
            List par = l(new[] { "2", "3" });
            NumericOperator add = new NumericOperator(Atom.s("+"), par);
            Assert.AreEqual(Atom.s("5"), add.Eval(env));
        }

        //[TestMethod]
        //public void WithLists()
        //{
        //    var env = new VariablesEnvironment();
        //    var par = l(new Symbol[]{ a("2"), l(new[] { "-", "8", "3" })});
        //    var add = new NumericOperator(Atom.s("+"), par);
        //    Assert.AreEqual(Atom.s("7"), add.Eval(env));
        //}

    }
}
