using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class NumericOperatorTest : SexprHelpers
    {

        [TestMethod]
        public void AcceptedOperatorsq()
        {
            Assert.IsTrue(NumericOperator.IsAccepted(Atom.s("+")));
            Assert.IsFalse(NumericOperator.IsAccepted(Atom.s("dummy")));
        }

        [TestMethod]
        public void WithAtoms()
        {
            var env = new VariablesEnvironment();
            List par = l(new[] { "2", "3" });
            NumericOperator add = new NumericOperator(Atom.s("+"));
            Assert.AreEqual(Atom.s("5"), add.ApplyOn(par, env));
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
