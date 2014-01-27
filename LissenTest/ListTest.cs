using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lissen;

namespace LissenTest
{
    [TestClass]
    public class ListTest : SymbolHelpers
    {
        private List abc;

        [TestInitialize]
        public void SetUp()
        {
            abc = l(new[] { "a", "b", "c" });
        }

        [TestMethod]
        public void Car()
        {
            Assert.AreEqual(a("a"), abc.Car());
        }

        [TestMethod]
        public void Cdr()
        {
            Assert.AreEqual(l(new[] { "b", "c" }), abc.Cdr());
        }

        [TestMethod]
        public void Cadr()
        {
            Assert.AreEqual(a("b"), abc.Cadr());
        }

        [TestMethod]
        public void Caddr()
        {
            Assert.AreEqual(a("c"), abc.Caddr());
        }

        [TestMethod]
        public void Eval()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            List list = l(new[] { "+", "2", "3" });
            Assert.AreEqual(a("5"), list.Eval(env));
        }

        public void EvalNestedLists()
        {
            VariablesEnvironment env = new VariablesEnvironment();
            List list = l(new Sexpr[] { a("+"), a("3"), l(new[] { "+", "2", "3" })});
            Assert.AreEqual(a("8"), list.Eval(env));
        }
    }
}
