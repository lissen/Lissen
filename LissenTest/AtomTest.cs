using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class AtomTest
    {
        [TestMethod]
        public void Constructor()
        {
            Atom a = Atom.s("abc");
            Assert.AreEqual("abc", a.ToString());
        }

        [TestMethod]
        public void Eval()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            Atom a = Atom.s("abc");
            Assert.AreEqual(Atom.s("abc"), a.Eval(env));
        }

        [TestMethod]
        public void EvalOperator()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            Atom a = Atom.s("+");
            Assert.IsTrue(a.Eval(env) is NumericOperator);
        }
    }
}
